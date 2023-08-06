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
using Service.Interface;
using Service.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IRepository<Users> _usersRepository;
        private readonly IRepository<UserInRole> _userInRoleRepository;
        private readonly IUserService _userService;
        public LoginController(IConfiguration config, IRepository<Users> usersRepository, IRepository<UserInRole> userInRoleRepository,
               IUserService userService)
        {
            _config = config;
            _usersRepository = usersRepository;
            _userInRoleRepository = userInRoleRepository;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public ActionResult Login([FromBody] UserLoginModel userLogin)
        {
            if (!string.IsNullOrEmpty(userLogin.Password))
            {
                var user = Authenticate(userLogin);
                if (user != null)
                {
                    var token = GenerateToken(user);
                    _userService.AddActivity(user.UserId, "Login", "Form Authentication - User Logged In", DateTime.Now, user.Username);
                    return new JsonResult(new { token = token, user = user, success = true, status = HttpStatusCode.OK });
                }
            }
            
            return new JsonResult(new { token = "Invalid authentication", success = false, status = HttpStatusCode.OK });
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("authenticatemobile")]
        public async Task<ActionResult> Login(string civilNo)
        {
            var user = await Authenticate(civilNo);
            if (user != null && user.UserId == 0)
            {
                _userService.AddActivity(user.UserId, "Login", "Mobile PKI - User Authenticated by PKI but not exists in system", DateTime.Now, user.Username);
                return new JsonResult(new { message = "PKI Authentication successfully. User does not exist", user = user, success = true, status = HttpStatusCode.NoContent });
            }
            else if (user != null && user.UserId > 0)
            {
                var token = GenerateToken(user);
                _userService.AddActivity(user.UserId, "Login", "Mobile PKI - User Authenticated by PKI and logged In", DateTime.Now, user.Username);
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
            var currentUser = _usersRepository.GetSingle(x => x.CivilNumber == userLogin.Username && x.Password == userLogin.Password);
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
        private async Task<UsersModel> Authenticate(string civilNo)
        {
            #if debug
               if (civilNo == "85923849")
               {
                    civilNo = "2189511";
               }             
            #endif
            var userByCivilNo = _usersRepository.GetSingle(x => x.CivilNumber == civilNo);
            if (userByCivilNo == null)
            {
                return new UsersModel()
                {
                    CivilID = civilNo,
                    UserId = 0
                };
                
            }

            Roles role = _userInRoleRepository.GetSingle(x => x.UserId == userByCivilNo.Id && x.Role.Name == SjcConstants.roleIndividual, x => x.Role).Role;
            var user = new UsersModel()
            {
                UserId = userByCivilNo.Id,
                Username = userByCivilNo.UserName,
                UsernameAr = userByCivilNo.UserNameAr,
                CivilID = userByCivilNo.CivilNumber,
                Email = userByCivilNo.Email,
                MobileNo = userByCivilNo.PhoneNumber,
                RoleId = role == null ? 0 : role.Id,
                Role = role == null ? "" : role.Name,
                RoleAr = role == null ? "" : role.Name
            };
            return user;
        }
    }
}
