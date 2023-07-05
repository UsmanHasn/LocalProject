using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
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
        public IActionResult GetAllRoles()
        {
            List<UserRole> model = new List<UserRole>();
            model = _userService.GetAllUserRole();
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
                _userService.Add(model, userName);
            }
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
    }
}
