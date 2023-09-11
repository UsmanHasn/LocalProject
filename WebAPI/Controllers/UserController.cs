using Domain.Entities;
using Domain.Modeles;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using Service.Helper;
using Service.Interface;
using Service.Models;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/users/")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("getalluserslist")]
        public IActionResult GetAllUser()
        {
            List<UserListModel> model = new List<UserListModel>();
            model = _userService.GetAllUsers();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }


        [HttpGet]
        [Route("getUserbyId")]
        public IActionResult GetUserById(int Id)
        {
            UserModel model = new UserModel();
            model = _userService.GetUserById(Id);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("getallroles")]
        public IActionResult GetAllRoles(int UID)
        {
            List<UserAssignRole> model = new List<UserAssignRole>();
            model = _userService.GetAllUserRole(UID);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("InsertUser")]
        public IActionResult Add(UserModel model, string userName)
        {
            if (model.Id > 0)
            {
                UserModel _userModel = _userService.GetUserById(model.Id);
                model.CreatedDate = _userModel.CreatedDate;
                model.CreatedBy = _userModel.CreatedBy;
                _userService.UpdateUser(model, userName);
            }
            else
            {
                UserModel usrModel = _userService.checkDuplicate(model.CivilID, model.Email, model.Mobile);
                if (usrModel == null)
                {
                    _userService.Add(model, userName);
                }
                else
                {
                    return null;
                } 
                
            }
            _userService.AddUserInRole(model.AssignRoleIds, model.Id, userName);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("UpdateUserFirstLogin")]
        public IActionResult UpdateFirstLogin(int UserId,string userName)
        {
            if (UserId > 0)
            {
                
                _userService.UpdateUserFirstLogin(UserId, userName);
            }
            UserModel _userModel = _userService.GetUserById(UserId);
            return new JsonResult(new { data = _userModel, status = HttpStatusCode.OK });
        }


        [HttpPost]
        [Route("InsertUserActivity")]
        public IActionResult AddUserActivity(UserActivityInfoLogModel model, string userName)
        {
            _userService.AddActivity(model, userName);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("getUserActivityLogbyId")]
        public IActionResult GetUserUserActivityLogById(int ID)
        {
            UserActivityInfoLogModel model = new UserActivityInfoLogModel();
            model = _userService.GetActivityById(ID);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }


        [HttpPost]
        [Route("updateUserStatus")]
        public IActionResult UpdateUserStatus(Service.Models.UserStatusModel model)
        {
            _userService.UpdateUserStatus(model);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("GenerateNumericOTP")]
        public IActionResult GenerateNumericOTP(string Email, int UserId,int OTPType)
        {
            
            const string validChars = "0123456789";
            byte[] randomBytes = new byte[6];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }

            StringBuilder otpBuilder = new StringBuilder(6);
            foreach (byte dataByte in randomBytes)
            {
                int index = dataByte % validChars.Length;
                otpBuilder.Append(validChars[index]);
            }

            EmailHelper.sendMail(Email, "OTP Verification - التحقق من OTP", otpBuilder.ToString());
            Service.Models.OtpModel model = new Service.Models.OtpModel()
            {
                OtpId = otpBuilder.ToString(),
                OtpType = OTPType,
                UserId = UserId,
                EmailSent = true,
                OTPExpiry = DateTime.Now.AddMinutes(2)
            };
            _userService.InsertOtp(model);


            return new JsonResult(new { data = otpBuilder.ToString(), email=Email, otpexpiry = model.OTPExpiry, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("OTPverify")]
        public IActionResult OTPverify(Service.Models.OtpModel model)
        {
            return new JsonResult(new { data = _userService.VerifyOtp(model), status = HttpStatusCode.OK });
        }

    }
}
