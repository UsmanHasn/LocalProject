using Domain.Entities.Lookups;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/common/")]
    public class CommonController : Controller
    {

        private readonly IMailService mailService;

        private readonly ILookupService _lookupService;
        public CommonController(ILookupService lookupService, IMailService mailService)
        {
            _lookupService = lookupService;
            this.mailService = mailService;
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

        [HttpGet]
        [Route("getnationalityvalues")]
        public IActionResult GetNationalityValues()
        {
            List<NationalityModel> model = new List<NationalityModel>();
            model = _lookupService.GetNationalityLookups().Select(x => new NationalityModel() { Id = x.Id, Name = x.Name }).ToList();
            //var json = new Dictionary<string, string>();
            //foreach (var item in model)
            //{
            //    json[item.Id + ""] = item.Name;
            //}
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("getCountry")]
        public IActionResult GetCountry()
        {
            List<CountryModel> model = new List<CountryModel>();
            model = _lookupService.GetCountryLookups().Select(x => new CountryModel() { Id = x.Id, Name = x.Name }).ToList();
            //var json = new Dictionary<string, string>();
            //foreach (var item in model)
            //{
            //    json[item.Id + ""] = item.Name;
            //}
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getAlerts")]
        public IActionResult GetAlerts(string userId)
        {
            List<AlertModel> model = new List<AlertModel>();
            model = _lookupService.GetAlerts(userId);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getAlertsById")]
        public IActionResult GetAlertsById(string alertId)
        {
            //AlertModel model = new AlertModel>();
            var model = _lookupService.GetAlertsById(alertId);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }



        [HttpPost("SendNotification")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();


            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [HttpPost]
        [Route("updatealert")]
        public IActionResult Add(AlertModel alertModel, string userName)
        {
            _lookupService.UpdateAlertById(alertModel);
            return new JsonResult(new { data = alertModel, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("GetCaseStatusLookup")]
        public IActionResult GetCaseStatusLookup()
        {
            List<LookupsModel> model = new List<LookupsModel>();
            model = _lookupService.GetCaseStatusLookup().Select(x => new LookupsModel() { Id = x.Id, NameAr = x.NameAr, NameEn = x.NameEn }).ToList();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

    }
}