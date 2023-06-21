using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class UserService : IUserService
    {
       public List<UserListModel> GetAllUsers()
        {
            List<UserListModel> model = new List<UserListModel>();
            model.Add(new UserListModel()
            {
                ID = 0001,
                Name = "Irfan",
                Email = "Addministrator@gmail.com",
                Role = "Addministrator",
                MobileNumber =1234567890,
                CivilId = 6789,
                Status = "unblock"
            });
            model.Add(new UserListModel()
            {
                ID = 0002,
                Name = "Muneeb",
                Email = "admin@admincourt.com",
                Role = "Admin",
                MobileNumber = 1234567890,
                CivilId = 4567,
                Status = "unblock"
            });
            
            model.Add(new UserListModel()
            {
                ID = 0003,
                Name = "Owais",
                Email = "company@admincourt.com",
                Role = "Company Manager",
                MobileNumber = 1234567890,
                CivilId = 4578,
                Status = "unblock"
            });
            model.Add(new UserListModel()
            {
                ID = 0004,
                Name = "Ammar",
                Email = "lawyer@admincourt.com",
                Role = "Lawyer",
                MobileNumber = 1234567890,
                CivilId = 4566,
                Status = "unblock"
            });
            model.Add(new UserListModel()
            {
                ID = 0005,
                Name = "Yassen",
                Email = "systemadmin@admincourt.com",
                Role = "System Admin",
                MobileNumber = 1234567890,
                CivilId = 8766,
                Status = "unblock"
            });
            model.Add(new UserListModel()
            {
                ID = 0005,
                Name = "Amir",
                Email = "legaloffice@admincourt.com",
                Role = "Legal Office",
                MobileNumber = 1234567890,
                CivilId = 0766,
                Status = "unblock"
            });
            model.Add(new UserListModel()
            {
                ID = 0006,
                Name = "Yassen",
                Email = "legaladmin@admincourt.com",
                Role = "legal Admin",
                MobileNumber = 1234567890,
                CivilId = 1766,
                Status = "unblock"
            });
            return model;
        }
            public List<UserRole> GetAllUserRole()
        {
            List<UserRole> model = new List<UserRole>();

            model.Add(new UserRole()
            {
                Role = "Addministrator",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,\t\r\n"

            });

            model.Add(new UserRole()
            {
                Role = "Customer Role\t",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,\t\r\n"

            });
            model.Add(new UserRole()
            {
                Role = "Guest / Visitor\t",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,\t\r\n"

            });
            return model;
        }
    }
}
