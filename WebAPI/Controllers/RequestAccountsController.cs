using Data.Context;
using Domain.Helper;
using Domain.Modeles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/documenttype/")]
    public class RequestAccountsController : Controller
    {
        private readonly IRequestAccountService? _requestAccountService;
        private readonly string UploadFolder = "\\wwwroot\\requestaccount\\"; // Replace with actual path
        private readonly IWebHostEnvironment environment;
        string folderName = "";
        //string
        public RequestAccountsController(IRequestAccountService requestAccountService, IWebHostEnvironment repository)
        {
            _requestAccountService = requestAccountService;
            environment = repository;
        }

        [HttpGet]
        [Route("binddoctype")]
        public IActionResult BindDocumentType()
        {
            List<DocumentTypeLookupModel> model = new List<DocumentTypeLookupModel>();
            model = _requestAccountService.BindDocumentType();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("insertrequestaccount")]
        public IActionResult Add(RequestAccountsModel requestAccountsModel, string userName)
        {
            var InitiateRequest = _requestAccountService.GetRequestStatusIdFromSystemSetting("InitiateRequest");
            var Assigned = _requestAccountService.GetRequestStatusIdFromSystemSetting("Assigned");
            var Approved = _requestAccountService.GetRequestStatusIdFromSystemSetting("Approved");


            //Initiate
            requestAccountsModel.RequestStatusId = Convert.ToInt32(InitiateRequest.KeyValue);
            _requestAccountService.AddRequestAccount(requestAccountsModel, userName, "");

            //Assign
            requestAccountsModel.RequestStatusId = Convert.ToInt32(Assigned.KeyValue);
            _requestAccountService.AddRequestAccount(requestAccountsModel, userName, "");

            //Approved
            requestAccountsModel.RequestStatusId = Convert.ToInt32(Approved.KeyValue);
            _requestAccountService.AddRequestAccount(requestAccountsModel, userName, "");

            return new JsonResult(new { data = requestAccountsModel, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("uploadimage")]
        public IActionResult UploadImage(int actionTypeId, string role, int entityId, string comments, int requestStatusId, string createdBy, DateTime createdDate, string lastModifiedBy, DateTime lastModifiedDate, int documentTypeId, char _type, string userName, int userId)
        {
            var file = Request.Form.Files[0];
            folderName = Path.Combine("Assets", "requestaccount");
            var pathTotSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathTotSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                //folderName = fullPath;
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    var InitiateRequest = _requestAccountService.GetRequestStatusIdFromSystemSetting("InitiateRequest");
                    var Assigned = _requestAccountService.GetRequestStatusIdFromSystemSetting("Assigned");
                    RequestAccountsModel requestAccountsModel = new RequestAccountsModel()
                    {
                        ActionTypeId = actionTypeId,
                        Role = role,
                        EntityId = entityId,
                        Comments = comments,
                        RequestStatusId = 1,
                        CreatedBy = createdBy,
                        CreatedDate = createdDate,
                        LastModifiedBy = lastModifiedBy,
                        LastModifiedDate = lastModifiedDate,
                        DocumentTypeId = documentTypeId,
                        DocPath = fullPath,
                        FileName = fileName,
                        Type = _type,
                        UserId = userId
                    };
                    requestAccountsModel.RequestStatusId = Convert.ToInt32(InitiateRequest.KeyValue);
                    _requestAccountService.AddRequestAccount(requestAccountsModel, userName, fullPath);

                    requestAccountsModel.RequestStatusId = Convert.ToInt32(Assigned.KeyValue);
                    _requestAccountService.AddRequestAccount(requestAccountsModel, userName, fullPath);
                }
                return new JsonResult(new { data = dbPath, status = HttpStatusCode.OK });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("insertlinkcompany")]
        public IActionResult AddLicktoCompany(LinkCompanyModel linkCompanyModel, string userName)
        {
            LinkCompanyModel sysModel = _requestAccountService.GetCivilNo(linkCompanyModel.CivilNo);
            if (sysModel == null)
            {
                _requestAccountService.AddLinkCompany(linkCompanyModel, userName);
                return new JsonResult(new { data = linkCompanyModel, status = HttpStatusCode.OK });
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        [Route("getallrequestaccount")]
        public IActionResult GetRequestAccount(int userId)
        {
            List<RequestAccountsModel> model = new List<RequestAccountsModel>();
            model = _requestAccountService.GetAll(userId);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpGet("{imageName}")]
        public IActionResult GetImage(string imageName)
        {
            // Retrieve the image file and return it as a file result.
            var imagePath = Path.Combine(environment.WebRootPath, "requestaccount", "", "", imageName);
            var imageBytes = System.IO.File.ReadAllBytes(imagePath);
            return File(imageBytes, "image/PNG"); // Adjust the content type as needed.
        }


        [HttpGet]
        [Route("getallrequestaccountForAdmin")]
        public IActionResult GetRequestAccountForAdmin(string? ActionTypeId, string? CivilNo, string? UserName)
        {
            List<RequestAccountsModel> model = new List<RequestAccountsModel>();
            model = _requestAccountService.GetAllForAdmin(ActionTypeId, CivilNo, UserName);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("updateRequestAccountHistory")]
        public IActionResult updateRequestAccountHistory(int requestId, int responseStatusId)
        {
            _requestAccountService.UpdateRequestAccountHistory(requestId, responseStatusId);
            return new JsonResult(new { data = true, status = HttpStatusCode.OK });
        }
    }
}