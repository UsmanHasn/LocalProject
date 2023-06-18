using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Helper
{
    public static class SjdcConstants
    {
        public static List<UsersModel> Users = new()
            {
                    new UsersModel(){ Username="abubaker",Password="123",Role="Admin"}
            };
    }
}
