using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;
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
            model = userProfileService.GetAllUserFile();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }


        [HttpGet]
        [Route("GetUserProfile")]
        public IActionResult GetDataByID(string CivilID)
        {
            Models.UsersModel? model = SjdcConstants.Users.FirstOrDefault(x => x.CivilID == CivilID);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }


    }
}
