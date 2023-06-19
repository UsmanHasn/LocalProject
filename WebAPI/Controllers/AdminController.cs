using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.Models;
using System.Net;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/admin/")]
    public class AdminController : Controller
    {
        private readonly IAdminService? _AdminService;
        
        public AdminController(IAdminService adminService)
        {
            _AdminService = adminService;
        }

        [HttpGet]
        [Route("getallcourt")]
        public IActionResult  GetAllCourt()
        {
            List<CourtList> model = new List<CourtList>();
            model = _AdminService.GetAllCourts();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getallcases")]
        public IActionResult GetAllCases()
        {
            List<CaseListModel> model = new List<CaseListModel>();
            model = _AdminService.GetAllCases();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
    }
}
