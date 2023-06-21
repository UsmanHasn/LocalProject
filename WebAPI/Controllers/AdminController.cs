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

        [HttpGet]
        [Route("getallcalendar")]
        public IActionResult GetAllCalendar()
        {
            List<Calendar> model = new List<Calendar>();
            model = _AdminService.GetAllCalendar();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }


        [HttpGet]
        [Route("getallannouncement")]
        public IActionResult GetAllAccouncement()
        {
            List<Announcement> model = new List<Announcement>();
            model = _AdminService.GetAllAnnouncements();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }


        [HttpGet]
        [Route("getalluseractivitylog")]
        public IActionResult GetAllUseractivitylog()
        {
            List<UserActivityLog> model = new List<UserActivityLog>();
            model = _AdminService.GetActivityLogs();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

    }
}
