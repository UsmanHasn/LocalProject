using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SJCESP_Judge_Information
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int64? IdDossierCivil { get; set; }
       public string? JudgeName { get; set; }
        public string? SessionInformation { get; set; }
      
    }
}
