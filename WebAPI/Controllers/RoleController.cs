using Microsoft.AspNetCore.Mvc;

using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;
using Data.Interface;
using Data.Concrete;
using Domain.Entities;

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

        [HttpGet]
        [Route("getRolebyId")]
        public IActionResult GetUserById(int Id)
        {
            RoleModel model = new RoleModel();
            model = roleService.GetRoleById(Id);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("manageRole")]
        public IActionResult Add(RoleModel model, string userName)
        {
            if (model.Id > 0)
            {
                RoleModel _roleModel = roleService.GetRoleById(model.Id);
                model.CreatedDate = _roleModel.CreatedDate;
                model.CreatedBy = _roleModel.CreatedBy;
                roleService.UpdateRole(model, userName);
            }
            else
            {
                roleService.Add(model, userName);
            }
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("deleterole")]
        public IActionResult Delete(int roleId, string userName)
        {
            RoleModel _roleModel = roleService.GetRoleById(roleId);
            _roleModel.CreatedDate = _roleModel.CreatedDate;
            _roleModel.CreatedBy = _roleModel.CreatedBy;
            roleService.DeleteRole(_roleModel, userName);
            
            return new JsonResult(new { data = _roleModel, status = HttpStatusCode.OK });
        }
    }
}