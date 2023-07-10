using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using System.Net;
using WebAPI.Helper;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/httprequest/")]
    public class HttpRequestController : BaseController
    {
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
            response.AddRange(responseACO.data);
            response.AddRange(responseJCMS.data);
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
            if (responseACO.data != null && responseACO.data.Count() > 0)
            {
                response = responseACO.data.FirstOrDefault();
            }
            else
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
            //var responseJCMS = await httpClientHelper.MakeHttpRequest<HttpResponseModel<CaseSubjectsModel>, HttpResponseModel<CaseSubjectsModel>>(base.jcmsApiUrl + "case/GetSubjectByCaseId?caseId=" + caseId, HttpMethod.Get, null, null);
            var response = new List<CaseSubjectsModel>();
            response.AddRange(responseACO.data);
            //response.AddRange(responseJCMS.data);
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
            //var responseJCMS = await httpClientHelper.MakeHttpRequest<HttpResponseModel<CasePartiesModel>, HttpResponseModel<CasePartiesModel>>(base.jcmsApiUrl + "case/GetPartiesByCaseId?caseId=" + caseId, HttpMethod.Get, null, null);
            var response = new List<CasePartiesModel>();
            response.AddRange(responseACO.data);
            //response.AddRange(responseJCMS.data);
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }
    }
}
