using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IReportService
    {
        List<PaymentHistoryModel> GetPaymentHistory(string? caseNo,string?date,string?fee,string?status);
    }
}
