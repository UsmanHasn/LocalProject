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
           new UsersModel(){CivilID="0001", Email = "admin@admincourt.com",  Username = "Admin", Password = "admin", Role = "Admin", MobileNo = "98123456"},
           new UsersModel(){CivilID="0002", Email = "company@admincourt.com",  Username = "Company Manager", Password = "company", Role = "Company Manager", MobileNo = "98654321"},
           new UsersModel(){CivilID="0003", Email = "lawyer@admincourt.com",  Username = "Lawyer", Password = "lawyer", Role = "Lawyer", MobileNo = "98121314"},
           new UsersModel(){CivilID="0004", Email = "user@admincourt.com",  Username = "User", Password = "user", Role = "User", MobileNo = "98001122"},
           new UsersModel(){CivilID="0005", Email = "systemadmin@admincourt.com", Username = "System Admin", Password = "systemadmin", Role = "System Admin", MobileNo = "98003344"},
           new UsersModel(){CivilID="0006", Email = "legaloffice@admincourt.com", Username = "Legal Office", Password = "legaloffice", Role = "Legal Office", MobileNo = "98445566"},
           new UsersModel(){CivilID="0007", Email = "legaladmin@admincourt.com",  Username = "Legal Admin", Password = "legaladmin", Role = "Legal  Admin", MobileNo = "98405060"}
        };
    }
}
