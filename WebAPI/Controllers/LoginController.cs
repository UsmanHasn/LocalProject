﻿using Microsoft.AspNetCore.Mvc;
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
using Service.Helper;
using Microsoft.AspNet.Identity;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Components.Forms;
using System.Drawing;
using WebAPI.Manager;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IRepository<SEC_Users> _usersRepository;
        private readonly IRepository<SEC_UserInRole> _userInRoleRepository;
        private readonly IUserService _userService;
        public LoginController(IConfiguration config, IRepository<SEC_Users> usersRepository, IRepository<SEC_UserInRole> userInRoleRepository,
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
                    var check = _userService.GetUserById(user.UserId);
                    if (user.RoleId == 0)
                    {
                        return new JsonResult(new { token = "Noroleassigned", success = false, status = HttpStatusCode.OK });
                    }
                    if (check.WrongPassword == 5)
                        return new JsonResult(new { token = "Your account has been locked, Please contact the admin", success = false, status = HttpStatusCode.OK });

                    if (check.UserStatusId == 1)
                    {
                        var data =_userService.GetrevokedTokenModel(user.CivilID,null);
                        Service.Models.RevokedTokenModel revokedTokenModel = new Service.Models.RevokedTokenModel();

                        var token = GenerateToken(user);
                        if (data != null)
                        {
                            
                            
                                revokedTokenModel.Token = data.Token;
                                revokedTokenModel.Reason = "Revoked login again";
                                revokedTokenModel.CivilID = data.CivilID;

                            if (data.IsActive)
                            {
                                TokenRevocationService tokenRevocationService = new TokenRevocationService();

                                _userService.UpdaterevokedTokenModel(revokedTokenModel);
                                tokenRevocationService.RevokeToken(data.Token);

                            }
                          
                        }
                        //inser token into db 
                        revokedTokenModel.Token = token;
                        revokedTokenModel.Reason = "Revoked login again";
                        revokedTokenModel.CivilID = user.CivilID;

                        _userService.InsertrevokedTokenModel(revokedTokenModel);

                        _userService.AddActivity(user.UserId, "Login", "Form Authentication - User Logged In", DateTime.Now, user.Username);
                        return new JsonResult(new { token = token, user = user, success = true, status = HttpStatusCode.OK });
                    }
                    else return new JsonResult(new { token = "Your account has been locked, Please contact the admin", success = false, status = HttpStatusCode.OK });
                }
                else
                {
                    try
                    {
                        _userService.UpdateLoginAttempts(Convert.ToInt32(userLogin.Username));
                    }
                    catch (Exception)
                    {

                        //throw;
                    }
                }
            }


            return new JsonResult(new { token = "Invalid authentication", success = false, status = HttpStatusCode.OK });
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("authenticatemobile")]
        public async Task<ActionResult> Login(string civilNo)
        {
            try
            {
                var user = await Authenticate(civilNo);
                if (user != null && user.UserId == 0)
                {
                    return new JsonResult(new { message = "PKI Authentication successfully. User does not exist", user = user, success = true, status = HttpStatusCode.NoContent });
                }
                else if (user != null && user.UserId > 0)
                {
                    if (user.RoleId == 0)
                    {
                        return new JsonResult(new { token = "Noroleassigned", success = false, status = HttpStatusCode.OK });
                    }
                    var token = GenerateToken(user);
                    //inser token into db 
                    _userService.AddActivity(user.UserId, "Login", "Mobile PKI - User Authenticated by PKI and logged In", DateTime.Now, user.Username);
                    return new JsonResult(new { token = token, user = user, success = true, status = HttpStatusCode.OK });
                }
                return new JsonResult(new { token = "Invalid authentication", success = false, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("InvokeMobilePKI")]
        public async Task<ActionResult> InvokePKI(string mobileNo)
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var response = new InovokeMobilePKIResponseModel();
            try
            {
                var responseString = await httpClientHelper.MakeHttpRequestJsonString<InovokeMobilePKIRequestModel, InovokeMobilePKIResponseModel>
                    ("http://" + SjcConstants.baseIp + "84/api/GovServ/InvokeMobilePKI/" + mobileNo, HttpMethod.Get, null, null);
                HttpPKIResponseModel httpStringResponse = JsonConvert.DeserializeObject<HttpPKIResponseModel>(responseString);
                //response = JsonConvert.DeserializeObject<InovokeMobilePKIResponseModel>(httpStringResponse.data);
                return new JsonResult(new { data = httpStringResponse });
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet]
        [Route("InvokeMobilePKIStatus")]
        public async Task<ActionResult> InvokeMobilePKIStatus(string transId)
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var response = new InovokeMobilePKIResponseModel();
            try
            {
                var responseString = await httpClientHelper.MakeHttpRequestJsonString<InovokeMobilePKIRequestModel, InovokeMobilePKIResponseModel>
                    ("http://" + SjcConstants.baseIp + "84/api/GovServ/InvokeMobilePKIStatus/" + transId, HttpMethod.Get, null, null);
                HttpPKIResponseModel httpStringResponse = JsonConvert.DeserializeObject<HttpPKIResponseModel>(responseString);
                //response = JsonConvert.DeserializeObject<InovokeMobilePKIResponseModel>(httpStringResponse.data);
                return new JsonResult(new { data = httpStringResponse });
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet]
        [Route("RefreshToken")]
        public async Task<ActionResult> RefreshToken(string token, string identifier)
        {
            try
            {
                var currentUser = _usersRepository.GetSingle(x => x.CivilNumber == identifier);
                if (currentUser != null)
                {
                    SEC_Roles role = _userInRoleRepository.GetSingle(x => x.UserId == currentUser.Id, x => x.Role).Role;
                    var user = new UsersModel()
                    {
                        UserId = currentUser.Id,
                        Username = currentUser.UserName,
                        UsernameAr = currentUser.UserNameAr,
                        CivilID = currentUser.CivilNumber.ToString(),
                        Email = currentUser.Email,
                        MobileNo = currentUser.PhoneNumber,
                        RoleId = role == null ? 0 : role.Id,
                        Role = role == null ? "" : role.Name,
                        LastLoginDate = currentUser.LastLoginDate
                    };
                    return new JsonResult(new { token = GetRefreshToken(user), status = true });
                }
                return new JsonResult(new { message = "Invalid Authentication", status = false });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        // To generate token
        private string GenerateToken(UsersModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.CivilID),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GetRefreshToken(UsersModel user)
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
                expires: DateTime.Now.AddDays(1),
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
                var roleRepo = _userInRoleRepository.GetSingle(x => x.UserId == currentUser.Id && x.Deleted == false, x => x.Role);
                SEC_Roles? role = roleRepo != null ? roleRepo.Role : null;
                return new UsersModel()
                {
                    UserId = currentUser.Id,
                    Username = currentUser.UserName,
                    UsernameAr = currentUser.UserNameAr,
                    CivilID = currentUser.CivilNumber.ToString(),
                    Email = currentUser.Email,
                    MobileNo = currentUser.PhoneNumber,
                    RoleId = role == null ? 0 : role.Id,
                    Role = role == null ? "" : role.Name,
                    RoleAr = role == null ? "" : role.NameAr,
                    LastLoginDate = currentUser.LastLoginDate,
                    CRNo = "",
                    CRName = "",
                    EntityId = 0,
                    EntityName = "",
                    CivilExpiry = currentUser.CivilExpiryDate,
                    IsEmailVerified = currentUser.isEmailVerified,
                    IsPhoneVerified = currentUser.isPhoneVerified,
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

            SEC_Roles role = _userInRoleRepository.GetSingle(x => x.UserId == userByCivilNo.Id && x.Role.Name == SjcConstants.roleIndividual, x => x.Role).Role;
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
                RoleAr = role == null ? "" : role.Name,
                LastLoginDate = userByCivilNo.LastLoginDate,
                CRNo = "", CRName = "", EntityId = 0, EntityName = "",
                CivilExpiry = userByCivilNo.CivilExpiryDate
            };
            return user;
        }





        [AllowAnonymous]
        [HttpPost]
        [Route("forgotPassword")]
        public ActionResult ForgotPassword([FromBody] ForgotPasswordModel forgotPassword)
        {
            string message = "";
            var user = _usersRepository.GetSingle(x => x.CivilNumber == forgotPassword.CivilNo && x.Email == forgotPassword.Email);
            if (user != null)
            {

                var pass = Guid.NewGuid();
                user.Password = "12345";
                _usersRepository.Update(user, "System");
                _usersRepository.Save();

                var fullPath = Path.Combine(Directory.GetCurrentDirectory() + "/Assets/EmailTemplates/", "ForgotPassword.txt");

                string messageBody = System.IO.File.ReadAllText(fullPath);
                if (!string.IsNullOrEmpty(messageBody))
                {
                    message = messageBody.Replace("{username}", user.UserName);
                    message = message + " " + user.Password;
                }

                EmailHelper.sendMail(user.Email, "ForgotPassword ", message);
                return new JsonResult(new { success = true, status = HttpStatusCode.OK });
            }
            return new JsonResult(new { token = "Invalid authentication", success = false, status = HttpStatusCode.OK });
        }



    }
}
