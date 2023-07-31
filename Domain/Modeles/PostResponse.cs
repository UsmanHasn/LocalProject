using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeles
{
    public class PostResponse : BaseResponse
    {
        public UsersProfilePictureModel Post { get; set; }
    }
}
