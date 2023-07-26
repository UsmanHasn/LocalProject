using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Concrete;
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
        public IActionResult GetAllMenu(int profileId, string profileType)
        {
            List<MenuModel> model = new List<MenuModel>();
            model = menuService.GetAllMenu(profileId, profileType);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("GetMenu")]
        public IActionResult GetMenu()
        {
            List<MenuModel> model = new List<MenuModel>();
            model = menuService.GetMenu();
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
        [HttpPost]
        [Route("addMenu")]
        public IActionResult AddMenu(MenuModel menuModel, string username)
        {
      

            if (menuModel.Id > 0)
            {
                //MenuModel mode = menuService.GetMenuById(menuModel.Id);
                //menuModel. = model.CreatedDate;
                //menuModel.CreatedBy = model.CreatedBy;
                menuService.UpdateMenu(menuModel.Id, menuModel, username);
            }
            else
            {
                menuService.Add(menuModel, username);
            }
            return new JsonResult(new { data = menuModel, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("getPages")]
        public IActionResult Getpages()
        {
            //List<PageModel> model = new List<PageModel>();
            var model = menuService.Getpages();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("getParentMenu")]
        public IActionResult GetParentMenu()
        {
            //List<PageModel> model = new List<PageModel>();
            var model = menuService.getParentMenu();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("getMenubyId")]
        public IActionResult GetPageById(int Id)
        {
            MenuModel model = new MenuModel();
            model = menuService.GetMenuById(Id);

            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpDelete]
        [Route("deleteMenu")]
        public IActionResult DeleteMenu(int id)
        {
            var menu = menuService.DeleteMenu(id);
            return new JsonResult(new { data = menu, status = HttpStatusCode.OK });
        }
    }
}