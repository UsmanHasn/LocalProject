using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PasswordHistory : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PasswordHash { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
