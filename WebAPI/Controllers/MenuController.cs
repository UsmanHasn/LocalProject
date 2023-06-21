﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAllMenu()
        {
            List<MenuModel> model = new List<MenuModel>();
            model = menuService.GetAllMenu();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
    }
}