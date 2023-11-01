using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class CaseCategoryDetails
    {
        public int CaseCatDtlId { get; set; }
        public int CaseCateggoryId { get; set; }
        public string Description_en { get; set; }
        public string Description_ar { get; set; }
        public string ImageUrl { get; set; }
        public string ServiceUsers_en { get; set; }
        public string ServiceUsers_ar { get; set; }
        public string Procedure_en { get; set; }
        public string Procedure_ar { get; set; }
        public string ReqdDocs_en { get; set; }
        public string ReqdDocs_ar { get; set; }
        public string ReqdApprovals_en { get; set; }
        public string ReqdApprovals_ar { get; set; }
        public string ServiceFee_en { get; set; }
        public string ServiceFee_ar { get; set; }
        public string DeliveryTime_en { get; set; }
        public string DeliveryTime_ar { get; set; }
        public string ReqdDocTypeIds { get; set; }
        public string VisibleToRoleIds { get; set; }
        public string Action { get; set; }



    }
}
