﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class CaseTypesLookupModel
    {
       public long CaseTypeId {get; set;}
       public string Code { get; set; }
       public string NameEn {get; set;}
       public string NameAr {get; set;}
       public long CourtTypeId {get; set;}
       public int IsActive {get; set;}
       public string  CreatedBy { get; set;}
       public DateTime  CreatedDate { get; set;}
       public string  LastModifiedBy { get; set;}
       public DateTime LastModifiedDate {get; set;}
       public int Deleted {get; set;}
       public long CaseGroupId {get; set;}
    }
    public class CaseTypesLookupModelDelete
    {
        public long CaseTypeId { get; set; }
        public int Deleted { get; set; }
    }
}
