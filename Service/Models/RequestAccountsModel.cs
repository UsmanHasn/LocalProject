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
        public string? RoleNameEn { get; set; }
        public string? RoleNameAr { get;set; }
        public int EntityId { get; set; }
        public string? EntityNameEn { get; set; }
        public string? EntityNameAr { get; set; }
        public string? Comments { get; set; }
        public int RequestStatusId { get; set; }
        public int ResponseStatusId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set;}
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int UserId { get; set; }
        public int DocumentTypeId { get; set; }
        public string? DocPath { get; set; }
        public string? FileName { get; set; }
        public char? Type { get; set; }
        public string? NameEn { get; set;}
        public string? NameAr { get; set; }

        public string? RequestStatusNameEn { get; set; }
        public string? RequestStatusNameAr { get; set; }
    }
}
