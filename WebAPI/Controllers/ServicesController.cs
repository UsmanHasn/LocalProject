using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/Services/")]
    public class ServicesController : Controller
    {
        private readonly ILookupService _lookService;

        public ServicesController(ILookupService lookService)
        {
            _lookService = lookService;
        }

        [HttpGet]
        [Route("GetServicesSubCategory")]
        public IActionResult GetServicesSubCategory()
        {
            List<ServicesSubCategoryModel> model = new List<ServicesSubCategoryModel>();
            model = _lookService.GetServicesSubCategory();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }


         
    }
}
