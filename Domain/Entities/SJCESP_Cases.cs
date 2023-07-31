using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SJCESP_Cases
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string? CRNO { get; set; }
        [Key]
        public Int64? IdDossierCivil { get; set; }
        public string? PartyCompanyName {get; set;}  
        public string? RoleParties {get; set;}      
        public string? LawyerName { get; set; }

    }
}
