using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Domain.Entities
{

    public class UserProfile : BaseEntity
    {
        public UserProfile()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None), ForeignKey("User")]
        public int Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(256)]
        public string Email { get; set; }
        [MaxLength(250)]
        public string UserUniqueId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [MaxLength(250)]
        public string Address1 { get; set; }
        [MaxLength(250)]
        public string Address2 { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(20)]
        public string Zipcode { get; set; }
        public int? SupervisorUserId { get; set; }
        [MaxLength(50)]
        public string SupervisorName { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }
        public ApplicationUser User { get; set; }

        /// <summary>
        /// Helper read-only property - gets the first or default from AssignedRoles.
        /// </summary>
        public int? AssignedRole
        {
            get
            {
                if (this.User != null && this.User.Roles != null && User.Roles.Count > 0)
                {
                    return User.Roles.FirstOrDefault().RoleId;
                }
                return null;
            }
        }
        /// <summary>
        /// Helper - Full Name
        /// </summary>
        public string FullName
        {
            get
            {
                return string.Concat(this.FirstName, " ", this.LastName);
            }
        }


    }
}
