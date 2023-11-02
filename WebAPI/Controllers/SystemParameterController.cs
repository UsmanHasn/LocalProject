using MailKit.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Drawing.Printing;
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
        public IActionResult GetAllSystemParmeter(int pageSize, int pageNumber, string? SearchText)
        {
            try
            {
                var systemParameterModel = _isystemParameterService.GetAllsystemParameter(pageSize, pageNumber, SearchText);
                return new JsonResult(new { data = systemParameterModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
               return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }

        }

        [HttpPost]
        [Route("insertsystemparameter")]
        public IActionResult Add(SystemParameterModel systemParameterModel, string userName)
        {
            try
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
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpDelete]
        [Route("deletesystemparameter")]
        public IActionResult Deletesystemparameter(int id, string userName)
        {
            try
            {
                if (id != 0)
                {
                    var systemParameterModel = _isystemParameterService.DeletesystemParameter(id, userName);
                    return new JsonResult(new { data = systemParameterModel, status = HttpStatusCode.OK });
                }
                else
                {
                    return new JsonResult(new { status = HttpStatusCode.OK });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
            

        }
        [HttpPut]
        [Route("Updatesystemparameter")]
        public IActionResult Updatesystemparameter(SystemParameterModel systemParameterModel, string userName)
        {
            try
            {
                var systemparameter = _isystemParameterService.UpdatesystemParameter(systemParameterModel, userName);
                return new JsonResult(new { data = systemparameter, status = HttpStatusCode.OK });

            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("getsysParambyId")]
        public IActionResult GetUserById(int Id)
        {
            SystemParameterModel model = new SystemParameterModel();
            try
            {
                model = _isystemParameterService.GetsystemParameterById(Id);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
    }
}
