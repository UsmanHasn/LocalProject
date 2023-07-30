using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SJCESP_AlertandNotification 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int64? CaseID { get; set; }
        [Key]
        public Boolean? Affichable { get; set; }
        public string Notificationtype { get; set; }
        public string AlertMessage { get; set; }
        

    }
}
