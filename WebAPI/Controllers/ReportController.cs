﻿using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/report")]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll(string? caseNo, string? date, string? caseStatus, string? caseType)
        {
            List<PaymentHistoryModel> models = new List<PaymentHistoryModel>();
            models = _reportService.GetPaymentHistory(caseNo, date, caseStatus, caseType);
            return new JsonResult(new { data = models, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("BindCaseType")]
        public IActionResult BindCaseType()
        {
            List<CaseType> models = new List<CaseType>();
            models = _reportService.BindCaseType();
            return new JsonResult(new { data = models, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("BindCaseStatus")]
        public IActionResult BindCaseStatus()
        {
            List<CaseStatus> models = new List<CaseStatus>();
            models = _reportService.BindCaseStatus();
            return new JsonResult(new { data = models, status = HttpStatusCode.OK });
        }
    }
}