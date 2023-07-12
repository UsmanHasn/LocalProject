using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPI.Helper;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/httpjson/")]
    public class HttpJsonRequestController : Controller
    {
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
