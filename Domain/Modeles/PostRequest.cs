using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Modeles
{
    public class PostRequest
    {
        public int UserId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public string? FilePath { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? FileName { get; set; }
        public IFormFile Image { get; set; }
     
      



    } 
}
