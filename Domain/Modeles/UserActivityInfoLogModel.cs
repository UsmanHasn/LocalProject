using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeles
{
    public class UserActivityInfoLogModel
    {
        [Key]
        public int UserId { get; set; }
         
        public string PageName { get; set; }
       
        public string Message { get; set; }

        public DateTime TimeLoggedIn { get; set; }

        public DateTime? TimeLoggedOut { get; set; }
    }
}
