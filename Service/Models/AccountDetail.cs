using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public  class AccountDetail
    {
        public int UserId { get; set; }
        public bool isEmailVerified { get; set; }
        public bool isPhoneVerified { get; set; }
    }
}
