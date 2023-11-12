using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Lookups
{
    public class LKT_Country : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
       
        
        public string Name { get; set; }
       
        
        public string NameAr { get; set; }

        public string CodeISONum { get; set; }
        public string CodeISO3 { get; set; }
        public string DialingCode { get; set; }

    }
}
