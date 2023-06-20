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
           new UsersModel(){ Username = "admin@admincourt.com", Password = "admin", Role = "Admin"},
           new UsersModel(){ Username = "company@admincourt.com", Password = "company", Role = "Company Manager"},
           new UsersModel(){ Username = "lawyer@admincourt.com", Password = "lawyer", Role = "Lawyer"},
           new UsersModel(){ Username = "user@admincourt.com", Password = "user", Role = "User"},
           new UsersModel(){ Username = "systemadmin@admincourt.com", Password = "systemadmin", Role = "System Admin"},
           new UsersModel(){ Username = "legaloffice@admincourt.com", Password = "legaloffice", Role = "Legal Office"},
           new UsersModel(){ Username = "legaladmin@admincourt.com", Password = "legaladmin", Role = "Legal  Admin"}
        };
    }
}
