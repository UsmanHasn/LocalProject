using Domain.Entities.Lookups;
using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using Service.Interface;
using System.Net;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/common/")]
    public class CommonController : Controller
    {
        private readonly ILookupService _lookupService;
        public CommonController(ILookupService lookupService) 
        {
            _lookupService = lookupService;
        }
        [HttpGet]
        [Route("getlanguagevalues")]
        public IActionResult GetLanguageValues()
        {
            List<LanguageModel> model = new List<LanguageModel>();
            model = _lookupService.GetLanguageValues().Select(x => new LanguageModel() { Header = "" + x.Key + "", Values = x.ArabicValue }).ToList();
            var json = new Dictionary<string, string>();
            foreach (var item in model)
            {
                json[item.Header] = item.Values;
            }
            return new JsonResult(new { data = json, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getlanguagevaluesar")]
        public IActionResult GetLanguageValuesAr()
        {
            List<LanguageModel> model = new List<LanguageModel>();
            model = _lookupService.GetLanguageValues().Select(x => new LanguageModel() { Header = "" + x.Key + "", Values = x.EnglishValue }).ToList();
            var json = new Dictionary<string, string>();
            foreach (var item in model)
            {
                json[item.Header] = item.Values;
            }
            return new JsonResult(new { data = json, status = HttpStatusCode.OK });
        }
    }
}
