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

            model.Add(new UserRole() { Role = "Admin", Description = "Policy Implementation and Compliance: Admins often play a role in implementing and enforcing organizational policies" });
            model.Add(new UserRole() { Role = "Company Manager", Description = "Leadership and Strategic Planning: Company managers provide leadership and set strategic goals for the organization." });
            model.Add(new UserRole() { Role = "Lawyer", Description = "The role of a lawyer encompasses a wide range of responsibilities and tasks. Here are some key aspects of a lawyer's role:" });
            model.Add(new UserRole() { Role = "User", Description = "A user is a general role that represents individuals who utilize a system or application. Users typically have limited permissions and access rights based on their specific needs. They interact with the system to perform tasks, access information, and use the features provided." });
            model.Add(new UserRole() { Role = "System Admin", Description = "System administrators create and manage user accounts, permissions, and access levels for employees or system users. They handle user authentication, password management, and access control to protect the organization's data and resources." });
            model.Add(new UserRole() { Role = "Legal Office", Description = "A legal office, also known as a law office or law firm, is a professional establishment where lawyers and other legal professionals work together to provide legal services to clients." });
            model.Add(new UserRole() { Role = "Legal Admin", Description = "A legal admin, short for legal administrator, refers to a role within a legal office or law firm that focuses on managing the administrative tasks and operations of the organization. Legal admins provide support to lawyers and other legal professionals, ensuring the smooth functioning of the office. Here are some key responsibilities and duties associated with a legal admin role" });
            return model;
        }
    }
}