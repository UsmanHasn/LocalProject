using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using System.Net;
using WebAPI.Helper;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/httprequest/")]
    public class HttpRequestController : Controller
    {
        [HttpGet]
        [Route("getcases")]
        public async Task<IActionResult> GetCases()
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();
            var responseACO = await httpClientHelper.MakeHttpRequest<HttpResponseModel>("https://localhost:7140/api/data/GetCases");
            var responseJCMS = await httpClientHelper.MakeHttpRequest<HttpResponseModel>("https://localhost:7233/api/data/GetCases");
            var response = new List<CasesModel>();
            response.AddRange(responseACO.data);
            response.AddRange(responseJCMS.data);
            return new JsonResult(new { data = response, status = HttpStatusCode.OK });
        }
    }
}
