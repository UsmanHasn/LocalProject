using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Domain.Entities
{
    public class SJCESP_LawyerAddress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string? LicenseNo { get; set; }
        public string? LawyerName { get; set; }
        public string? OfficeAdress { get; set; }
    }
}
