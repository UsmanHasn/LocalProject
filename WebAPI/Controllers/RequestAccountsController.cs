using Data.Context;
using Domain.Helper;
using Domain.Modeles;
using Microsoft.AspNetCore.Mvc;
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
        string folderName = "";
        //string
        public RequestAccountsController(IRequestAccountService requestAccountService)
        {
            _requestAccountService = requestAccountService;
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
            //var file = Request.Form.Files[0];
            //var folderName = Path.Combine("wwwroot", "requestaccount");
            //var pathTotSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            _requestAccountService.AddRequestAccount(requestAccountsModel, userName, "");
            return new JsonResult(new { data = requestAccountsModel, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("uploadimage")]
        public IActionResult UploadImage(int actionTypeId,string role,int entityId,string comments,int requestStatusId,string createdBy,DateTime createdDate,string lastModifiedBy,DateTime lastModifiedDate,int documentTypeId,char _type, string userName)
        {
            var file = Request.Form.Files[0];
            folderName = Path.Combine("wwwroot", "requestaccount");
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
                    RequestAccountsModel requestAccountsModel = new RequestAccountsModel()
                    {
                        ActionTypeId = actionTypeId,
                        Role = role,
                        EntityId = entityId,
                        Comments = comments,
                        RequestStatusId = requestStatusId,
                        CreatedBy = createdBy,
                        CreatedDate = createdDate,
                        LastModifiedBy = lastModifiedBy,
                        LastModifiedDate = lastModifiedDate,
                        DocumentTypeId = documentTypeId,
                        DocPath = fullPath,
                        FileName = fileName,
                        Type = _type
                    };
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
        public IActionResult GetRequestAccount()
        {
            List<RequestAccountsModel> model = new List<RequestAccountsModel>();
            model = _requestAccountService.GetAll();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
    }
}