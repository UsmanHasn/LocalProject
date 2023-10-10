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
            try
            {
                var pagesModel = _IRolePermissionService.GetAllRolePermissions();
                return new JsonResult(new { data = pagesModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
          
        }
        [HttpPost]
        [Route("Insertrolepermission")]
        public IActionResult Addrolepermission(RolePermissionModel rolePermissionModel,string userName)
        {
            try
            {
                _IRolePermissionService.AddRolePermission(rolePermissionModel, userName);
                return new JsonResult(new { data = rolePermissionModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
            
        }
        [HttpDelete]
        [Route("Deleterolepermission")]
        public IActionResult Deleterolepermission(int id, string userName)
        {
            try
            {
                var rolePermissionModel = _IRolePermissionService.DeleteRolePermission(id, userName);
                return new JsonResult(new { data = rolePermissionModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
         
        }
        [HttpPut]
        [Route("Updaterolepermission")]
        public IActionResult Updaterolepermission(RolePermissionModel rolePermissionModel, string userName)
        {
            try
            {
                var rolePermission = _IRolePermissionService.UpdateRolePermission(rolePermissionModel, userName);
                return new JsonResult(new { data = rolePermission, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
    }
}
