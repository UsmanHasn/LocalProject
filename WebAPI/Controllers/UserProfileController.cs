using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using WebAPI.Helper;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/UserProfileController/")]
    public class UserProfileController : Controller
    {
        private readonly IUserProfileService? userProfileService;
        public UserProfileController(IUserProfileService _userProfileService)
        {
            userProfileService = _userProfileService;
        }



        [HttpGet]
        [Route("GetAllUserProfile")]
        public IActionResult GetAllData()
        {
            List<UserProfileModel> model = new List<UserProfileModel>();
            try
            {
                model = userProfileService.GetAllUserFile();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }


        [HttpGet]
        [Route("GetSwitchProfiles")]
        public IActionResult GetSwitchProfiles(int UserId)
        {
            try
            {
                var model = userProfileService.GetSwitchProfiles(UserId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
       



    }
}
