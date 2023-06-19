using Microsoft.AspNetCore.Mvc;

using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;
using Data.Interface;
using Data.Concrete;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/role/")]
    public class RoleController : Controller
    {

        private readonly IRoleService? roleService;

        public RoleController(IRoleService _roleService)
        {
            roleService = _roleService;

        }
        [HttpGet]
        [Route("GetAllRole")]
        public IActionResult GetAllRole()
        {
            List<RoleModel> model = new List<RoleModel>();
            model = roleService.GetAllRole();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

    }
}