using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/assign/")]
    public class RoleAssignController : Controller
    {
        private readonly IPermissionService? _permissionService;
        public RoleAssignController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }
        [HttpGet]
        [Route("GetPages")]
        public IActionResult GetpagesforAssign(string roleId)
        {
            List<AssignRole> model = new List<AssignRole>();
            model = _permissionService.GetAssignRoles(roleId);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            var distinctModules = model.Select(x => x.pageModuleEn).Distinct();
            List<RolePermissionsModel> modelPermissions = distinctModules.Select(x =>
                                new RolePermissionsModel()
                                {
                                    items = model.Where(y => y.pageModuleEn == x)
                                    .Select(y => new AssignRole()
                                    {
                                        roleId = y.roleId,
                                        pageId = y.pageId,
                                        ReadPermission = y.ReadPermission,
                                        WritePermission = y.WritePermission,
                                        DeletePermission = y.DeletePermission,
                                        NameEn = y.NameEn,
                                        NameAr = y.NameAr,
                                        pageModuleEn = y.pageModuleEn,
                                        pageModuleAr = y.pageModuleAr,
                                        RolePermissionId = y.RolePermissionId
                                    }).ToList(),
                                    group = x,
                                }).ToList();

            return new JsonResult(new { data = modelPermissions, status = HttpStatusCode.OK });
        }


        [HttpPost]
        [Route("manageRolepermission")]
        public IActionResult Add(List<AssignRole> model, string userName)
        {
            _permissionService.DeleteRolePermission(model.First().roleId);
            foreach (AssignRole item in model)
            {
                if (item.RolePermissionId > 0)
                {
                    AssignRole _roleModel = _permissionService.GetPermissionById(item.RolePermissionId);
                    item.CreatedDate = _roleModel.CreatedDate;
                    item.CreatedBy = _roleModel.CreatedBy;
                    _permissionService.UpdatePermission(item, userName);
                }
                else
                {
                    _permissionService.Add(item, userName);
                }
            }

            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
    }
}
