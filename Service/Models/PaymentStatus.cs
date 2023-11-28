using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public  class PaymentStatus
    {
        public bool order_status { get; set; }
        public string status_message { get; set; }
    }
}
