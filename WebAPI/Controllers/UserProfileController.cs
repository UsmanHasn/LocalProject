using Microsoft.AspNetCore.Mvc;
 
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;

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


    }
}
