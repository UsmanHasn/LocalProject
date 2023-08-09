using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class OtpModel
    { public int OtpId { get; set; }
        public int OtpType { get; set; }    
        public int UserId { get; set; }
        public bool EmailSent { get; set; }
    }
}
