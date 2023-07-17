using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public int CivilID { get; set; }
        public string Name { get; set; }

        public string NameAr { get; set; }

        public int Nationality { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        //public string Address { get; set; }

        public string Gender { get; set; }

        public string PassportNo { get; set; }

        public DateTime PassportExpDate { get; set; }

        public int PassportCountryCode { get; set; }

        public string VisaNo { get; set; }

        public DateTime VisaNoExpDate { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int CountryID { get; set; }

        public string City { get; set; }
        public string Password { get; set; }
        public List<int> AssignRoleIds { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
