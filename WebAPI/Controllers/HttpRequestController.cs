﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.Data.SqlClient;
using Service.Concrete;
using Service.Models;
using System.Net;
using WebAPI.Helper;
using WebAPI.Models;
using CaseDocumentModel = WebAPI.Models.CaseDocumentModel;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/httprequest/")]
    public class HttpRequestController : BaseController
    {
        #region Case Requests
        [HttpGet]
        [Route("getcases")]
        public async Task<IActionResult> GetCases(string civilNo)
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            //var requestBody = new MyRequestModel { Property1 = "value1", Property2 = "value2" };
            var parameters = new Dictionary<string, string>
            {
                { "civilNo", civilNo}
            };
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel<CasesModel>, HttpResponseModel<CasesModel>>(base.acoApiUrl + "case/GetCases", HttpMethod.Get, null, parameters);
            var responseJCMS = await httpClientHelper.MakeHttpRequest<HttpResponseModel<CasesModel>, HttpResponseModel<CasesModel>>(base.jcmsApiUrl + "case/GetCases", HttpMethod.Get, null, parameters);
            var response = new List<CasesModel>();
            if (responseACO != null && responseACO.data != null)
            {
                response.AddRange(responseACO.data);
            }
            if (responseJCMS != null && responseJCMS.data != null)
            {
                response.AddRange(responseJCMS.data);
            }
            response.OrderBy(x => x.CaseFiledDate);
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getcasebyid")]
        public async Task<IActionResult> GetCasesById(string caseId)
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            //var requestBody = new MyRequestModel { Property1 = "value1", Property2 = "value2" };
            var parameters = new Dictionary<string, string>
            {
                { "caseId", caseId}
            };
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel<CasesModel>, HttpResponseModel<CasesModel>>(base.acoApiUrl + "case/GetCaseById?caseId=" + caseId, HttpMethod.Get, null, null);
            var responseJCMS = await httpClientHelper.MakeHttpRequest<HttpResponseModel<CasesModel>, HttpResponseModel<CasesModel>>(base.jcmsApiUrl + "case/GetCaseById?caseId=" + caseId, HttpMethod.Get, null, null);
            var response = new CasesModel();
            if (responseACO != null && responseACO.data != null && responseACO.data.Count() > 0)
            {
                response = responseACO.data.FirstOrDefault();
            }
            else if (responseJCMS != null)
            {
                response = responseJCMS.data.FirstOrDefault();
            }
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getsubjectbycaseid")]
        public async Task<IActionResult> GetSubjectsByCaseId(string caseId)
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            //var requestBody = new MyRequestModel { Property1 = "value1", Property2 = "value2" };
            var parameters = new Dictionary<string, string>
            {
                { "caseId", caseId}
            };
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel<CaseSubjectsModel>, HttpResponseModel<CaseSubjectsModel>>(base.acoApiUrl + "case/GetSubjectByCaseId?caseId=" + caseId, HttpMethod.Get, null, null);
            var responseJCMS = await httpClientHelper.MakeHttpRequest<HttpResponseModel<CaseSubjectsModel>, HttpResponseModel<CaseSubjectsModel>>(base.jcmsApiUrl + "case/GetSubjectByCaseId?caseId=" + caseId, HttpMethod.Get, null, null);
            var response = new List<CaseSubjectsModel>();
            response.AddRange(responseACO.data);
            response.AddRange(responseJCMS.data);
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getpartiesbycaseid")]
        public async Task<IActionResult> GetPartiesByCaseId(string caseId)
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            //var requestBody = new MyRequestModel { Property1 = "value1", Property2 = "value2" };
            var parameters = new Dictionary<string, string>
            {
                { "caseId", caseId}
            };
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel<CasePartiesModel>, HttpResponseModel<CasePartiesModel>>(base.acoApiUrl + "case/GetPartiesByCaseId?caseId=" + caseId, HttpMethod.Get, null, null);
            var responseJCMS = await httpClientHelper.MakeHttpRequest<HttpResponseModel<CasePartiesModel>, HttpResponseModel<CasePartiesModel>>(base.jcmsApiUrl + "case/GetPartiesByCaseId?caseId=" + caseId, HttpMethod.Get, null, null);
            var response = new List<CasePartiesModel>();
            response.AddRange(responseACO.data);
            response.AddRange(responseJCMS.data);
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getannouncementsbycaseid")]
        public async Task<IActionResult> GetAnnouncementByCaseId(string caseId)
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            //var requestBody = new MyRequestModel { Property1 = "value1", Property2 = "value2" };
            var parameters = new Dictionary<string, string>
            {
                { "caseId", caseId}
            };
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel<CaseAnnouncementModel>, HttpResponseModel<CaseAnnouncementModel>>(base.acoApiUrl + "case/GetAnnouncementsByCaseId?caseId=" + caseId, HttpMethod.Get, null, null);
            var responseJCMS = await httpClientHelper.MakeHttpRequest<HttpResponseModel<CaseAnnouncementModel>, HttpResponseModel<CaseAnnouncementModel>>(base.jcmsApiUrl + "case/GetAnnouncementsByCaseId?caseId=" + caseId, HttpMethod.Get, null, null);
            var response = new List<CaseAnnouncementModel>();
            response.AddRange(responseACO.data);
            response.AddRange(responseJCMS.data);
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("gethearingsbycaseid")]
        public async Task<IActionResult> GetHearingsByCaseId(string caseId)
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            //var requestBody = new MyRequestModel { Property1 = "value1", Property2 = "value2" };
            var parameters = new Dictionary<string, string>
            {
                { "caseId", caseId}
            };
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel<CaseHearingModel>, HttpResponseModel<CaseHearingModel>>(base.acoApiUrl + "case/GetHearingsByCaseId?caseId=" + caseId, HttpMethod.Get, null, null);
            var responseJCMS = await httpClientHelper.MakeHttpRequest<HttpResponseModel<CaseHearingModel>, HttpResponseModel<CaseHearingModel>>(base.jcmsApiUrl + "case/GetHearingsByCaseId?caseId=" + caseId, HttpMethod.Get, null, null);
            var response = new List<CaseHearingModel>();
            response.AddRange(responseACO.data);
            response.AddRange(responseJCMS.data);
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getdocumentsbycaseid")]
        public async Task<IActionResult> GetDocumentsByCaseId(string caseId)
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            //var requestBody = new MyRequestModel { Property1 = "value1", Property2 = "value2" };
            var parameters = new Dictionary<string, string>
            {
                { "caseId", caseId}
            };
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel<CaseDocumentModel>, HttpResponseModel<CaseDocumentModel>>(base.acoApiUrl + "case/GetDocumentsByCaseId?caseId=" + caseId, HttpMethod.Get, null, null);
            var responseJCMS = await httpClientHelper.MakeHttpRequest<HttpResponseModel<CaseDocumentModel>, HttpResponseModel<CaseDocumentModel>>(base.jcmsApiUrl + "case/GetDocumentsByCaseId?caseId=" + caseId, HttpMethod.Get, null, null);
            var response = new List<CaseDocumentModel>();
            response.AddRange(responseACO.data);
            response.AddRange(responseJCMS.data);
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("getCasesType")]
        public async Task<IActionResult> GetCaseType()
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel<CaseType>, HttpResponseModel<CaseType>>(base.acoApiUrl + "case/GetCasesType", HttpMethod.Get, null, null);
            var response = new List<CaseType>();
            if (responseACO != null && responseACO.data != null)
            {
                response.AddRange(responseACO.data);
            }
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getCasesStatus")]
        public async Task<IActionResult> GetCasesStatus()
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel<CaseStatus>, HttpResponseModel<CaseStatus>>(base.acoApiUrl + "case/GetCasesStatus", HttpMethod.Get, null, null);
            var response = new List<CaseStatus>();
            if (responseACO != null && responseACO.data != null)
            {
                response.AddRange(responseACO.data);
            }
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getCaseFilter")]
        public async Task<IActionResult> GetCaseFilter(string caseType, string caseStatus)
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var parameters = new Dictionary<string, string>
            {
                { "caseType", caseType},
                { "caseStatus", caseStatus}
            };
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel<CasesModel>, HttpResponseModel<CasesModel>>(base.acoApiUrl + "case/GetCaseFilter?caseType=" + caseType + "&caseStatus=" + caseStatus, HttpMethod.Get, null, null);
            var response = new List<CasesModel>();
            response.AddRange(responseACO.data);
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }
        #endregion
        #region Lookup Requests
        [HttpGet]
        [Route("GetEntity")]
        public async Task<IActionResult> GetEntity(string ApiType)
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel<LookupModel>, HttpResponseModel<LookupModel>>(base.acoApiUrl + "lookup/GetEntity", HttpMethod.Get, null, null);
            var responseJCMS = await httpClientHelper.MakeHttpRequest<HttpResponseModel<LookupModel>, HttpResponseModel<LookupModel>>(base.jcmsApiUrl + "lookup/GetEntity", HttpMethod.Get, null, null);
            var response = new List<LookupModel>();
            if (ApiType == "A")
            {
                if (responseACO != null && responseACO.data != null)
                {
                    response.AddRange(responseACO.data);
                }
            }
            else
            {
                if (responseJCMS != null && responseJCMS.data != null)
                {
                    response.AddRange(responseJCMS.data);
                }
            }
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getcourttype")]
        public async Task<IActionResult> GetCourtType()
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel<LookupModel>, HttpResponseModel<LookupModel>>(base.acoApiUrl + "lookup/GetCourtTypes", HttpMethod.Get, null, null);
            var responseJCMS = await httpClientHelper.MakeHttpRequest<HttpResponseModel<LookupModel>, HttpResponseModel<LookupModel>>(base.jcmsApiUrl + "lookup/GetCourtTypes", HttpMethod.Get, null, null);
            var response = new List<LookupModel>();
            if (responseACO != null && responseACO.data != null)
            {
                response.AddRange(responseACO.data);
            }
            if (responseJCMS != null && responseJCMS.data != null)
            {
                response.AddRange(responseJCMS.data);
            }
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("GetCaseCategorybyIdCaseType")]
        public async Task<IActionResult> GetCaseCategorybyIdCaseType(string Id)
        {
            var parameters = new Dictionary<string, string>
            {
                { "Id", Id}
            };
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel<LookupModel>, HttpResponseModel<LookupModel>>(base.acoApiUrl + "lookup/GetCaseCategorybyIdCaseType", HttpMethod.Get, null, parameters);
            var responseJCMS = await httpClientHelper.MakeHttpRequest<HttpResponseModel<LookupModel>, HttpResponseModel<LookupModel>>(base.jcmsApiUrl + "lookup/GetCaseCategorybyIdCaseType", HttpMethod.Get, null, parameters);
            var response = new List<LookupModel>();
            if (responseACO != null && responseACO.data != null)
            {
                response.AddRange(responseACO.data);
            }
            if (responseJCMS != null && responseJCMS.data != null)
            {
                response.AddRange(responseJCMS.data);
            }
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("GetCaseSubCategorybyCategoryId")]
        public async Task<IActionResult> GetCaseSubCategorybyCategoryId(string Id)
        {
            var parameters = new Dictionary<string, string>
            {
                { "Id", Id}
            };
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel<LookupModel>, HttpResponseModel<LookupModel>>(base.acoApiUrl + "lookup/GetCaseSubCategorybyCategoryId", HttpMethod.Get, null, parameters);
            var responseJCMS = await httpClientHelper.MakeHttpRequest<HttpResponseModel<LookupModel>, HttpResponseModel<LookupModel>>(base.jcmsApiUrl + "lookup/GetCaseSubCategorybyCategoryId", HttpMethod.Get, null, parameters);
            var response = new List<LookupModel>();
            if (responseACO != null && responseACO.data != null)
            {
                response.AddRange(responseACO.data);
            }
            if (responseJCMS != null && responseJCMS.data != null)
            {
                response.AddRange(responseJCMS.data);
            }
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("GetCaseTypes")]
        public async Task<IActionResult> GetCaseTypes()
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel<LookupModel>, HttpResponseModel<LookupModel>>(base.acoApiUrl + "lookup/GetCaseTypes", HttpMethod.Get, null, null);
            var responseJCMS = await httpClientHelper.MakeHttpRequest<HttpResponseModel<LookupModel>, HttpResponseModel<LookupModel>>(base.jcmsApiUrl + "lookup/GetCaseTypes", HttpMethod.Get, null, null);
            var response = new List<LookupModel>();
            if (responseACO != null && responseACO.data != null)
            {
                response.AddRange(responseACO.data);
            }
            if (responseJCMS != null && responseJCMS.data != null)
            {
                response.AddRange(responseJCMS.data);
            }
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("GetCourtNamebyCourtTypeId")]
        public async Task<IActionResult> GetCourtNamebyCourtTypeId(string Id, string ApiType)
        {
            var parameters = new Dictionary<string, string>
            {
                { "Id", Id}
            };
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel<LookupModel>, HttpResponseModel<LookupModel>>(base.acoApiUrl + "lookup/GetCourtNamebyCourtTypeId", HttpMethod.Get, null, parameters);
            var responseJCMS = await httpClientHelper.MakeHttpRequest<HttpResponseModel<LookupModel>, HttpResponseModel<LookupModel>>(base.jcmsApiUrl + "lookup/GetCourtNamebyCourtTypeId", HttpMethod.Get, null, parameters);
            var response = new List<LookupModel>();
            if (ApiType == "A")
            {
                if (responseACO != null && responseACO.data != null)
                {
                    response.AddRange(responseACO.data);
                }
            }
            else
            {
                if (responseJCMS != null && responseJCMS.data != null)
                {
                    response.AddRange(responseJCMS.data);
                }
            }
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("GetPartyTypebyCaseTypeId")]
        public async Task<IActionResult> GetPartyTypebyCaseTypeId(string Id)
        {
            var parameters = new Dictionary<string, string>
            {
                { "Id", Id}
            };
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel<LookupModel>, HttpResponseModel<LookupModel>>(base.acoApiUrl + "lookup/GetPartyTypebyCaseTypeId", HttpMethod.Get, null, parameters);
            var responseJCMS = await httpClientHelper.MakeHttpRequest<HttpResponseModel<LookupModel>, HttpResponseModel<LookupModel>>(base.jcmsApiUrl + "lookup/GetPartyTypebyCaseTypeId", HttpMethod.Get, null, parameters);
            var response = new List<LookupModel>();
            if (responseACO != null && responseACO.data != null)
            {
                response.AddRange(responseACO.data);
            }
            if (responseJCMS != null && responseJCMS.data != null)
            {
                response.AddRange(responseJCMS.data);
            }
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("GetOriginalCaseInfoByCaseNo")]
        public async Task<IActionResult> GetOriginalCaseInfoByCaseNo(string CourtNameId, string CaseSerial, string CaseCode, string CaseYear, string CategoryId)
        {
            var parameters = new Dictionary<string, string>
            {
                 { "CourtNameId", CourtNameId},
                 { "CaseSerial", CaseSerial},
                 { "CaseCode", CaseCode},
                 { "CaseYear", CaseYear},
                 { "CategoryId", CategoryId}
            };
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel<OriginalCaseInfoModel>, HttpResponseModel<OriginalCaseInfoModel>>(base.acoApiUrl + "lookup/GetOriginalCaseInfoByCaseNo", HttpMethod.Get, null, parameters);
            var responseJCMS = await httpClientHelper.MakeHttpRequest<HttpResponseModel<OriginalCaseInfoModel>, HttpResponseModel<OriginalCaseInfoModel>>(base.jcmsApiUrl + "lookup/GetOriginalCaseInfoByCaseNo", HttpMethod.Get, null, parameters);
            var response = new List<OriginalCaseInfoModel>();
            if (responseACO != null && responseACO.data != null)
            {
                response.AddRange(responseACO.data);
            }
            if (responseJCMS != null && responseJCMS.data != null)
            {
                response.AddRange(responseJCMS.data);
            }
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("GetPartyInformationbyOriginalcaseId")]
        public async Task<IActionResult> GetPartyInformationbyOriginalcaseId(string Id)
        {
            var parameters = new Dictionary<string, string>
            {
                { "Id", Id}
            };
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel<PartyInformationModel>, HttpResponseModel<PartyInformationModel>>(base.acoApiUrl + "lookup/GetPartyInformationbyOriginalcaseId", HttpMethod.Get, null, parameters);
            var responseJCMS = await httpClientHelper.MakeHttpRequest<HttpResponseModel<PartyInformationModel>, HttpResponseModel<PartyInformationModel>>(base.jcmsApiUrl + "lookup/GetPartyInformationbyOriginalcaseId", HttpMethod.Get, null, parameters);
            var response = new List<PartyInformationModel>();
            if (responseACO != null && responseACO.data != null)
            {
                response.AddRange(responseACO.data);
            }
            if (responseJCMS != null && responseJCMS.data != null)
            {
                response.AddRange(responseJCMS.data);
            }
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }
        #endregion

    }
}
