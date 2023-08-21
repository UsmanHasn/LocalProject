﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class CaseParties
    {
        public int CasePartyId { get; set; }
        public int CaseId { get; set;}
        public char PartyType { get; set;}
        public int PartyCategoryId { get; set;}
        public string? PartyCatName { get; set;}
        public int PartyTypeId { get; set;}
        public string? PartyTypeName { get; set; }
        public string? CivilNo { get; set;}
        public string? CRNo { get; set; }
        public string? Name { get; set; }
        public string? PhoneNo { get; set;}
        public string? Address { get; set; }
    }
}