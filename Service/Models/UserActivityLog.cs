using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class UserActivityLog
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserNameAr { get; set; }
        public string? PageName { get; set; }

        public string? Message { get; set; }
        public string? TimeLoggedIn { get; set; }

        public DateTime? TimeLoggedOut { get; set; }
    }
}
