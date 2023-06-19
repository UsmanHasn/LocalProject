using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class UserProfileModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserUniqueId { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }
        public int? SupervisorUserId { get; set; }

        public string SupervisorName { get; set; }

        public string Status { get; set; }

    }
}
