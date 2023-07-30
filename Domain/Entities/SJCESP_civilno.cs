using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class SJCESP_civilno
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]     
        public Int64? IdDossierCivil { get; set; }
        [Key]
        public string? NumeroPieceIdentite { get; set; }
        public string? name { get; set; }
    }
}
