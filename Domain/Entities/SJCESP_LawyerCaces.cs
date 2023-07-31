using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
    public class SJCESP_LawyerCaces
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int64? CaseID { get; set; }
        public string? LawyerName { get; set; }
        public string? NumeroPieceIdentite { get; set; }
    }
}
