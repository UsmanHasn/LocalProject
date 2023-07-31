using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SJCESP_RoleParties
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int64? CaseID { get; set; }
       
        public string? CivilNumberParties { get; set; }

        public string?  PartyFullName { get; set; }
      
        public string? RoleParties { get; set; }
      
        public string? LawyerName { get; set; }
    }
}
