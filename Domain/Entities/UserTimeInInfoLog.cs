using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class UserTimeInInfoLog : BaseEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(100)]
        public string Message { get; set; }
        [Required]
        public DateTime TimeLoggedIn { get; set; }

        public DateTime? TimeLoggedOut { get; set; }
    }
}
