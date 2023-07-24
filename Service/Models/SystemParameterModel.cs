using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class SystemParameterModel
    {
        public int systemSettingId { get; set; }
        public string? keyName { get; set; }
        public string? keyValue { get; set; }
        public string? description { get; set; }
        public string? createdBy { get; set; }
        public DateTime? createdDate { get; set; }
    }
}
