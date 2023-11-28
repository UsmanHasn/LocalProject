using Domain.Entities;
using Domain.Modeles;
using MailKit.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Drawing.Printing;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Xml.Linq;
using WebAPI.Models;
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
            try
            {
                caseModel.CaseId = _caseService.AddCase(caseModel, userName);
                return new JsonResult(new { data = caseModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpPost]
        [Route("insertcaseparties")]
        public IActionResult InsertCaseParties(CaseParties caseParties, string userName)
        {
            try
            {
                CasePartiesResponse response = _caseService.AddCaseParties(caseParties, userName);
                if (response.status == 200)
                {
                    return new JsonResult(new { data = caseParties, status = HttpStatusCode.OK });
                }
                else 
                {
                    return new JsonResult(new { data = response, status = HttpStatusCode.Forbidden });
                }
                
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("GetCaseByCivilNo")]
        public IActionResult GetCaseByCivilNo(string CivilNo)
        {
            List<CaseModel> model = new List<CaseModel>();
            try
            {
                model = _caseService.GetAllCases(CivilNo);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("GetRequest")]
        public IActionResult GetRequest(int? caseId, int? pageSize, int? pageNumber, string? SearchText)
        {
            try
            {
                var model = _caseService.GetAllRequest(caseId, pageSize, pageNumber, SearchText);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("GetCaseById")]
        public IActionResult GetCaseById(long CaseId)
        {
            CaseModel model = new CaseModel();
            try
            {
                model = _caseService.GetCaseById(CaseId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("GetPartiesByCaseId")]
        public IActionResult GetPartiesByCaseId(long CaseId, long PartyNo)
        {

            List<CaseParties> model = new List<CaseParties>();
            try
            {
                model = _caseService.GetCaseParties(CaseId, PartyNo);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }
        }


        [HttpGet]
        [Route("GeCaseDocumentsByCaseId")]
        public IActionResult GeCaseDocumentsByCaseId(long CaseId)
        {
            List<CaseDocumentsModel> model = new List<CaseDocumentsModel>();
            try
            {
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
                    UploadDate = x.UploadDate,
                    CaseDocumentId = x.CaseDocumentId
                }).ToList();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("UpdateCaseStatus")]
        public IActionResult UpdateCaseStatus(long CaseId, string CaseStatus, string UserName)
        {
            try
            {
                string caseNo = _caseService.UpdateCaseStatus(CaseId, CaseStatus, UserName).CaseNo;
                return new JsonResult(new { data = new { CaseId = CaseId, CaseNo = caseNo, CaseStatus = CaseStatus, Message = "Case updated" }, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        #region
        [HttpPost]
        [Route("uploaddocument")]
        public IActionResult UploadDocument(string caseId, string documentId, string documentType, string description, string userName)
        {
            try
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
                        Service.Models.CaseDocumentModel caseDocumentModel = new Service.Models.CaseDocumentModel()
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
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpPost]
        [Route("deletecasedocument")]
        public IActionResult DeleteCaseDocument(string caseId, string documentId, string documentType, string description, string userName)
        {
            try
            {
                Service.Models.CaseDocumentModel caseDocumentModel = new Service.Models.CaseDocumentModel()
                {
                    CaseId = Convert.ToInt64(caseId),
                    DocumentId = Convert.ToInt64(documentId),
                    DocumentPath = description,
                    Description = description,
                    DocumentType = Convert.ToInt32(documentType)
                };
                _caseService.DeleteCaseDocument(caseDocumentModel, userName);
                return new JsonResult(new { data = documentId, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }
        }
        [HttpGet]
        [Route("GetAllCases")]
        public IActionResult GetAllCases()
        {
            List<CaseModel> model = new List<CaseModel>();
            try
            {
                model = _caseService.GetAllCases().Select(x => new CaseModel() { CaseId = x.CaseId, CaseNo = x.CaseNo, CourtName = x.CourtName, CaseTypeId = x.CaseTypeId, CaseType = x.CaseType, CaseCategoryId = x.CaseCategoryId, CaseCatName = x.CaseCatName, CaseSubCategoryId = x.CaseSubCategoryId, CaseSubCatName = x.CaseSubCatName, FiledOn = x.FiledOn, Subject = x.Subject, CreatedBy = x.CreatedBy, CreatedDate = x.CreatedDate, LastModifiedDate = x.LastModifiedDate, LastModifiedBy = x.LastModifiedBy, OriginalCaseNo = x.OriginalCaseNo, CaseStatusName = x.CaseStatusName }).ToList();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("GetPendingCase")]
        public IActionResult GetPendingCase(string CivilNo, int CaseStatusId, int pageSize, int pageNumber, string? SearchText)
        {
            try
            {
                var model = _caseService.GetAllPendingCase( CivilNo,  CaseStatusId,  pageSize,  pageNumber, SearchText);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("BindPaymentDraw")]
        public IActionResult BindPaymentDraw()
        {
            List<PaymentActionModel> model = new List<PaymentActionModel>();
            try
            {
                model = _caseService.BindPaymentDraw();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpPost]
        [Route("UpdateCase")]
        public IActionResult UpdateCase(long caseId, string caseStatusId, Decimal fee, int paymentDrawId, int exempted, string userName,string Comment)
        {
            try
            {
                _caseService.UpdateCase(caseId, caseStatusId, fee, paymentDrawId, exempted, userName, Comment);
                return new JsonResult(new { data = new { CaseId = caseId, CaseStatus = caseStatusId, fee = fee, paymentDrawId = paymentDrawId, exempted = exempted }, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }




        [HttpGet]
        [Route("GetCasesByUserName")]
        public IActionResult GetCasesByUserName(string UserName)
        {
            CaseModel model = new CaseModel();
            try
            {
                model = _caseService.GetCasesByUserName(UserName);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("GetCasesByCaseId")]
        public IActionResult GetCasesByCaseId(string CaseId)
        {
            CaseModel model = new CaseModel();
            try
            {
                model = _caseService.GetCasesByCaseId(CaseId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        #endregion


        [HttpPost]
        [Route("AddCaseTypeLookup")]
        public IActionResult AddCaseTypeLookup(CaseTypesLookupModel caseTypesLookupModel, string UserName)
        {
            try
            {
                if (caseTypesLookupModel.CaseTypeId > 0)
                {
                    _caseService.UpdateCaseTypeLookup(caseTypesLookupModel, UserName);
                }
                else
                {
                    _caseService.AddCaseTypeLookup(caseTypesLookupModel, UserName);
                }
                return new JsonResult(new { data = true, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }


        }
        [HttpGet]
        [Route("GetCaseTypeLookup")]
        public IActionResult GetCaseTypeLookup()
        {
            List<CaseTypesLookupModel> model = new List<CaseTypesLookupModel>();
            try
            {
                model = _caseService.GetAllCaseTypeLookup();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("GetCourtTypeLookup")]
        public IActionResult GetCourtTypeLookup()
        {
            List<CourtTypeLookupModel> model = new List<CourtTypeLookupModel>();
            try
            {
                model = _caseService.GetAllCourtTypeLookup();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("GetCaseTypeById")]
        public IActionResult GetCaseTypeById(int caseTypeId)
        {
            CaseTypesLookupModel model = new CaseTypesLookupModel();
            try
            {
                model = _caseService.GetCaseTypeLookupById(caseTypeId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("GetCaseDetail")]
        public IActionResult GetCaseDetail(int caseId)
        {
            CaseModel model = new CaseModel();
            try
            {
                model = _caseService.GetCaseDetail(caseId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("GetCasePartiesDetail")]
        public IActionResult GetCasePartiesDetail(int caseId)
        {
            List<CaseParties> model = new List<CaseParties>();
            try
            {
                model = _caseService.GetCasePartiesDetail(caseId);
                var groupData = model.Select(x => new { group = x.PartyNo }).Distinct();
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
                                            PartyType = y.PartyType,
                                            PartyCategoryId = y.PartyCategoryId,
                                            PartyTypeId = y.PartyTypeId,
                                            PartyTypeName = y.PartyTypeName,
                                            partyTypeNameAr = y.partyTypeNameAr,
                                            EntityId = y.EntityId,
                                            EntityName = y.EntityName,
                                            EntityNameAr = y.EntityNameAr,
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
                                            DocEn = y.DocEn,
                                            DocAr = y.DocAr,
                                            DocumentPath = y.DocumentPath,
                                            Description = y.Description
                                        }).ToList(),
                                        group = x.group.ToString(),
                                    }).ToList();
                return new JsonResult(new { data = modelPermissions, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("GetCasesByStatus")]
        public IActionResult GetCasesByStatus(string UserName, string CaseStatusName)
        {
            List<CaseBasicModel> model = new List<CaseBasicModel>();
            try
            {
                model = _caseService.GetCasesByStatusName(UserName, CaseStatusName);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpPost]
        [Route("DeleteCaseParties")]
        public IActionResult DeleteCaseParties(long CasePartyId)
        {
            try
            {
                CasePartiesDelete deleteCaseParties = new CasePartiesDelete() { CasePartyId = CasePartyId };
                _caseService.DeleteCaseParties(deleteCaseParties);
                return new JsonResult(new { data = deleteCaseParties, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("getcasegroup")]
        public IActionResult GetCaseGroup()
        {
            List<CaseGroupModel> model = new List<CaseGroupModel>();
            try
            {
                model = _caseService.GetCaseGroup();
                List<CaseGroupCountValues> modelCountValues = _caseService.GetCaseGroupCountValues();
                return new JsonResult(new { data = model, countValues = modelCountValues, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("getgroupgovenorates")]
        public IActionResult GetCaseGroupGovernorates(int caseGroupId)
        {
            List<GovernoratesModel> model = new List<GovernoratesModel>();
            try
            {
                model = _caseService.GetGovernoratesByCaseGroupId(caseGroupId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("getgovenorateslocation")]
        public IActionResult GetGovernoratesLocation(int governorateId, bool isActive)
        {
            List<LocationModel> model = new List<LocationModel>();
            try
            {
                model = _caseService.GetLocationByGovernorateId(governorateId, isActive);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("getGrpGovernLocation")]
        public IActionResult GetGrpGovernLocation()
        {
            List<treeViewGrpGovernLocModel> model = new List<treeViewGrpGovernLocModel>();
            try
            {
                model = _caseService.GetGroupGovernorateLcoations();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("getcasecategorybylocation")]
        public IActionResult GetCaseCategoryByLocation(int locationId)
        {
            List<CaseCategoryGroupModel> model = new List<CaseCategoryGroupModel>();
            try
            {
                model = _caseService.GetCategoryByLocationId(locationId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("getcasecategorybycasegroup")]
        public IActionResult GetCaseCategoryByGroup(int caseGroupId, bool isActive)
        {
            List<CaseCategoryGroupModel> model = new List<CaseCategoryGroupModel>();
            try
            {
                model = _caseService.GetCategoryByGroupId(caseGroupId, isActive);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("getcasetypebycategory")]
        public IActionResult GetTypeByCategoryId(int categoryId)
        {
            List<CaseCategoryTypesModel> model = new List<CaseCategoryTypesModel>();
            try
            {
                model = _caseService.GetTypeByCategoryId(categoryId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpPost]
        [Route("insUpdCaseGroup")]
        public IActionResult InsUpdCaseGroup(CaseGroupModel caseGroupModel)
        {
            try
            {
                string message = _caseService.InsUpDel_CaseGroup(caseGroupModel, (caseGroupModel.CaseGroupId > 0 ? "U" : "I"));
                return new JsonResult(new { data = caseGroupModel, message = message, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpPost]
        [Route("deleteCaseGroup")]
        public IActionResult DeleteCaseGroup(CaseGroupModel caseGroupModel)
        {
            try
            {
                string message = _caseService.InsUpDel_CaseGroup(caseGroupModel, "D");
                return new JsonResult(new { data = caseGroupModel, message = message, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpPost]
        [Route("insUpDel_LktGovernorate")]
        public IActionResult InsUpDel_LktGovernorate(LKTGovernorateModel lKTGovernorateModel)
        {
            try
            {
                string message = _caseService.InsUpDel_LktGovernorate(lKTGovernorateModel, (lKTGovernorateModel.GovernateId > 0 ? "U" : "I"));
                return new JsonResult(new { data = lKTGovernorateModel, message = message, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpPost]
        [Route("insUpDel_LktGroupGovernorate")]
        public IActionResult InsUpDel_LktGovernorate(LKT_GroupGovernoratesModel lKTGroupGovernorateModel)
        {
            try
            {
                _caseService.InsUpDel_LktGroupGovernorate(lKTGroupGovernorateModel);
                return new JsonResult(new { data = lKTGroupGovernorateModel, message = "Message.RecordSavedSuccessfully", status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpPost]
        [Route("insUpDel_LktLoction")]
        public IActionResult InsUpDel_LktLocation(LKTLocationModel lKTLocationModel)
        {
            try
            {
                string message = _caseService.InsUpDel_LktLocation(lKTLocationModel, (lKTLocationModel.LocationId > 0 ? "U" : "I"));
                return new JsonResult(new { data = lKTLocationModel, message = message, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("getunassignedgovernorates")]
        public IActionResult getUnassignedGovernorates(int caseGroupId, bool isActive)
        {
            List<LKTGovernorateModel> model = new List<LKTGovernorateModel>();
            try
            {
                model = _caseService.getUnassignedGovernorates(caseGroupId, isActive);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("getassignedgovernorates")]
        public IActionResult getAssignedGovernorates(int caseGroupId)
        {
            List<LKTGovernorateModel> model = new List<LKTGovernorateModel>();
            try
            {
                model = _caseService.getAssignedGovernorates(caseGroupId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpPost]
        [Route("insUpDel_CaseCategory")]
        public IActionResult InsUpDel_CaseCategory(CaseGroupCategoryModel caseGroupCategoryModel)
        {
            try
            {
                string message = _caseService.InsUpDel_CaseCategory(caseGroupCategoryModel, (caseGroupCategoryModel.CaseCategoryId > 0 ? "U" : "I"));
                return new JsonResult(new { data = caseGroupCategoryModel, message = message, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("getpartycategory")]
        public IActionResult getPartyCategory()
        {
            List<LKTPartyCategory> model = new List<LKTPartyCategory>();
            try
            {
                model = _caseService.getPartyCategory();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("getpartytype")]
        public IActionResult getPartyType(int caseGroupId, int partyCategoryId)
        {
            List<LKTPartyType> model = new List<LKTPartyType>();
            try
            {
                model = _caseService.GetPartyTypes(caseGroupId, partyCategoryId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("DeleteCase")]
        public IActionResult DeleteCase(int CaseId)
        {
            try
            {
                _caseService.DeleteCase(CaseId);
                return new JsonResult(new { data = CaseId, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("getcorcasetypes")]
        public IActionResult getcoacasetypes()
        {
            List<CaseCategoryTypesModel> model = new List<CaseCategoryTypesModel>();
            try
            {
                model = _caseService.GetCaseCategoryTypes();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("getunassignedcasetypes")]
        public IActionResult getunassignedcasetypes(int caseGroupId, int caseCategoryId, bool isActive)
        {
            List<CaseCategoryTypesModel> model = new List<CaseCategoryTypesModel>();
            try
            {
                model = _caseService.GetUnassignedCaseTypes(caseGroupId, caseCategoryId, isActive);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("getassignedcasetypes")]
        public IActionResult getassignedcasetypes(int caseGroupId, int caseCategoryId)
        {
            List<CaseCategoryTypesModel> model = new List<CaseCategoryTypesModel>();
            try
            {
                model = _caseService.GetAssignedCaseTypes(caseGroupId, caseCategoryId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpPost]
        [Route("insUpDel_CaseType")]
        public IActionResult InsUpDel_CaseType(CaseCategoryTypesModel caseCategoryTypesModel)
        {
            try
            {
                string message = _caseService.InsUpDel_CaseType(caseCategoryTypesModel, (caseCategoryTypesModel.CaseTypeId > 0 ? "U" : "I"));
                return new JsonResult(new { data = caseCategoryTypesModel, message = message, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("insert_LKT_Subject")]
        public IActionResult insert_LKT_Subject(LKT_SubjectModel lKT_SubjectModel)
        {
            try
            {

                string message = _caseService.InsertLKT_Subject(lKT_SubjectModel, (lKT_SubjectModel.SubjectId > 0 ? "U" : "I"));
                return new JsonResult(new { data = lKT_SubjectModel, message = message, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
        }

        [HttpGet]
        [Route("getLKT_Subject")]
        public IActionResult getLKT_Subject()
        {
            List<LKT_SubjectModel> model = new List<LKT_SubjectModel>();
            try
            {
                model = _caseService.GetAll();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("GetUnAssignedSubjects")]
        public IActionResult GetUnAssignedSubjects(int CaseGrpCatTypeId, bool isActive = true)
        {
            List<CORCaseSubjectModel> model = new List<CORCaseSubjectModel>();
            try
            {
                model = _caseService.GetUnAssignedSubjects(CaseGrpCatTypeId, isActive);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }
        }
        [HttpGet]
        [Route("GetAssignedSubjects")]
        public IActionResult GetAssignedSubjects(int CaseGrpCatTypeId)
        {
            List<CORCaseSubjectModel> model = new List<CORCaseSubjectModel>();
            try
            {
                model = _caseService.GetAssignedSubjects(CaseGrpCatTypeId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }
        }

        [HttpPost]
        [Route("insUpDel_CorCaseSubject")]
        public IActionResult insUpDel_CorCaseSubject(CORCaseSubject cORCaseSubject)
        {
            try
            {
                _caseService.InsUpDel_CorCaseSubject(cORCaseSubject);
                return new JsonResult(new { data = cORCaseSubject, message = "Message.RecordSavedSuccessfully", status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
        }
        [HttpPost]
        [Route("insUpDel_CaseGroupCatType")]
        public IActionResult InsUpDel_CaseGroupCatType(COR_GroupCatTypeModel cor_GroupCatTypeModel)
        {
            try
            {
                _caseService.InsUpDel_CORGrpCatType(cor_GroupCatTypeModel);
                return new JsonResult(new { data = cor_GroupCatTypeModel, message = "Message.RecordSavedSuccessfully", status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("InsUpdCaseCategoryDetails")]
        public IActionResult InsUpdCaseCategoryDetails(CaseCategoryDetails model, string userName)
        {
            try
            {
                string Message;
                Message = _caseService.InsUpdCaseCategoryDetails(model, userName);
                return new JsonResult(new { data = true, status = HttpStatusCode.OK, msg = Message });

            }
            catch (Exception ex)
            {

                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }


        }

        [HttpGet]
        [Route("getallcasecategorydetails")]
        public IActionResult GetAllCaseCategoryDetails()
        {
            List<CaseCategoryDetails> model = new List<CaseCategoryDetails>();

            try
            {
                model = _caseService.GetAllCaseCategoryDetails();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("GetCaseCategoryDetailsbyId")]
        public IActionResult GetCaseCategoryDetailsbyId(int CaseCatDtlId)
        {
            try
            {

                CaseCategoryDetails caseCategoryDetails = new CaseCategoryDetails();
                caseCategoryDetails = _caseService.GetCaseCategoryDetailsbyId(CaseCatDtlId);
                return new JsonResult(new { data = caseCategoryDetails, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
        }

        [HttpPost]
        [Route("DeleteCaseCategoryDetails")]
        public IActionResult DeleteCaseCategoryDetails(CaseCategoryDetails caseCategoryDetails, string userName)
        {
            try
            {
                string Message;
                Message = _caseService.DeleteCaseCategoryDetails(caseCategoryDetails, userName);
                return new JsonResult(new { data = true, status = HttpStatusCode.OK, msg = Message });
            }
            catch (Exception ex)
            {

                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }

        }

        [HttpPost]
        [Route("InsUpDel_CorAdvanceLinkingConfig")]
        public IActionResult InsUpDel_CorAdvanceLinkingConfig(COR_AdvanceLinkingConfigModel cOR_AdvanceLinkingConfigModel)
        {
            try
            {
                _caseService.InsUpDel_CorAdvanceLinkingConfig(cOR_AdvanceLinkingConfigModel);
                return new JsonResult(new { data = cOR_AdvanceLinkingConfigModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }


        [HttpDelete]
        [Route("delete_CorAdvanceLinkingConfig")]
        public IActionResult delete_CorAdvanceLinkingConfig(int linkId)
        {
            try
            {
                _caseService.DeleteAdvanceLinking(linkId);
                return new JsonResult(new { data = linkId, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("GetCorAdvanceLinkingConfigbyId")]
        public IActionResult GetCorAdvanceLinkingConfigbyId(int LinkId)
        {
            try
            {
                COR_AdvanceLinkingConfigModel cOR_AdvanceLinkingConfigModel = new COR_AdvanceLinkingConfigModel();
                cOR_AdvanceLinkingConfigModel = _caseService.GetCOR_AdvanceLinkingConfigById(LinkId);
                return new JsonResult(new { data = cOR_AdvanceLinkingConfigModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }
        }
        [HttpGet]
        [Route("GetCorAdvanceLinkingConfig")]
        public IActionResult GetCorAdvanceLinkingConfig()
        {
            try
            {
                List<COR_AdvanceLinkingConfigModel> model = new List<COR_AdvanceLinkingConfigModel>();
                model = _caseService.GetCOR_AdvanceLinkingConfig();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }
        }
        [HttpGet]
        [Route("getLocationsByCaseGroup")]
        public IActionResult getLocationsByCaseGroup(int caseGroupId)
        {
            List<LKTLocationModel> model = new List<LKTLocationModel>();
            try
            {
                model = _caseService.getLocationsByCaseGroupId(caseGroupId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("GetRequestEventLog")]
        public IActionResult GetRequestEventLog(int requestId , bool userFlag, int pageSize, int pageNumber, string? SearchText)
        {
            try
            {
                var model = _caseService.GetAllRequestEventLog( requestId,  userFlag,  pageSize,  pageNumber,  SearchText);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("InsertRequestEventLog")]
        public IActionResult InsertRequestEventLog([FromBody] RequestEvenLog evenLog)
        {
            try
            {
                var model = _caseService.InsertRequestEventLog(evenLog);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }


        [HttpGet]
        [Route("GetRequest_caseId")]
        public IActionResult GetRequest_caseId(int? caseId,long roleId, string? orderId)
        {
            try
            {
                var Datamodel = _caseService.sjc_GetRequest_caseId(caseId);
                var ActionBasedOnStatus = _caseService.GetActionforAvailableStatus(Datamodel.CaseStatusId,  roleId);
                PaymentStatus paymentStatus = _caseService.GetPaymentStatus(orderId);
                GetRequestInfoAndActions Result = new GetRequestInfoAndActions()
                {
                    Request = Datamodel,
                    GetAvailableActionOnStatuses = ActionBasedOnStatus,
                    paymentStatus = paymentStatus
                };

                return new JsonResult(new { data = Result, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }



        [HttpGet]
        [Route("GetDoctype")]
        public IActionResult GetDoctype()
        {
            try
            {
                List<DocumentTypeModel> model = new List<DocumentTypeModel>();
                model = _caseService.getdocumentType();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }
        }

        [HttpPost]
        [Route("uploaddocumentEventLog")]
        public IActionResult uploaddocumentEventLog(long caseId, long documentId, int documentType, string description, string userName, long actionId)
        {
            try
            {
                var file = Request.Form.Files[0];
                string folderName = Path.Combine("Assets", "Case Document");
                var pathTotSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string folderPath = Path.Combine(pathTotSave, caseId.ToString());
                    fullPath = Path.Combine(pathTotSave, caseId.ToString(), fileName);
                    var dbPath = Path.Combine(folderName, caseId.ToString(), fileName);
                    DirectoryInfo di = new DirectoryInfo(folderPath);
                    if (!di.Exists)
                    {
                        di.Create();
                    }
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        Service.Models.CaseDocumentModel caseDocumentModel = new Service.Models.CaseDocumentModel()
                        {
                            CaseId = caseId,
                            DocumentId = documentId,
                            DocumentPath = dbPath,
                            Description = description,
                            DocumentType = documentType
                        };
                        _caseService.AddCaseEventDocuments(caseDocumentModel,userName,actionId);

                    }
                    return new JsonResult(new { data = dbPath, status = HttpStatusCode.OK });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpPost]
        [Route("deletecaseeventdocument")]
        public IActionResult DeleteCaseEventDocument(long caseId, long documentId, int documentType, string description, string userName)
        {
            try
            {
                Service.Models.CaseDocumentModel caseDocumentModel = new Service.Models.CaseDocumentModel()
                {
                    CaseId = caseId,
                    DocumentId = documentId,
                    DocumentPath = description,
                    Description = description,
                    DocumentType = documentType
                };
                _caseService.DeleteCaseDocument(caseDocumentModel, userName);
                return new JsonResult(new { data = documentId, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {

                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }
        }
        [HttpGet]
        [Route("UpateRequestEventLogView")]
        public IActionResult UpateRequestEventLogView(long? caseId, long LogId, bool ShowToRequestor)
        {
            try
            {
                var Datamodel = _caseService.UpateRequestEventLogView(caseId, LogId, ShowToRequestor);
                return new JsonResult(new { data = Datamodel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
    }
}




