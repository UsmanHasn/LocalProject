using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/case")]
    public class CaseController : Controller
    {
        private readonly ICaseService _caseService;

        public CaseController(ICaseService caseService)
        {
            _caseService= caseService;
        }

        [HttpPost]
        [Route("insertcase")]
        public IActionResult Insertcase(CaseModel caseModel, string userName)
        {
            caseModel.CaseId =  _caseService.AddCase(caseModel, userName);
            return new JsonResult(new { data = caseModel, status = HttpStatusCode.OK });
        }
        [HttpPost]
        [Route("insertcaseparties")]
        public IActionResult InsertCaseParties(CaseParties caseParties, string userName)
        {
            _caseService.AddCaseParties(caseParties, userName);
            return new JsonResult(new { data = caseParties, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("GetCaseByCivilNo")]
        public IActionResult GetCaseByCivilNo(string CivilNo)
        {
            List<CaseModel> model = new List<CaseModel>();
            model = _caseService.GetAllCases(CivilNo);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("GetCaseById")]
        public IActionResult GetCaseById(long CaseId)
        {
            CaseModel model = new CaseModel();
            model = _caseService.GetCaseById(CaseId);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

    }
}
