﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/pages")]
    public class PagesController : ControllerBase
    {
        private readonly IPagesService _IpagesService;

        public PagesController(IPagesService pagesService)
        {
            _IpagesService = pagesService;
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            try
            {
                var pagesModel = _IpagesService.GetAllPages();
                return new JsonResult(new { data = pagesModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("getPagebyId")]
        public IActionResult GetPageById(int Id)
        {
            PagesModel model = new PagesModel();
            try
            {
                model = _IpagesService.GetpagesById(Id);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });

            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("Insertpages")]
        public IActionResult Addpages(PagesModel pagesModel, string username)
        {
            try
            {
                if (pagesModel.Id > 0)
                {
                    PagesModel model = _IpagesService.GetpagesById(pagesModel.Id);
                    pagesModel.CreatedDate = model.CreatedDate;
                    pagesModel.CreatedBy = model.CreatedBy;
                    _IpagesService.Updatepages(pagesModel, username);
                }
                else
                {
                    _IpagesService.Addpages(pagesModel, username);
                }
                return new JsonResult(new { data = pagesModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
          
        }
        [HttpDelete]
        [Route("Deletepages")]
        public IActionResult Deletepages(int id, string username)
        {
            try
            {
                var pagesModel = _IpagesService.Deletepages(id, username);
                return new JsonResult(new { data = pagesModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpPut]
        [Route("Updatepages")]
        public IActionResult Updatepages(PagesModel pagesModel, string username) 
        {
            try
            {
                var model = _IpagesService.Updatepages(pagesModel, username);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
    }
}
