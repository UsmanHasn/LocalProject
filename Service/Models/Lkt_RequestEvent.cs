using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Lkt_RequestEvent
    {
        public int EventId { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool IsActive { get; set; }
        public string Action { get; set; }

        public string RequestEventEnglish
        {
            get { return IsActive ? "Yes" : "No"; }
            set { }
        }
        public string RequestEventArabic
        {
            get { return IsActive ? "نعم" : "لا"; }
            set { }

        }
    }
}
