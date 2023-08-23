using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class RequestAccountsModel
    {
        public int RequestId { get; set; }
        public int ActionTypeId { get; set; }
        public string? Role { get; set; }
        public int EntityId { get; set; }
        public string? Comments { get; set; }
        public int RequestStatusId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set;}
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public int DocumentTypeId { get; set; }
        public string? DocPath { get; set; }
        public string? FileName { get; set; }
        public char? Type { get; set; }
        public string? NameEn { get; set;}
        public string? NameAr { get; set; }
    }
}
