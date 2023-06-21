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
           new UsersModel(){ Username = "admin@admincourt.com", Password = "admin", Role = "Admin", MobileNo = "98123456"},
           new UsersModel(){ Username = "company@admincourt.com", Password = "company", Role = "Company Manager", MobileNo = "98654321"},
           new UsersModel(){ Username = "lawyer@admincourt.com", Password = "lawyer", Role = "Lawyer", MobileNo = "98121314"},
           new UsersModel(){ Username = "user@admincourt.com", Password = "user", Role = "User", MobileNo = "98001122"},
           new UsersModel(){ Username = "systemadmin@admincourt.com", Password = "systemadmin", Role = "System Admin", MobileNo = "98003344"},
           new UsersModel(){ Username = "legaloffice@admincourt.com", Password = "legaloffice", Role = "Legal Office", MobileNo = "98445566"},
           new UsersModel(){ Username = "legaladmin@admincourt.com", Password = "legaladmin", Role = "Legal  Admin", MobileNo = "98405060"}
        };
    }
}
