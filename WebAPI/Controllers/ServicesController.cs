using Data.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/Services/")]
    public class ServicesController : Controller
    {
        private readonly ILookupService _lookService;
        private readonly IService _service;

        public ServicesController(ILookupService lookService, IService service)
        {
            _service = service;
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

        [HttpGet]
        [Route("BindServicesSubCategory")]
        public IActionResult BindServicesSubCategory()
        {
            List<ServicesSubCategoryModel> model = new List<ServicesSubCategoryModel>();
            model = _service.BindSubCategory();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("insertservice")]
        public IActionResult Add(ServicesModel services, string userName)
        {
            if (services.ServiceId > 0)
            {
                _service.UpdateService(services.ServiceId,services, userName);
            }
            else
            {
                _service.AddService(services, userName);
            }
            return new JsonResult(new { data = services, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("GetAllService")]
        public IActionResult GetAllServices()
        {
            List<ServicesModel> model = new List<ServicesModel>();
            model = _service.GetAllService();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("GetAllServiceById")]
        public IActionResult GetAllServicesById(int id)
        {
           var model = _service.GetDataById(id);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("DeleteService")]
        public void DeleteService(int id)
        {
            _service.DeleteService(id);
            new JsonResult(new { data = true, status = HttpStatusCode.OK });
        }

        [HttpDelete]
        [Route("DeleteService")]
        public IActionResult DeleteService(int id, string userName)
        {
            if (id != 0)
            {
                var systemParameterModel = _service.DeleteServiceItem(id, userName);
                return new JsonResult(new { data = systemParameterModel, status = HttpStatusCode.OK });
            }
            else
            {
                return new JsonResult(new { status = HttpStatusCode.OK });
            }

        }
    }
}

