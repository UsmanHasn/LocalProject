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
        public IActionResult GetAllMenu(int profileId, string profileType, int profileDelegatedId)
        {
            List<MenuModel> model = new List<MenuModel>();
            try
            {
                model = menuService.GetAllMenu(profileId, profileType, profileDelegatedId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("GetMenuList")]
        public IActionResult GetMenuList(int pageSize, int pageNumber, string? SearchText)
        {
            try
            {
                var model = menuService.GetMenList(pageSize, pageNumber, SearchText);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("GetMenu")]
        public IActionResult GetMenu()
        {
            List<MenuModel> model = new List<MenuModel>();
            try
            {
                model = menuService.GetMenu();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
           
        }

        [HttpGet]
        [Route("GetAllMenuCompany")]
        public IActionResult GetAllMenuCompany()
        {
            List<MenuModel> model = new List<MenuModel>();
            try
            {
                model = menuService.GetAllMenuCompany();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpPost]
        [Route("addMenu")]
        public IActionResult AddMenu(MenuModel menuModel, string username)
        {
            try
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
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("getPages")]
        public IActionResult Getpages()
        {
            //List<PageModel> model = new List<PageModel>();
            try
            {
                var model = menuService.Getpages();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
            
        }

        [HttpGet]
        [Route("getParentMenu")]
        public IActionResult GetParentMenu()
        {
            //List<PageModel> model = new List<PageModel>();
            try
            {
                var model = menuService.getParentMenu();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("getMenubyId")]
        public IActionResult GetPageById(int Id)
        {
            MenuModel model = new MenuModel();
            try
            {
                model = menuService.GetMenuById(Id);

                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
            
        }

        [HttpDelete]
        [Route("deleteMenu")]
        public IActionResult DeleteMenu(int id)
        {
            try
            {
                var menu = menuService.DeleteMenu(id);
                return new JsonResult(new { data = menu, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
    }
}