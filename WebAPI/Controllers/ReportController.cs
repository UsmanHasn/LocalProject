using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll(string? caseNo, string? date, string? fee, string? status)
        {
            List<PaymentHistoryModel> models = new List<PaymentHistoryModel>();
            models = _reportService.GetPaymentHistory(caseNo, date, fee, status);
            return new JsonResult(new { data = models, status = HttpStatusCode.OK });
        }
    }
}