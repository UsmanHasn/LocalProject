using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
         
    public class SJCESP_CaseInformation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public Int64? Identifiant { get; set; }
        
        public Boolean? Affichable { get; set; }

        public string CaseNumber { get; set; }
        public DateTime RegisterDate { get; set; }
        public string? CourtName { get; set; }
        public string? CaseObject { get; set; }
        public string? CaseType { get; set; }
        public string? TypeofRequest { get; set; }
        public decimal? CourtFees { get; set; }
       





    }
}
