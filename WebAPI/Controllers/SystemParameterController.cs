using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/systemparameter")]
    public class SystemParameterController : ControllerBase
    {
        private readonly ISystemParameterService _isystemParameterService;

        public SystemParameterController(ISystemParameterService systemParameterService)
        {
            _isystemParameterService = systemParameterService;
        }
        [HttpGet]
        [Route("InsertsystemParameter")]
        public IActionResult GetAllSystemParmeter()
        {
            var systemParameterModel = _isystemParameterService.GetAllsystemParameter();
            return new JsonResult(new { data = systemParameterModel, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("InsertsystemParameter")]
        public IActionResult Add(SystemParameterModel systemParameterModel, string userName)
        {
            _isystemParameterService.Add(systemParameterModel, userName);
            return new JsonResult(new { data = systemParameterModel, status = HttpStatusCode.OK });
        }
        [HttpDelete]
        [Route("Deletesystemparameter")]
        public IActionResult Deletesystemparameter(int id, string userName)
        {
            var systemParameterModel = _isystemParameterService.DeletesystemParameter(id, userName);
            return new JsonResult(new { data = systemParameterModel, status = HttpStatusCode.OK });
        }
        [HttpPut]
        [Route("Updatesystemparameter")]
        public IActionResult Updatesystemparameter(SystemParameterModel systemParameterModel, string userName)
        {
            var systemparameter = _isystemParameterService.UpdatesystemParameter(systemParameterModel, userName);
            return new JsonResult(new { data = systemparameter, status = HttpStatusCode.OK });

        }
    }
}
