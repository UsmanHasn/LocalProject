using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class CasesFilter
    {

    }
    public class CaseStatus
    {
        public long Case_Status_ID { get; set; }
        public string Case_Status_En { get; set; }
        public string Case_Status_Ar { get; set; }
    }
    public class CaseType
    {
        public long Case_Type_ID { get; set; }
        public string Case_Type_En { get; set; }
        public string Case_Type_ar { get; set; }

    }
}
