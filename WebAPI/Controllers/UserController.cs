using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.Models;
using System.Net;

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
    }
}
