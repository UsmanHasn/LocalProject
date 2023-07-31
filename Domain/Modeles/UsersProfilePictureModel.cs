using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeles
{
    public class UsersProfilePictureModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CreatedBy { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string FilePath { get; set; }
       
    }
}
