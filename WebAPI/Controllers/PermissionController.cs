using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/permission/")]
    public class PermissionController : Controller
    {
        private readonly IPermissionService? permissionService;
        public PermissionController(IPermissionService _prmissionService)
        {
            permissionService = _prmissionService;
        }
        [HttpGet]
        [Route("GetAllPermission")]
        public IActionResult GetAllPermission()
        {
            List<PermissionModel> model = new List<PermissionModel>();
            model = permissionService.GetAllPermission();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

       
    }
}
