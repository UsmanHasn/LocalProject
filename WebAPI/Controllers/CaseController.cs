using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;
using System.Net.Http.Headers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/case")]
    public class CaseController : Controller
    {
        private readonly ICaseService _caseService;
        private string fullPath;

        public CaseController(ICaseService caseService)
        {
            _caseService = caseService;
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
        public IActionResult GetPartiesByCaseId(long CaseId, long PartyNo)
        {
            List<CaseParties> model = new List<CaseParties>();
            model = _caseService.GetCaseParties(CaseId, PartyNo);

            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }


        [HttpGet]
        [Route("GeCaseDocumentsByCaseId")]
        public IActionResult GeCaseDocumentsByCaseId(long CaseId)
        {
            List<CaseDocumentsModel> model = new List<CaseDocumentsModel>();
            model = _caseService.GeCaseDocumentsByCaseId(CaseId);
            model = model.Select(x => new CaseDocumentsModel()
            {
                //fileStream = System.IO.File.ReadAllBytes(x.DocumentPath),
                CaseId = x.CaseId,
                Description = x.Description,
                DocNameAr = x.DocNameAr,
                DocNameEn = x.DocNameEn,
                DocumentPath = x.DocumentPath,
                DocumentTypeId = x.DocumentTypeId,
                nameAr = x.nameAr,
                nameEn = x.nameEn,
                UploadDate = x.UploadDate
            }).ToList();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("UpdateCaseStatus")]
        public IActionResult UpdateCaseStatus(long CaseId, string CaseStatus, string UserName)
        {
            string caseNo = _caseService.UpdateCaseStatus(CaseId, CaseStatus, UserName).CaseNo;
            return new JsonResult(new { data = new { CaseId = CaseId, CaseNo = caseNo, CaseStatus = CaseStatus, Message = "Case updated" }, status = HttpStatusCode.OK });
        }
        #region
        [HttpPost]
        [Route("uploaddocument")]
        public IActionResult UploadDocument(string caseId, string documentId, string documentType, string description, string userName)
        {

            var file = Request.Form.Files[0];
            string folderName = Path.Combine("Assets", "Case Document");
            var pathTotSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                string folderPath = Path.Combine(pathTotSave, caseId);
                fullPath = Path.Combine(pathTotSave, caseId, fileName);
                var dbPath = Path.Combine(folderName, caseId, fileName);
                DirectoryInfo di = new DirectoryInfo(folderPath);
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
                        DocumentPath = dbPath,
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
            model = _caseService.GetAllCases().Select(x => new CaseModel() { CaseId = x.CaseId, CaseNo = x.CaseNo, CourtName = x.CourtName, CaseTypeId = x.CaseTypeId, CaseType = x.CaseType, CaseCategoryId = x.CaseCategoryId, CaseCatName = x.CaseCatName, CaseSubCategoryId = x.CaseSubCategoryId, CaseSubCatName = x.CaseSubCatName, FiledOn = x.FiledOn, Subject = x.Subject, CreatedBy = x.CreatedBy, CreatedDate = x.CreatedDate, LastModifiedDate = x.LastModifiedDate, LastModifiedBy = x.LastModifiedBy, OriginalCaseNo = x.OriginalCaseNo, CaseStatusName = x.CaseStatusName }).ToList();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("GetPendingCase")]
        public IActionResult GetPendingCase(string CivilNo, int CaseStatusId)
        {
            List<CaseModel> model = new List<CaseModel>();
            model = _caseService.GetAllPendingCase(CivilNo, CaseStatusId);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("BindPaymentDraw")]
        public IActionResult BindPaymentDraw()
        {
            List<LookupsModel> model = new List<LookupsModel>();
            model = _caseService.BindPaymentDraw();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpPost]
        [Route("UpdateCase")]
        public IActionResult UpdateCase(long caseId, string caseStatusId, int fee, int paymentDrawId, int exempted, string userName)
        {
            _caseService.UpdateCase(caseId, caseStatusId, fee, paymentDrawId, exempted, userName);
            return new JsonResult(new { data = new { CaseId = caseId, CaseStatus = caseStatusId, fee = fee, paymentDrawId = paymentDrawId, exempted = exempted }, status = HttpStatusCode.OK });
        }
       

       
       
        [HttpGet]
        [Route("GetCasesByUserName")]
        public IActionResult GetCasesByUserName(string UserName)
        {
            CaseModel model = new CaseModel();
            model = _caseService.GetCasesByUserName(UserName);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("GetCasesByCaseId")]
        public IActionResult GetCasesByCaseId(string CaseId)
        {
            CaseModel model = new CaseModel();
            model = _caseService.GetCasesByCaseId(CaseId);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        #endregion


        [HttpPost]
        [Route("AddCaseTypeLookup")]
        public IActionResult AddCaseTypeLookup(CaseTypesLookupModel caseTypesLookupModel, string UserName)
        {
            if (caseTypesLookupModel.CaseTypeId>0)
            {
                _caseService.UpdateCaseTypeLookup(caseTypesLookupModel, UserName);
            }
            else
            {
                _caseService.AddCaseTypeLookup(caseTypesLookupModel, UserName);
            }
            return new JsonResult(new { data = true, status = HttpStatusCode.OK });

        }
        [HttpGet]
        [Route("GetCaseTypeLookup")]
        public IActionResult GetCaseTypeLookup()
        {
            List<CaseTypesLookupModel> model = new List<CaseTypesLookupModel>();
            model = _caseService.GetAllCaseTypeLookup();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("GetCourtTypeLookup")]
        public IActionResult GetCourtTypeLookup()
        {
            List<CourtTypeLookupModel> model = new List<CourtTypeLookupModel>();
            model = _caseService.GetAllCourtTypeLookup();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("GetCaseTypeById")]
        public IActionResult GetCaseTypeById(int caseTypeId)
        {
            CaseTypesLookupModel model = new CaseTypesLookupModel();
            model = _caseService.GetCaseTypeLookupById(caseTypeId);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("GetCaseDetail")]
        public IActionResult GetCaseDetail(int caseId)
        {
            CaseModel model = new CaseModel();
            model = _caseService.GetCaseDetail(caseId);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("GetCasePartiesDetail")]
        public IActionResult GetCasePartiesDetail(int caseId)
        {
            List<CaseParties> model = new List<CaseParties>();
            model = _caseService.GetCasePartiesDetail(caseId);
            var groupData = model.Select(x => new { group = x.PartyNo}).Distinct();
            List<CasePartyModel> modelPermissions = groupData.Select(x =>
                                new CasePartyModel()
                                {
                                    items = model.Where(y => y.PartyNo == x.group)
                                    .Select(y => new CaseParties()
                                    {
                                        CasePartyId = y.CasePartyId,
                                        CaseId = y.CaseId,
                                        PartyNo = y.PartyNo,
                                        LegalType = y.LegalType,
                                        PartyType=y.PartyType,
                                        PartyCategoryId = y.PartyCategoryId,
                                        PartyTypeId = y.PartyTypeId,
                                        PartyTypeName=y.PartyTypeName,
                                        partyTypeNameAr=y.partyTypeNameAr,
                                        EntityId = y.EntityId,
                                        EntityName=y.EntityName,
                                        EntityNameAr=y.EntityNameAr,
                                        CivilNo = y.CivilNo,
                                        CivilExpiry = y.CivilExpiry,
                                        CRNo = y.CRNo,
                                        Name = y.Name,
                                        PhoneNo = y.PhoneNo,
                                        Address = y.Address,
                                        FamilyName = y.FamilyName,
                                        Email = y.Email,
                                        Country = y.Country,
                                        City = y.City,
                                        DocEn=y.DocEn,
                                        DocAr=y.DocAr,
                                        DocumentPath=y.DocumentPath,
                                        Description=y.Description
                                    }).ToList(),
                                    group = x.group.ToString(),
                                }).ToList();
            return new JsonResult(new { data = modelPermissions, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("GetCasesByStatus")]
        public IActionResult GetCasesByStatus(string UserName, string CaseStatusName)
        {
            List<CaseBasicModel> model = new List<CaseBasicModel>();
            model = _caseService.GetCasesByStatusName(UserName, CaseStatusName);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpPost]
        [Route("DeleteCaseParties")]
        public IActionResult DeleteCaseParties(CasePartiesDelete deleteCaseParties, long CasePartyId)
        {
            _caseService.DeleteCaseParties(deleteCaseParties);
            return new JsonResult(new { data = deleteCaseParties, status = HttpStatusCode.OK });
        }
    }
}
