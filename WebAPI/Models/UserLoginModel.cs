using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class UserLoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class ForgotPasswordModel
    {
        public string CivilNo { get; set; }
        public string Email { get; set; }
    }



}
