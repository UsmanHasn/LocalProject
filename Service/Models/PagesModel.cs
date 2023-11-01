using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class PagesModel
    {
        public int Id { get; set; }
        public string PageName { get; set; }
        public string PageNameAr { get; set; }
        public string PageModuleEn { get; set; }
        public string PageModuleAr { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class PageModelPagination
    {
        public List<PagesModel> PaginatedData { get; set; }
        public int TotalCount { get; set; }
    }
}
