using Data.Interface;
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
using WebAPI.Manager;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/users/")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRepository<Users> _userRepository;
        private readonly JsonRequestManager jsonRequestManager;
        public UserController(IUserService userService, IRepository<Users> userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
            jsonRequestManager = new JsonRequestManager(_userRepository);
        }

        [HttpGet]
        [Route("getalluserslist")]
        public IActionResult GetAllUser(int userId)
        {
            List<UserListModel> model = new List<UserListModel>();
            try
            {
                model = _userService.GetAllUsers(userId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
            
        }


        [HttpGet]
        [Route("getUserbyId")]
        public IActionResult GetUserById(int Id)
        {
            UserModel model = new UserModel();
            try
            {
                model = _userService.GetUserById(Id);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("getallroles")]
        public IActionResult GetAllRoles(int UID)
        {
            List<UserAssignRole> model = new List<UserAssignRole>();
            try
            {
                model = _userService.GetAllUserRole(UID);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("InsertUser")]
        public async Task<IActionResult> Add(UserModel model, string userName)
        {
            try
            {
                if (model.Id > 0)
                {
                    UserModel _userModel = _userService.GetUserById(model.Id);
                    model.CreatedDate = _userModel.CreatedDate;
                    model.CreatedBy = _userModel.CreatedBy;
                    model.CivilExpiryDate = _userModel.CivilExpiryDate;
                    _userService.UpdateUser(model, userName);
                }
                else
                {
                    UserModel usrModel = _userService.checkDuplicate(model.CivilID, model.Email, model.Mobile);
                    if (usrModel == null)
                    {
                        _userService.Add(model, userName);
                        try
                        {
                         await   jsonRequestManager.ExpertInfo_UpsertExpert(model.CivilID);
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            await jsonRequestManager.LawyerInfo_UpsertLawyer(model.CivilID, model.Email);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else
                    {
                        return null;
                    }

                }
                _userService.AddUserInRole(model.AssignRoleIds, model.Id, userName);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
            
        }

        [HttpGet]
        [Route("UpdateUserFirstLogin")]
        public IActionResult UpdateFirstLogin(int UserId,string userName)
        {
            try
            {
                if (UserId > 0)
                {

                    _userService.UpdateUserFirstLogin(UserId, userName);
                }
                UserModel _userModel = _userService.GetUserById(UserId);
                return new JsonResult(new { data = _userModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
     
        }


        [HttpPost]
        [Route("InsertUserActivity")]
        public IActionResult AddUserActivity(UserActivityInfoLogModel model, string userName)
        {
            try
            {
                _userService.AddActivity(model, userName);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("getUserActivityLogbyId")]
        public IActionResult GetUserUserActivityLogById(int ID)
        {
            UserActivityInfoLogModel model = new UserActivityInfoLogModel();
            try
            {
                model = _userService.GetActivityById(ID);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }


        [HttpPost]
        [Route("updateUserStatus")]
        public IActionResult UpdateUserStatus(Service.Models.UserStatusModel model)
        {
            try
            {
                _userService.UpdateUserStatus(model);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("GenerateNumericOTP")]
        public IActionResult GenerateNumericOTP(string Email, int UserId,int OTPType)
        {
            try
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


                return new JsonResult(new { data = otpBuilder.ToString(), email = Email, otpexpiry = model.OTPExpiry, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("OTPverify")]
        public IActionResult OTPverify(Service.Models.OtpModel model)
        {
            return new JsonResult(new { data = _userService.VerifyOtp(model), status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getUserbyCivilId")]
        public IActionResult GetUserByCivilId(string civilId)
        {
            UserModel model = new UserModel();

            try
            {
                model = _userService.GetUserByCivilId(civilId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
    }
}
