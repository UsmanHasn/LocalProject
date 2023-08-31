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
        //added by Muhammad Usman
        [HttpGet]
        [Route("GetActionById")]
        public IActionResult GetActionById(int id)
        {
            ActionType action = new ActionType();
            action = _lookupService.GetActionById(id);
            return new JsonResult(new { data = action, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("GetReqStatusById")]
        public IActionResult GetReqStatusById(int id)
        {
            RequestStatus request = new RequestStatus();
            request = _lookupService.GetReqStatusById(id);
            return new JsonResult(new { data = request, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("GetAllActionlist")]
        public IActionResult GetAllActionlist()
        {
            List<ActionType> model = new List<ActionType>();
            model = _lookupService.GetAllActionlist();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("GetAllStatusList")]
        public IActionResult GetAllStatusList()
        {
            List<RequestStatus> model = new List<RequestStatus>();
            model = _lookupService.GetAllStatusList();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("InsUpdActType")]
        public void InsUpdActionLookup(ActionType model, string userName)
        {
            _lookupService.InsUpdActionLookup(model, userName);
            new JsonResult(new { data = true, status = HttpStatusCode.OK });
        }
        [HttpPost]
        [Route("DeleteAction")]
        public void DeleteAction(ActionType model, string userName)
        {
            _lookupService.DeleteAction(model, userName);
            new JsonResult(new { data = true, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("DeleteRequest")]
        public void DeleteRequest(RequestStatus model, string userName)
        {
            _lookupService.DeleteRequest(model, userName);
            new JsonResult(new { data = true, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("InsUpdReqStatus")]
        public void InsUpdStatusLookup(RequestStatus model, string userName)
        {
            _lookupService.InsUpdStatusLookup(model, userName);
            new JsonResult(new { data = true, status = HttpStatusCode.OK });
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


        [HttpGet]
        [Route("GetGovernatesLookupByCaseGroupId")]
        public IActionResult GetGovernatesLookupByCaseGroupId(long CaseGroupId)
        {
            List<GovernatesLookupModel> model = new List<GovernatesLookupModel>();
            model = _lookupService.GetGovernatesLookupByCaseGroupId(CaseGroupId);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("GetCaseGroupLookupByCaseGroupId")]
        public IActionResult GetCaseGroupLookupByCaseGroupId(long CaseGroupId)
        {
            List<CaseGroupLookupModel> model = new List<CaseGroupLookupModel>();
            model = _lookupService.GetCaseGroupLookupByCaseGroupId(CaseGroupId);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("GetLocationLookupByGovernatesId")]
        public IActionResult GetLocationLookupByGovernatesId(long GovernatesId)
        {
            List<LocationLookupModel> model = new List<LocationLookupModel>();
            model = _lookupService.GetLocationLookupByGovernatesId(GovernatesId);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("UpdateGovernatesLookupByCaseGroupId")]
        public IActionResult UpdateGovernatesLookupByCaseGroupId(GovernatesLookupModel governatesLookupModel, long CaseGroupId)
        {
            _lookupService.UpdateGovernatesLookupByCaseGroupId(governatesLookupModel);
            return new JsonResult(new { data = governatesLookupModel, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("UpdateCaseGroupLookup")]
        public IActionResult UpdateCaseGroupLookup(CaseGroupLookupModel caseGroupLookupModel, long CaseGroupId)
        {
            _lookupService.UpdateCaseGroupLookup(caseGroupLookupModel);
            return new JsonResult(new { data = caseGroupLookupModel, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("UpdateLocationLookup")]
        public IActionResult UpdateLocationLookup(LocationLookupModel locationLookupModel, long LocationId)
        {
            _lookupService.UpdateLocationLookup(locationLookupModel);
            return new JsonResult(new { data = locationLookupModel, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("AddGovernatesLookup")]
        public IActionResult AddGovernatesLookup(GovernatesLookupModel governatesLookupl)
        {
            _lookupService.AddGovernatesLookup(governatesLookupl);
            return new JsonResult(new { data = governatesLookupl, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("AddCaseGroupLookup")]
        public IActionResult AddCaseGroupLookup(CaseGroupLookupModel caseGroupLookup)
        {
            _lookupService.AddCaseGroupLookup(caseGroupLookup);
            return new JsonResult(new { data = caseGroupLookup, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("AddLocationLookup")]
        public IActionResult AddLocationLookup(LocationLookupModel locationLookup)
        {
            _lookupService.AddLocationLookup(locationLookup);
            return new JsonResult(new { data = locationLookup, status = HttpStatusCode.OK });
        }
    }
}