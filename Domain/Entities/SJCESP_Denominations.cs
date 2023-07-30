using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class SJCESP_Denominations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int64? IdDossierCivil { get; set; }
        [Key]
        public string? NumRegistreCommerce { get; set; }
        public string? Denomination { get; set; }
    }
}
