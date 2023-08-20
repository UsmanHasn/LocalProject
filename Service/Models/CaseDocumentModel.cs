using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class CaseDocumentModel
    {
        public long DocumentId { get; set; }
        public long CaseId { get; set; }
        public int DocumentType { get; set; }
        public string DocumentPath { get; set; }
        public string Description { get; set; }
    }
}
