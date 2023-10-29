using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class COR_AdvanceLinkingConfigModel
    {
        public int LinkId { get; set; }
        public int CaseGroupId { get; set; }
        public int LocationId { get; set; }
        public int CategoryId { get; set; }
        public int CaseTypeId { get; set; }
        public int SubjectId { get; set; }
        public bool LinkAllow { get; set; }
        public string? LinkGroupId { get; set; }
        public string? LinkSources { get; set; }
        public string? RoleId { get; set; }

    }
}
