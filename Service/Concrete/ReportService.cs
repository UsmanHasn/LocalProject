using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class ReportService : IReportService
    {
        public List<PaymentHistoryModel> GetPaymentHistory(string? caseNo, string? date, string? fee, string? status)
        {
            List<PaymentHistoryModel> model = new List<PaymentHistoryModel>();
            model.Add(new PaymentHistoryModel()
            {
                caseNo = "2669",
                date = "2015-06-17",
                fee = "30",
                status = "Pending"
            });

            model.Add(new PaymentHistoryModel()
            {
                caseNo = "42027",
                date = "2023-03-09",
                fee = "25",
                status = "Pending"
            });
            model.Add(new PaymentHistoryModel()
            {
                caseNo = "42026",
                date = "2023-03-09",
                fee = "42",
                status = "Success"
            });
            model.Add(new PaymentHistoryModel()
            {
                caseNo = "42025",
                date = "2023-03-09",
                fee = "28",
                status = "Success"
            });
            model.Add(new PaymentHistoryModel()
            {
                caseNo = "42024",
                date = "2023-03-09",
                fee = "15",
                status = "Failure"
            });
            model.Add(new PaymentHistoryModel()
            {
                caseNo = "42023",
                date = "2023-03-09",
                fee = "15",
                status = "Pending"
            });
            model.Add(new PaymentHistoryModel()
            {
                caseNo = "42022",
                date = "2023-03-09",
                fee = "22",
                status = "Success"
            });
            model.Add(new PaymentHistoryModel()
            {
                caseNo = "42021",
                date = "2023-03-09",
                fee = "30",
                status = "Success"
            });
            if (!string.IsNullOrEmpty(caseNo) || !string.IsNullOrEmpty(date) || !string.IsNullOrEmpty(fee) || !string.IsNullOrEmpty(status))
            {
                model = model.Where(x => x.caseNo == caseNo || x.date == date || x.fee == fee || x.status == status).ToList();
            }


            return model;
        }
    }
}
