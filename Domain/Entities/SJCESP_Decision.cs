using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SJCESP_Decision
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int64? IdDossierCivil { get; set; }
        public string? Libelle_Ar { get; set; }
        public string? ContenuDecision { get; set; }
     
    }
}
