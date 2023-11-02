using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class CORCaseSubjectModel
    {
        public int CaseSubjectId { get; set; }
        public int CaseGrpCatTypeId { get; set; }

        public int SubjectId { get; set; }
        public int AllowOriginalCase { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int Deleted { get; set; }

        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? ACO_Code { get; set; }
        public string? CAAJ_Code { get; set; }
    }


    public class CORCaseSubject
    {
        public int CaseGrpCatTypeId { get; set; }
        public int[] SubjectId { get; set; }
        public string CreatedBy { get; set; }
    }
}
