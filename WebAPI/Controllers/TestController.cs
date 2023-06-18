using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service;
using Service.Interface;
using Service.Models;
using System.Net;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/test/")]
    public class TestController : ControllerBase
    {
        private readonly ITestService? testService;
        public TestController(ITestService _testService) 
        {
            testService = _testService;
        }
        [HttpGet]
        [Route("getalldata")]
        public IActionResult GetAllData()
        {
            List<TestModel> model = new List<TestModel>();
            model = testService.GetAllData();
            return new JsonResult(new { data = model, status=HttpStatusCode.OK }); 
        }
        [HttpGet]
        [Route("getsingledata")]
        public IActionResult GetSingleData()
        {
            TestModel? model = new TestModel();
            model = testService.GetAllData().FirstOrDefault();
            return new JsonResult(new { data = JsonConvert.SerializeObject(model), status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getdatabyid")]
        public IActionResult GetDataById(int id)
        {
            TestModel? model = new TestModel();
            model = testService.GetAllData().FirstOrDefault(x => x.Id == id);
            return new JsonResult(new { data = JsonConvert.SerializeObject(model), status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getsingledataorderby")]
        public IActionResult GetSingleDataOrderBy(string orderBy)
        {
            TestModel? model = new TestModel();
            model = testService.GetAllData().OrderBy(x => x.Id).FirstOrDefault();
            return new JsonResult(new { data = JsonConvert.SerializeObject(model), status = HttpStatusCode.OK });
        }
    }
}
