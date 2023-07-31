using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UsersProfilePicture
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }
        public string FilePath { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate {get; set;}
        public string Deleted { get; set; }
        ///////////////////////////////
        ///

        public byte[] FileContent { get; set; }
        public string ContentLength { get; set; }
        public string FileName { get; set; }
        public FileType FileExt { get; set; }

    }
}
