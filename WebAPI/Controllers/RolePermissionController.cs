using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;
using System.Web.Http.Results;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/rolepermission")]
    public class RolePermissionController : ControllerBase
    {
        private readonly IRolePermissionService _IRolePermissionService;

        public RolePermissionController(IRolePermissionService iRolePermissionService)
        {
            _IRolePermissionService = iRolePermissionService;
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var pagesModel = _IRolePermissionService.GetAllRolePermissions();
            return new JsonResult(new { data = pagesModel, status = HttpStatusCode.OK });
        }
        [HttpPost]
        [Route("Insertrolepermission")]
        public IActionResult Addrolepermission(RolePermissionModel rolePermissionModel,string userName)
        {
            _IRolePermissionService.AddRolePermission(rolePermissionModel, userName);
            return new JsonResult(new { data = rolePermissionModel, status = HttpStatusCode.OK });
        }
        [HttpDelete]
        [Route("Deleterolepermission")]
        public IActionResult Deleterolepermission(int id, string userName)
        {
         var rolePermissionModel =   _IRolePermissionService.DeleteRolePermission(id, userName);
            return new JsonResult(new { data = rolePermissionModel, status = HttpStatusCode.OK });
        }
        [HttpPut]
        [Route("Updaterolepermission")]
        public IActionResult Updaterolepermission(RolePermissionModel rolePermissionModel, string userName)
        {
            var rolePermission = _IRolePermissionService.UpdateRolePermission(rolePermissionModel, userName);
            return new JsonResult(new { data = rolePermission, status = HttpStatusCode.OK });
        }
    }
}
