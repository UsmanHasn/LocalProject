using Azure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using WebAPI.Helper;
using WebAPI.Models;
using WebAPI.Models.APIModels;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/httpjson/")]
    public class HttpJsonRequestController : Controller
    {
        [HttpPost]
        [Route("getpersonalinfo")]
        public async Task<IActionResult> GetPersonalInfo(PersonalApiRequestModel personalApiRequest)
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var response = new HttpResponseModel<PersonalApiResponseModel>();
            try
            {
                response = await httpClientHelper.MakeHttpRequest<PersonalApiRequestModel, HttpResponseModel<PersonalApiResponseModel>>
                    ("https://integrationsvc.com/api/GovServ/PersonInformationV2", HttpMethod.Post, personalApiRequest, null);

            }
            catch (Exception ex)
            {
                return null;                
            }
            if (response == null)
            {
                response = SjcConstants.getPersonalInfo(personalApiRequest.CardCivilNo);
            }
            return new JsonResult(new { data = (response != null ? response.data[0] : null), status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getlawyerbycivilno")]
        public async Task<IActionResult> GetLawyerByCivilNo(string civilNo)
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var responseLaywer = await httpClientHelper.MakeHttpRequest<HttpResponseModel<LawyerJsonModel>, HttpResponseModel<LawyerJsonModel>>("http://10.146.2.5/WBSTest/api/GovServ/LawyerInformation/" + civilNo, HttpMethod.Get, null, null);
            var response = new List<LawyerJsonModel>();
            response.AddRange(responseLaywer.data);
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }

        

    }
}
