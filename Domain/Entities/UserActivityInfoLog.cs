using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class UserActivityInfoLog : BaseEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }
        //public int Id { get; set; }
        //public Users User { get; set; }
       
        
        [MaxLength(100)]
        public string PageName { get; set; }
        [MaxLength(200)]
        public string Message { get; set; }
       
        public DateTime TimeLoggedIn { get; set; }

        public DateTime? TimeLoggedOut { get; set; }

        public Boolean Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }

        public string? LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

    }
}
