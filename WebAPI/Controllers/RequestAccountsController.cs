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

            _requestAccountService.AddRequestAccount(requestAccountsModel, userName, folderName);
            return new JsonResult(new { data = requestAccountsModel, status = HttpStatusCode.OK });
        }

        [HttpPost]
        [Route("uploadimage")]
        public IActionResult UploadImage()
        {
            var file = Request.Form.Files[0];
            folderName = Path.Combine("wwwroot", "requestaccount");
            var pathTotSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathTotSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return new JsonResult(new { data = dbPath, status = HttpStatusCode.OK });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}