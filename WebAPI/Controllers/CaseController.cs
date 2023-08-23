using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;
using System.Net.Http.Headers;

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
            caseModel.CaseId = _caseService.AddCase(caseModel, userName);
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
        [HttpGet]
        [Route("GetPartiesByCaseId")]
        public IActionResult GetPartiesByCaseId(long CaseId)
        {
            List<CaseParties> model = new List<CaseParties>();
            model = _caseService.GetCaseParties(CaseId);
            
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("GeCaseDocumentsByCaseId")]
        public IActionResult GeCaseDocumentsByCaseId(long CaseId)
        {
            List<CaseDocumentsModel> model = new List<CaseDocumentsModel>();
            model = _caseService.GeCaseDocumentsByCaseId(CaseId);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("UpdateCaseStatus")]
        public IActionResult UpdateCaseStatus(long CaseId, string CaseStatus, string UserName)
        {
           _caseService.UpdateCaseStatus(CaseId, CaseStatus, UserName);
            return new JsonResult(new { data = new { CaseId= CaseId, CaseStatus = CaseStatus, Message = "Case updated" }, status = HttpStatusCode.OK });
        }
        #region
        [HttpPost]
        [Route("uploaddocument")]
        public IActionResult UploadDocument(string caseId, string documentId, string documentType, string description, string userName)
        {
            
            var file = Request.Form.Files[0];
            string folderName = Path.Combine("wwwroot", "Case Document");
            var pathTotSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var folderPath = Path.Combine(pathTotSave, caseId);
                var fullPath = Path.Combine(pathTotSave, caseId, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                DirectoryInfo di = new DirectoryInfo(pathTotSave);
                if (!di.Exists)
                {
                    di.Create();
                }
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    CaseDocumentModel caseDocumentModel = new CaseDocumentModel()
                    {
                        CaseId = Convert.ToInt64(caseId),
                        DocumentId = Convert.ToInt64(documentId),
                        DocumentPath = fullPath,
                        Description = description,
                        DocumentType = Convert.ToInt32(documentType)
                    };
                    _caseService.AddCaseDocuments(caseDocumentModel, userName);
                }
                return new JsonResult(new { data = dbPath, status = HttpStatusCode.OK });
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetAllCases")]
        public IActionResult GetAllCases()
        {
            List<CaseModel> model = new List<CaseModel>();
            model = _caseService.GetAllCases().Select(x => new CaseModel() { CaseId = x.CaseId, CaseNo = x.CaseNo, CourtTypeId = x.CourtTypeId, CourtBuildingId = x.CourtBuildingId , CourtName =x.CourtName , CaseTypeId =x.CaseTypeId , CaseType =x.CaseType , CaseCategoryId =x.CaseCategoryId , CaseCatName =x.CaseCatName , CaseSubCategoryId  =x.CaseSubCategoryId, CaseSubCatName= x.CaseSubCatName, FiledOn= x.FiledOn , Subject =x.Subject, CreatedBy =x.CreatedBy , CreatedDate =x.CreatedDate , LastModifiedDate =x.LastModifiedDate , LastModifiedBy =x.LastModifiedBy , OriginalCaseNo =x.OriginalCaseNo, CaseStatusName=x.CaseStatusName }).ToList();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        #endregion
    }
}
