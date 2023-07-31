using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class SMS_TransModel
    {
       public int SMS_Trans_ID {get; set;}
        public string Text_Numbers { get; set; }
        public string Text_Message { get; set; }
        public string Notes { get; set; }






        public DateTime CreatedDate { get; set; }
        public string Created_On { get; set; }
        public string Modified_By { get; set; }
        public DateTime Modified_On { get; set; }
    }
}
