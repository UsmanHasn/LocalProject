using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class MenuModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string UrlPath { get; set; }
        [NotMapped]
        public string Description { get; set; }
        public int ParentId { get; set; }
        [NotMapped]
        public List<MenuModel>? Childrens { get;set; }
        public string Type { get; set; }
        public int Sequence { get; set; }
        public int PageId { get; set; }
    }
}
