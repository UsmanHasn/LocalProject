using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.Models;
using System.Net;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/menu/")]
    public class MenuController : Controller
    {
        private readonly IMenuService? menuService;
        public MenuController(IMenuService _menuService)
        {
            menuService = _menuService;
        }
        [HttpGet]
        [Route("GetAllMenu")]
        public IActionResult GetAllMenu(int roleId)
        {
            List<MenuModel> model = new List<MenuModel>();
            model = menuService.GetAllMenu(roleId);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("GetAllMenuCompany")]
        public IActionResult GetAllMenuCompany()
        {
            List<MenuModel> model = new List<MenuModel>();
            model = menuService.GetAllMenuCompany();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
    }
}
