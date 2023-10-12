using Domain.Entities;
using Domain.Entities.Lookups;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;
using WebAPI.Models;
using static Azure.Core.HttpHeader;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/common/")]
    public class CommonController : Controller
    {
        private readonly IMailService mailService;
        private ILogger<CommonController> logger;

        private readonly ILookupService _lookupService;
        public CommonController(ILookupService lookupService, IMailService mailService, ILogger<CommonController> _logger)
        {
            _lookupService = lookupService;
            this.mailService = mailService;
            this.logger = _logger;
        }
        [HttpGet]
        [Route("getlanguagevalues")]
        public IActionResult GetLanguageValues()
        {
            try
            {
                List<LanguageModel> model = new List<LanguageModel>();
                model = _lookupService.GetLanguageValues().Select(x => new LanguageModel() { Header = "" + x.Key + "", Values = x.ArabicValue }).ToList();
                var json = new Dictionary<string, string>();
                foreach (var item in model)
                {
                    json[item.Header] = item.Values;
                }
                logger.LogInformation("Language data found");
                return new JsonResult(new { data = json, status = HttpStatusCode.OK });

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Language values");
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }

        }
        [HttpGet]
        [Route("getlanguagevaluesar")]
        public IActionResult GetLanguageValuesAr()
        {
            try
            {
                List<LanguageModel> model = new List<LanguageModel>();
                model = _lookupService.GetLanguageValues().Select(x => new LanguageModel() { Header = "" + x.Key + "", Values = x.EnglishValue }).ToList();
                var json = new Dictionary<string, string>();
                foreach (var item in model)
                {
                    json[item.Header] = item.Values;
                }
                logger.LogInformation("Arabic Language data found");
                return new JsonResult(new { data = json, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Arabic Language values");
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }

        }

        [HttpGet]
        [Route("getnationalityvalues")]
        public IActionResult GetNationalityValues()
        {
            List<NationalityModel> model = new List<NationalityModel>();
            try
            {
                model = _lookupService.GetNationalityLookups().Select(x => new NationalityModel() { Id = x.Id, Name = x.Name, NameAr = x.NameAr }).ToList();
                //var json = new Dictionary<string, string>();
                //foreach (var item in model)
                //{
                //    json[item.Id + ""] = item.Name;
                //}
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("getCountry")]
        public IActionResult GetCountry()
        {
            List<CountryModel> model = new List<CountryModel>();
            try
            {
                model = _lookupService.GetCountryLookups().Select(x => new CountryModel() { Id = x.Id, Name = x.Name, NameAr = x.NameAr }).ToList();
                //var json = new Dictionary<string, string>();
                //foreach (var item in model)
                //{
                //    json[item.Id + ""] = item.Name;
                //}
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
           
        }
        //added by Muhammad Usman
        [HttpGet]
        [Route("GetActionById")]
        public IActionResult GetActionById(int id)
        {
            ActionType action = new ActionType();
            try
            {
                action = _lookupService.GetActionById(id);
                return new JsonResult(new { data = action, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
           
        }

        [HttpGet]
        [Route("GetReqStatusById")]
        public IActionResult GetReqStatusById(int id)
        {
            RequestStatus request = new RequestStatus();
            try
            {
                request = _lookupService.GetReqStatusById(id);
                return new JsonResult(new { data = request, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("GetAllActionlist")]
        public IActionResult GetAllActionlist()
        {
            List<ActionType> model = new List<ActionType>();
            try
            {
                model = _lookupService.GetAllActionlist();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
           
        }

        [HttpGet]
        [Route("GetAllStatusList")]
        public IActionResult GetAllStatusList()
        {
            List<RequestStatus> model = new List<RequestStatus>();
            try
            {
                model = _lookupService.GetAllStatusList();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("InsUpdActType")]
        public void InsUpdActionLookup(ActionType model, string userName)
        {
            try
            {
                _lookupService.InsUpdActionLookup(model, userName);
                new JsonResult(new { data = true, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }
            
        }
        [HttpPost]
        [Route("DeleteAction")]
        public void DeleteAction(ActionType model, string userName)
        {
            try
            {
                _lookupService.DeleteAction(model, userName);
                new JsonResult(new { data = true, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
          
        }

        [HttpPost]
        [Route("DeleteRequest")]
        public void DeleteRequest(RequestStatus model, string userName)
        {
            try
            {
                _lookupService.DeleteRequest(model, userName);
                new JsonResult(new { data = true, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
            
        }

        [HttpPost]
        [Route("InsUpdReqStatus")]
        public void InsUpdStatusLookup(RequestStatus model, string userName)
        {
            try
            {
                _lookupService.InsUpdStatusLookup(model, userName);
                new JsonResult(new { data = true, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }


        [HttpGet]
        [Route("getAlerts")]
        public IActionResult GetAlerts(string userId)
        {
            List<AlertModel> model = new List<AlertModel>();
            try
            {
                model = _lookupService.GetAlerts(userId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
               return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
           
        }
        [HttpGet]
        [Route("getAlertsById")]
        public IActionResult GetAlertsById(string alertId)
        {
            //AlertModel model = new AlertModel>();
            try
            {
                var model = _lookupService.GetAlertsById(alertId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

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
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }


        [HttpPost]
        [Route("updatealert")]
        public IActionResult Add(AlertModel alertModel, string userName)
        {
            try
            {
                _lookupService.UpdateAlertById(alertModel);
                return new JsonResult(new { data = alertModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
           
        }

        [HttpGet]
        [Route("GetCaseStatusLookup")]
        public IActionResult GetCaseStatusLookup()
        {
            List<LookupsModel> model = new List<LookupsModel>();
            try
            {
                model = _lookupService.GetCaseStatusLookup().Select(x => new LookupsModel() { Id = x.Id, NameAr = x.NameAr, NameEn = x.NameEn }).ToList();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
          
        }


        [HttpGet]
        [Route("GetGovernatesLookupByCaseGroupId")]
        public IActionResult GetGovernatesLookupByCaseGroupId(long CaseGroupId)
        {
            List<GovernatesLookupModel> model = new List<GovernatesLookupModel>();
            try
            {
                model = _lookupService.GetGovernatesLookupByCaseGroupId(CaseGroupId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
            
        }
        [HttpGet]
        [Route("GetCaseGroupLookupByCaseGroupId")]
        public IActionResult GetCaseGroupLookupByCaseGroupId(long CaseGroupId)
        {
            List<CaseGroupLookupModel> model = new List<CaseGroupLookupModel>();
            try
            {
                model = _lookupService.GetCaseGroupLookupByCaseGroupId(CaseGroupId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
            
        }

        [HttpGet]
        [Route("GetLocationLookupByGovernatesId")]
        public IActionResult GetLocationLookupByGovernatesId(long GovernatesId)
        {
            List<LocationLookupModel> model = new List<LocationLookupModel>();
            try
            {
                model = _lookupService.GetLocationLookupByGovernatesId(GovernatesId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("UpdateGovernatesLookupByCaseGroupId")]
        public IActionResult UpdateGovernatesLookupByCaseGroupId(GovernatesLookupModel governatesLookupModel, long CaseGroupId)
        {
            try
            {
                _lookupService.UpdateGovernatesLookupByCaseGroupId(governatesLookupModel);
                return new JsonResult(new { data = governatesLookupModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
           
        }

        [HttpPost]
        [Route("UpdateCaseGroupLookup")]
        public IActionResult UpdateCaseGroupLookup(CaseGroupLookupModel caseGroupLookupModel, long CaseGroupId)
        {
            try
            {
                _lookupService.UpdateCaseGroupLookup(caseGroupLookupModel);
                return new JsonResult(new { data = caseGroupLookupModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("UpdateLocationLookup")]
        public IActionResult UpdateLocationLookup(LocationLookupModel locationLookupModel, long LocationId)
        {
            try
            {
                _lookupService.UpdateLocationLookup(locationLookupModel);
                return new JsonResult(new { data = locationLookupModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
           
        }

        [HttpPost]
        [Route("AddGovernatesLookup")]
        public IActionResult AddGovernatesLookup(GovernatesLookupModel governatesLookupl, string userName)
        {
            try
            {
                if (governatesLookupl.GovernateId > 0)
                {
                    _lookupService.UpdateGovernatesLookupByGovernateId(governatesLookupl);
                }
                else
                {
                    _lookupService.AddGovernatesLookup(governatesLookupl, userName);
                }
                return new JsonResult(new { data = governatesLookupl, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
           
        }

        [HttpPost]
        [Route("AddCaseGroupLookup")]
        public IActionResult AddCaseGroupLookup(CaseGroupLookupModel caseGroupLookup)
        { 
            try
            {
                _lookupService.AddCaseGroupLookup(caseGroupLookup);
                return new JsonResult(new { data = caseGroupLookup, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("AddLocationLookup")]
        public IActionResult AddLocationLookup(LocationLookupModel locationLookup)
        {
            //string Message;
            //Message = _lookupService.AddLocationLookup(locationLookup);

            try
            {
                if (locationLookup.LocationId > 0)
                {
                    _lookupService.UpdateLocationLookup(locationLookup);
                }
                else
                {
                    _lookupService.AddLocationLookup(locationLookup);
                }
                return new JsonResult(new { data = locationLookup, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("AddCaseTypeLookup")]
        public IActionResult AddCaseTypeLookup(CaseTypesLookupModel caseTypeLookup)
        {
            try
            {
                _lookupService.AddCaseTypeLookup(caseTypeLookup);
                return new JsonResult(new { data = caseTypeLookup, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("AddCaseCategoryLookup")]
        public IActionResult AddCaseCategoryLookup(CaseCategoryLookupModel caseCategoryLookup, string userName)
        {
            try
            {
                if (caseCategoryLookup.CaseCategoryId > 0)
                {
                    _lookupService.UpdateCaseCategoryLookup(caseCategoryLookup, userName);
                }
                else
                {
                    _lookupService.AddCaseCategoryLookup(caseCategoryLookup, userName);
                }

                return new JsonResult(new { data = caseCategoryLookup, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
           
        }

        [HttpPost]
        [Route("AddCaseSubCategoryLookup")]
        public IActionResult AddCaseSubCategoryLookup(CaseSubCategoryLookupModel caseSubCategoryLookup, string userName)
        {
            try
            {
                if (caseSubCategoryLookup.CaseSubCategoryId > 0)
                {
                    _lookupService.UpdateCaseSubCategoryLookup(caseSubCategoryLookup, userName);
                }
                else
                {
                    _lookupService.AddCaseSubCategoryLookup(caseSubCategoryLookup, userName);
                }

                return new JsonResult(new { data = caseSubCategoryLookup, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
         
        }

        //[HttpGet]
        //[Route("GetcaseTypesLookup")]
        //public IActionResult GetcaseTypesLookup()
        //{
        //    List<CaseTypesLookupModel> model = new List<CaseTypesLookupModel>();
        //    model = _lookupService.caseTypesLookup().ToList();
        //    //var json = new Dictionary<string, string>();
        //    //foreach (var item in model)
        //    //{
        //    //    json[item.Id + ""] = item.Name;
        //    //}
        //    return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        //}

        [HttpGet]
        [Route("GetcaseTypesLookup")]
        public IActionResult GetcaseTypesLookup(int CaseGroupId)
        {
            List<CaseTypesLookupModel> model = new List<CaseTypesLookupModel>();
            try
            {
                model = _lookupService.caseTypesLookup(CaseGroupId).Select(x => new CaseTypesLookupModel() { CaseTypeId = x.CaseTypeId, Code = x.Code, NameEn = x.NameEn, NameAr = x.NameAr, CourtTypeId = x.CourtTypeId, IsActive = x.IsActive, CreatedBy = x.CreatedBy, CreatedDate = x.CreatedDate, LastModifiedBy = x.LastModifiedBy, LastModifiedDate = x.LastModifiedDate, Deleted = x.Deleted, CaseGroupId = x.CaseGroupId }).ToList();
                //var json = new Dictionary<string, string>();
                //foreach (var item in model)
                //{
                //    json[item.Id + ""] = item.Name;
                //}
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("GetcaseGroup")]
        public IActionResult GetcaseGroup()
        {
            List<CaseGroupLookupModel> model = new List<CaseGroupLookupModel>();
            try
            {
                model = _lookupService.BindCaseGroup();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
           
        }
        [HttpGet]
        [Route("GetgovernateLookup")]
        public IActionResult GetgovernateLookup()
        {
            List<GovernatesLookupModel> model = new List<GovernatesLookupModel>();
            try
            {
                model = _lookupService.BindGovernateLookup();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("GetAllLocationLookup")]
        public IActionResult GetAllLocationLookup()
        {
            List<LocationLookupModel> model = new List<LocationLookupModel>();
            try
            {
                model = _lookupService.GelAllLocationLookup();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
           
        }
        [HttpGet]
        [Route("GetLocationLookupById")]
        public IActionResult GetLocationLookupById(int locationId)
        {
            LocationLookupModel model = new LocationLookupModel();
            try
            {
                model = _lookupService.GelLocationLookupById(locationId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
            
        }


        [HttpGet]
        [Route("GetAllGovernate")]
        public IActionResult GetAllGovernate()
        {
            List<GovernatesLookupModel> model = new List<GovernatesLookupModel>();
            try
            {
                model = _lookupService.GetAllGovernateLookup();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("GetGovernateLookupById")]
        public IActionResult GetGovernateLookupById(int governateId)
        {
            GovernatesLookupModel model = new GovernatesLookupModel();
            try
            {
                model = _lookupService.GetGovernateLookupById(governateId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("GetcaseCategoryLookup")]
        public IActionResult GetcaseCategoryLookup(int CaseTypeId)
        {
            List<CaseCategoryLookupModel> model = new List<CaseCategoryLookupModel>();
            try
            {
                model = _lookupService.GetcaseCategoryLookup(CaseTypeId).Select(x => new CaseCategoryLookupModel() { CaseCategoryId = x.CaseCategoryId, CaseTypeId = x.CaseTypeId, Code = x.Code, NameEn = x.NameEn, NameAr = x.NameAr, IsActive = x.IsActive, CreatedBy = x.CreatedBy, CreatedDate = x.CreatedDate, LastModifiedBy = x.LastModifiedBy, LastModifiedDate = x.LastModifiedDate, Deleted = x.Deleted }).ToList();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("GetcaseSubCategoryLookupById")]
        public IActionResult GetcaseSubCategoryLookupById(int caseSubCategoryId)
        {
            CaseSubCategoryLookupModel model = new CaseSubCategoryLookupModel();
            try
            {
                model = _lookupService.GetcaseSubCategoryLookupById(caseSubCategoryId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("GetcaseSubCategoryLookup")]
        public IActionResult GetcaseSubCategoryLookup(int CaseCategoryId)
        {
            List<CaseSubCategoryLookupModel> model = new List<CaseSubCategoryLookupModel>();
            try
            {
                model = _lookupService.GetcaseSubCategoryLookup(CaseCategoryId).ToList();//.Select(x => new CaseSubCategoryLookupModel() { CaseSubCategoryId = x.CaseSubCategoryId, NameEn = x.NameEn, NameAr = x.NameAr, CaseCategoryId = x.CaseCategoryId }).ToList();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
           
        }


        [HttpGet]
        [Route("_GetcaseSubCategoryLookup")]
        public IActionResult _GetcaseSubCategoryLookup()
        {
            List<CaseSubCategoryLookupModel> model = new List<CaseSubCategoryLookupModel>();
            try
            {
                model = _lookupService.GetcaseSubCategoryLookup().Select(x => new CaseSubCategoryLookupModel() { CaseSubCategoryId = x.CaseSubCategoryId, NameEn = x.NameEn, NameAr = x.NameAr, CaseCategoryId = x.CaseCategoryId }).ToList();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }
            
        }

        [HttpPost]
        [Route("UpdateCaseTypeLookup")]
        public IActionResult UpdateCaseTypeLookup(CaseTypesLookupModel caseTypesLookupModel, long CaseTypeId)
        {
            try
            {
                _lookupService.UpdateCaseTypeLookup(caseTypesLookupModel);
                return new JsonResult(new { data = caseTypesLookupModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("UpdateCaseCategoryLookup")]
        public IActionResult UpdateCaseCategoryLookup(CaseCategoryLookupModel caseCategoryLookupModel, string userName)
        {
            try
            {
                _lookupService.UpdateCaseCategoryLookup(caseCategoryLookupModel, userName);
                return new JsonResult(new { data = caseCategoryLookupModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
          
        }


        [HttpPost]
        [Route("UpdateCaseSubCategoryLookup")]
        public IActionResult UpdateCaseSubCategoryLookup(CaseSubCategoryLookupModel caseSubCategoryLookupModel, string userName)
        {
            try
            {
                _lookupService.UpdateCaseSubCategoryLookup(caseSubCategoryLookupModel, userName);
                return new JsonResult(new { data = caseSubCategoryLookupModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpPost]
        [Route("DeleteCaseTypeLookup")]
        public IActionResult DeleteCaseTypeLookup(CaseTypesLookupModelDelete caseTypesLookupModelDelete, long CaseTypeId)
        {
            try
            {
                _lookupService.DeleteCaseTypeLookup(caseTypesLookupModelDelete);
                return new JsonResult(new { data = caseTypesLookupModelDelete, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpPost]
        [Route("DeleteCaseCategoryLookup")]
        public IActionResult DeleteCaseCategoryLookup(int id)
        {
            try
            {
                _lookupService.DeleteCaseCategoryLookup(id);
                return new JsonResult(new { data = id, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpPost]
        [Route("DeleteCaseSubCategoryLookupModel")]
        public IActionResult DeleteCaseSubCategoryLookupModel(CaseSubCategoryLookupModelDelete caseSubCategoryLookupModelDelete, long CaseSubCategoryId)
        {
            try
            {
                _lookupService.DeleteCaseSubCategoryLookupModel(caseSubCategoryLookupModelDelete);
                return new JsonResult(new { data = caseSubCategoryLookupModelDelete, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
           
        }

        [HttpGet]
        [Route("GetAllCaseCategory")]
        public IActionResult GetAllCaseCategory()
        {
            List<CaseCategoryLookupModel> model = new List<CaseCategoryLookupModel>();
            try
            {
                model = _lookupService.GetAllCaseCategory();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("GetCaseCategoryById")]
        public IActionResult GetCaseCategoryById(int caseCategoryId)
        {
            CaseCategoryLookupModel model = new CaseCategoryLookupModel();
            try
            {
                model = _lookupService.GetCaseCategoryById(caseCategoryId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }


        [HttpPost]
        [Route("AddLanguageLookup")]
        public IActionResult AddLanguageLookup(LanguageLookupModel languageLookupModel, string userName)
        {

            try
            {
                if (languageLookupModel.LanguageId > 0)
                {
                    _lookupService.UpdateLanguageLookup(languageLookupModel, userName);
                    return new JsonResult(new { data = languageLookupModel, status = HttpStatusCode.OK });
                }
                else
                {
                    LanguageLookupModel sysModel = _lookupService.GetCode(languageLookupModel.Key);
                    if (sysModel == null)
                    {
                        _lookupService.AddLanguageLookup(languageLookupModel, userName);
                        return new JsonResult(new { data = languageLookupModel, status = HttpStatusCode.OK });
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

        //[HttpGet]
        //[Route("GetLanguageLookup")]
        //public IActionResult GetLanguageLookup()
        //{
        //    List<LanguageLookupModel> model = new List<LanguageLookupModel>();
        //    model = _lookupService.GetLanguageLookup();
        //    return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        //}
        [HttpGet]
        [Route("GetLanguageLookup")]
        public IActionResult GetLanguageLookup(int pageSize, int pageNumber)
        {
            PaginatedLanguageLookupModel model = new PaginatedLanguageLookupModel();
            try
            {
                model = _lookupService.GetLanguageLookup(pageSize, pageNumber);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
          
        }
        [HttpGet]
        [Route("GetLanguageLookupById")]
        public IActionResult GetLanguageLookupById(int languageLookupId)
        {
            LanguageLookupModel model = new LanguageLookupModel();
            try
            {
                model = _lookupService.GetLanguageLookupById(languageLookupId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("GetPartyTypes")]
        public IActionResult GetPartyTypes(int CaseTypeId)
        {
            List<LookupsModel> model = new List<LookupsModel>();
            try
            {
                model = _lookupService.GetPartyTypes(CaseTypeId).ToList();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("DeleteCaseGroup")]
        public void DeleteCaseGroup(int id)
        {
            try
            {
                _lookupService.DeleteCaseGroupLookup(id);
                new JsonResult(new { data = true, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                 new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("DeleteGovernatesLookup")]
        public IActionResult DeleteGovernatesLookup(int id)
        {
            try
            {
                _lookupService.DeleteGovernatesLookup(id);
                return new JsonResult(new { data = true, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
             return   new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("DeleteLocationLookup")]
        public IActionResult DeleteLocationLookup(int id)
        {
            try
            {
                _lookupService.DeleteLocationLookup(id);
                return new JsonResult(new { data = true, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
           
        }

        [HttpPost]
        [Route("UpdateCaseGroupStatus")]
        public void UpdateCaseGroupStatus(int caseGroupId, string status)
        {
            try
            {
                _lookupService.UpdateStatus(caseGroupId, status);
                new JsonResult(new { data = true, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                 new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
           
        }
    }
}