using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class MenuModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlPath { get; set; }
        public string Description { get; set; }
        public List<MenuModel>? Childrens { get;set; }
        public string Type { get; set; }
        public int Sequence { get; set; }
    }
}
