using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
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
        [Route("getallnotification")]
        public IActionResult GetAllNotification()
        {
            List<Notification> model = new List<Notification>();
            model = _AdminService.GetAllNotifications();
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

        [HttpGet]
        [Route("getalllawyers")]
        public IActionResult GetAllLawyers()
        {
            List<LawyersModels> model = new List<LawyersModels>();
            model = _AdminService.GetAllLawyers();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getallservices")]
        public IActionResult GetAlServices(int categoryId, int subCategoryId)
        {
            List<ServicesModel> model = new List<ServicesModel>();
            model = _AdminService.GetAllServices(categoryId, subCategoryId);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }




        [HttpPost]
        [Route("insertalert")]
        public IActionResult Add(AlertModel alertModel,string userName)
        {
            _AdminService.Add(alertModel, userName);
            return new JsonResult(new {data = alertModel, status = HttpStatusCode.OK});
        }
        [HttpGet]
        [Route("getusers")]
        public IActionResult Getusers()
        {
            //List<UserModel> model = new List<UserModel>();
            var model = _AdminService.GetUsers();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
          //  List<UserModel> model = new List<UserModel>();
           var model = _AdminService.GetAllAlerts();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getAlertbyId")]
        public IActionResult GetAlertById(int Id)
        {
            AlertModel model = new AlertModel();
            model = _AdminService.GetAlertById(Id);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
    }
}
