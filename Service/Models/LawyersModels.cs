using MimeKit.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class LawyersModels
    {
        public int LawyerId { get; set; }
        public string? CivilNO { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? ClassName { get; set; }
        public string? AddressRegion { get; set; }
        public string? AddressState { get; set; }
        public string? RegistrtionNO { get; set; }
        public string? Status { get; set; }
        public string? WorkPlaceCode { get; set; }
        public string? WorkPlace { get; set; }
        public string? WorkPlaceEmail { get; set; }
        public string? WorkPlaceRegion { get; set; }
        public string? WorkPlaceState { get; set; }
    }
}
