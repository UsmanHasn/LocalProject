using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class CasePartyModel
    {
        public string? group { get; set; }
        public List<CaseParties> items { get; set; }
    }
    public class LKTPartyCategory
    {
        public int PartyCategoryId { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? CreatedBy { get; set; }
    }
    public class LKTPartyType
    {
        public int PartyTypeId { get; set; }
        public int? PartyCategoryId { get; set; }
        public int? CaseGroupId { get; set; }
        public string CAAJ_Code { get; set; }
        public string ACO_Code { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
    }
}
