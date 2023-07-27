using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Helper;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;
using Data.Interface;
using Domain.Entities;
using WebAPI.Models.APIModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IRepository<Users> _usersRepository;
        private readonly IRepository<UserInRole> _userInRoleRepository;
        public LoginController(IConfiguration config, IRepository<Users> usersRepository, IRepository<UserInRole> userInRoleRepository)
        {
            _config = config;
            _usersRepository = usersRepository;
            _userInRoleRepository = userInRoleRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public ActionResult Login([FromBody] UserLoginModel userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = GenerateToken(user);
                return new JsonResult(new { token = token, user = user, success = true, status = HttpStatusCode.OK });
            }
            return new JsonResult(new { token = "Invalid authentication", success = false, status = HttpStatusCode.OK });
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("authenticatemobile")]
        public async Task<ActionResult> Login(string mobileNo)
        {
            var user = await Authenticate(mobileNo);
            if (user != null && user.UserId == 0)
            {
                return new JsonResult(new { message = "PKI Authentication successfully. User does not exist", user = user, success = true, status = HttpStatusCode.NoContent });
            }
            else if (user != null && user.UserId > 0)
            {
                var token = GenerateToken(user);
                return new JsonResult(new { token = token, user = user, success = true, status = HttpStatusCode.OK });
            }
            return new JsonResult(new { token = "Invalid authentication", success = false, status = HttpStatusCode.OK });
        }

        // To generate token
        private string GenerateToken(UsersModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Username),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //To authenticate user
        private UsersModel Authenticate(UserLoginModel userLogin)
        {
            //var currentUser = SjdcConstants.Users.FirstOrDefault(x => x.Username.ToLower() ==
            //    userLogin.Username.ToLower() && x.Password == userLogin.Password);
            var currentUser = _usersRepository.GetSingle(x => x.CivilNumber.ToString() == userLogin.Username && x.Password == userLogin.Password);
            if (currentUser != null)
            {
                Roles role = _userInRoleRepository.GetSingle(x => x.UserId == currentUser.Id, x => x.Role).Role;
                return new UsersModel()
                {
                    UserId = currentUser.Id,
                    Username = currentUser.UserName,
                    UsernameAr = currentUser.UserNameAr,
                    CivilID = currentUser.CivilNumber.ToString(),
                    Email = currentUser.Email,
                    MobileNo = currentUser.PhoneNumber,
                    RoleId = role == null ? 0 : role.Id,
                    Role = role == null ? "" : role.Name
                };
                //return currentUser;
            }
            return null;
        }
        private async Task<UsersModel> Authenticate(string mobileNo)
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var response = new HttpResponseModel<MobilePKIResponseModel>();
            try
            {
                response = await httpClientHelper.MakeHttpRequest<HttpResponseModel<MobilePKIRequestModel>, HttpResponseModel<MobilePKIResponseModel>>("https://integrationsvc.com/api/GovServ/MobilePKI/" + mobileNo, HttpMethod.Get, null, null);
            }
            catch (Exception ex)
            {
                return null;
            }
            if (response == null)
            {
                //will remove below code when api availables.
                response = SjcConstants.getPKIResponse(mobileNo);
                if (response == null)
                {
                    return null;
                }
            }
            
            MobilePKIResponseModel resp = (response != null ? response.data[0] : null);
            var userByCivilNo = _usersRepository.GetSingle(x => x.CivilNumber == resp.CivilNo);
            if (userByCivilNo == null)
            {
                return new UsersModel()
                {
                    CivilID = resp.CivilNo.ToString()
                };
                
            }

            Roles role = _userInRoleRepository.GetSingle(x => x.UserId == userByCivilNo.Id && x.Role.Name == SjcConstants.roleIndividual, x => x.Role).Role;
            var user = new UsersModel()
            {
                UserId = userByCivilNo.Id,
                Username = userByCivilNo.UserName,
                UsernameAr = userByCivilNo.UserNameAr,
                CivilID = userByCivilNo.CivilNumber.ToString(),
                Email = userByCivilNo.Email,
                MobileNo = userByCivilNo.PhoneNumber,
                RoleId = role == null ? 0 : role.Id,
                Role = role == null ? "" : role.Name
            };
            return user;
        }
    }
}
