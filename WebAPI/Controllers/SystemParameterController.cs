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
        [Route("getallsystemparameter")]
        public IActionResult GetAllSystemParmeter()
        {
            var systemParameterModel = _isystemParameterService.GetAllsystemParameter();
            return new JsonResult(new { data = systemParameterModel, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("insertsystemparameter")]
        public IActionResult Add(SystemParameterModel systemParameterModel, string userName)
        {
            if (systemParameterModel.systemSettingId > 0)
            {
                SystemParameterModel model = _isystemParameterService.GetsystemParameterById(systemParameterModel.systemSettingId);
                systemParameterModel.createdDate = model.createdDate;
                systemParameterModel.createdBy = model.createdBy;
                _isystemParameterService.UpdatesystemParameter(systemParameterModel, userName);
                return new JsonResult(new { data = systemParameterModel, status = HttpStatusCode.OK });
            }
            else
            {
                SystemParameterModel sysModel = _isystemParameterService.GetsystemParameterByName(systemParameterModel.keyName);
                if (sysModel == null)
                {
                    _isystemParameterService.Add(systemParameterModel, userName);
                    return new JsonResult(new { data = systemParameterModel, status = HttpStatusCode.OK });
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        [HttpDelete]
        [Route("deletesystemparameter")]
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
        [HttpGet]
        [Route("getsysParambyId")]
        public IActionResult GetUserById(int Id)
        {
            SystemParameterModel model = new SystemParameterModel();
            model = _isystemParameterService.GetsystemParameterById(Id);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
    }
}
