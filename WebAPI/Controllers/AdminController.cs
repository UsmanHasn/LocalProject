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
        private readonly IAdminService? courtList;
        
        public AdminController(IAdminService _courtList)
        {
            courtList = _courtList;
        }

        [HttpGet]
        [Route("getallcourt")]
        public IActionResult  GetAllCourt()
        {
            List<CourtList> model = new List<CourtList>();
            model = courtList.GetAllCourts();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
       
    }
}
