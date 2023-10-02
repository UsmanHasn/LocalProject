using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class LanguageLookupModel
    {
        public int LanguageId { get; set; }
        public string? Key { get; set; }
        public string? EnglishValue { get; set; }
        public string? ArabicValue { get; set; }
        public string? CreatedBy { get; set; }
        public bool Deleted { get; set;}
        public string? LastModifiedBy { get; set; }
    }
    public class PaginatedLanguageLookupModel
    {
        public List<LanguageLookupModel> PaginatedData { get; set; }
        public int TotalCount { get; set; }
    }
    internal class TotalCountModel
    {
        public int TotalCount { get; set; }
    }
}