using Data.Interface;
using Domain.Entities;
using Domain.Entities.Lookups;
using Domain.Modeles;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Service.Concrete
{
    public class UserService : IUserService
    {
        public readonly IRepository<Users> _userRepository;
        public readonly IRepository<UserActivityInfoLog> _userRepository1;
        public readonly IRepository<UserInRole> _userRoleRepository;
        public readonly IRepository<SystemSettings> _systemSettingRepository;


        public UserService(IRepository<Users> userRepository, IRepository<UserActivityInfoLog> userRepository1, IRepository<UserInRole> userRoleRepository, IRepository<SystemSettings> systemSettingRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _userRepository1 = userRepository1;
            _systemSettingRepository = systemSettingRepository;
        }

        public List<UserListModel> GetAllUsers()
        {
            //List<UserListModel> model = new List<UserListModel>();
            //model.Add(new UserListModel()
            //{
            //    ID = 0001,
            //    Name = "Irfan",
            //    Email = "Addministrator@gmail.com",
            //    Role = "Addministrator",
            //    MobileNumber = 1234567890,
            //    CivilId = 6789,
            //    Status = "unblock"
            //});
            //model.Add(new UserListModel()
            //{
            //    ID = 0002,
            //    Name = "Muneeb",
            //    Email = "admin@admincourt.com",
            //    Role = "Admin",
            //    MobileNumber = 1234567890,
            //    CivilId = 4567,
            //    Status = "unblock"
            //});

            //model.Add(new UserListModel()
            //{
            //    ID = 0003,
            //    Name = "Owais",
            //    Email = "company@admincourt.com",
            //    Role = "Company Manager",
            //    MobileNumber = 1234567890,
            //    CivilId = 4578,
            //    Status = "unblock"
            //});
            //model.Add(new UserListModel()
            //{
            //    ID = 0004,
            //    Name = "Ammar",
            //    Email = "lawyer@admincourt.com",
            //    Role = "Lawyer",
            //    MobileNumber = 1234567890,
            //    CivilId = 4566,
            //    Status = "unblock"
            //});
            //model.Add(new UserListModel()
            //{
            //    ID = 0005,
            //    Name = "Yassen",
            //    Email = "systemadmin@admincourt.com",
            //    Role = "System Admin",
            //    MobileNumber = 1234567890,
            //    CivilId = 8766,
            //    Status = "unblock"
            //});
            //model.Add(new UserListModel()
            //{
            //    ID = 0005,
            //    Name = "Amir",
            //    Email = "legaloffice@admincourt.com",
            //    Role = "Legal Office",
            //    MobileNumber = 1234567890,
            //    CivilId = 0766,
            //    Status = "unblock"
            //});
            //model.Add(new UserListModel()
            //{
            //    ID = 0006,
            //    Name = "Yassen",
            //    Email = "legaladmin@admincourt.com",
            //    Role = "legal Admin",
            //    MobileNumber = 1234567890,
            //    CivilId = 1766,
            //    Status = "unblock"
            //});

            var dataMenu = _userRepository.ExecuteStoredProcedure<UserListModel>("sjc_GetUser");
            var model = dataMenu.Select(x => new UserListModel()
            {
                ID = x.ID,
                Name = x.Name,
                Email = x.Email,
                Role = x.Role,
                MobileNumber = x.MobileNumber,
                CivilId = x.CivilId,
                Status = x.Status,
                NameAr=x.NameAr
            }).ToList();
            return model;
        }
        public List<UserAssignRole> GetAllUserRole(int UID)
        {
            List<UserAssignRole> model = new List<UserAssignRole>();
            var dataMenu = _userRepository.ExecuteStoredProcedure<UserAssignRole>("sjc_GetUserRole", new Microsoft.Data.SqlClient.SqlParameter("UserId", UID));
            return dataMenu.ToList();

            //model.Add(new UserRole() { Role = "Admin", Description = "Policy Implementation and Compliance: Admins often play a role in implementing and enforcing organizational policies" });
            //model.Add(new UserRole() { Role = "Company Manager", Description = "Leadership and Strategic Planning: Company managers provide leadership and set strategic goals for the organization." });
            //model.Add(new UserRole() { Role = "Lawyer", Description = "The role of a lawyer encompasses a wide range of responsibilities and tasks. Here are some key aspects of a lawyer's role:" });
            //model.Add(new UserRole() { Role = "User", Description = "A user is a general role that represents individuals who utilize a system or application. Users typically have limited permissions and access rights based on their specific needs. They interact with the system to perform tasks, access information, and use the features provided." });
            //model.Add(new UserRole() { Role = "System Admin", Description = "System administrators create and manage user accounts, permissions, and access levels for employees or system users. They handle user authentication, password management, and access control to protect the organization's data and resources." });
            //model.Add(new UserRole() { Role = "Legal Office", Description = "A legal office, also known as a law office or law firm, is a professional establishment where lawyers and other legal professionals work together to provide legal services to clients." });
            //model.Add(new UserRole() { Role = "Legal Admin", Description = "A legal admin, short for legal administrator, refers to a role within a legal office or law firm that focuses on managing the administrative tasks and operations of the organization. Legal admins provide support to lawyers and other legal professionals, ensuring the smooth functioning of the office. Here are some key responsibilities and duties associated with a legal admin role" });
            //return model;
        }

        public bool Add(UserModel userModel, string userName)
        {
            // UserModel usrModel = this.checkDuplicate(userModel.CivilID, userModel.Email, userModel.Mobile);
            //if (usrModel == null)
            //{
            Users users = new Users()
            {
                Id = userModel.Id,
                UserName = userModel.Name,
                UserNameAr = userModel.NameAr,
                CivilNumber = userModel.CivilID,
                NationalityId = userModel.nationalityID,
                Email = userModel.Email,
                PhoneNumber = userModel.Mobile,
                Gender = userModel.Gender,
                PassportNumber = userModel.PassportNo,
                PassportExpiryDate = userModel.PassportExpDate,
                PassportCountryId = userModel.PassportCountryCode,
                VisaNumber = userModel.VisaNo,
                VisaExpiryDate = userModel.VisaNoExpDate,
                BuildingNumber = "22",
                WayNumber = "83884",
                TelephoneNumber = "2881038832",
                CountryId = userModel.CountryID,
                DateOfBirth = userModel.DateOfBirth,
                City = userModel.City,
                Password = userModel.Password,
                SupervisorUserId = userModel.SupervisorUserId,
                UserStatusId=1
            };

            _userRepository.Create(users, userName);
            _userRepository.Save();
            userModel.Id = users.Id;
            return true;

            // }
            //else
            //{
            //    return false;
            //}

        }

        public UserModel GetUserById(int Id)
        {
            UserModel user = new UserModel();
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("UserId", Id);
            var dataMenu = _userRepository.ExecuteStoredProcedure<UserModel>("sjc_GetUserById",Param);
            if (dataMenu.Any())
            {
                user = dataMenu.FirstOrDefault();
               // user.AssignRoleIds = GetAllUserRole(user.Id).Where(x => x.Assigned).Select(x => x.RoleId).ToList();
                return user;
            }

            return null;
        }
        public bool InsertOtp(OtpModel DATA)
        {

            UserModel user = new UserModel();
            var dataMenu = _userRepository.ExecuteStoredProcedure<object>("sp_createOTP",
                new Microsoft.Data.SqlClient.SqlParameter("otp", (int)Convert.ToInt64(DATA.OtpId.ToString())),
                 new Microsoft.Data.SqlClient.SqlParameter("typeid", DATA.OtpType)
                 , new Microsoft.Data.SqlClient.SqlParameter("userId", DATA.UserId)
                 , new Microsoft.Data.SqlClient.SqlParameter("EmailSent", DATA.EmailSent)
                 , new Microsoft.Data.SqlClient.SqlParameter("OtpExpiry", DATA.OTPExpiry)
                 );
            if (dataMenu.Any())
            {

                return true;
            }

            return false;
        }
        public bool VerifyOtp(OtpModel DATA)
        {
            int dataMenu = _userRepository.ExecuteStoredProcedure<int>("sp_VerifyOTP",
                new Microsoft.Data.SqlClient.SqlParameter("otp", (int)Convert.ToInt64(DATA.OtpId.ToString()))
                 , new Microsoft.Data.SqlClient.SqlParameter("userId", DATA.UserId)
                 , new Microsoft.Data.SqlClient.SqlParameter("OtpType", DATA.OtpType)
                 , new Microsoft.Data.SqlClient.SqlParameter("Email", DATA.Email)
                 , new Microsoft.Data.SqlClient.SqlParameter("MobileNumber", DATA.MobileNumber)
                 ).FirstOrDefault();

            return dataMenu == 1 ? true : false;
        }
        public bool UpdateUser(UserModel userModel, string userName)
        {
            Users users = new Users()
            {
                Id = userModel.Id,
                UserName = userModel.Name,
                UserNameAr = userModel.NameAr,
                CivilNumber = userModel.CivilID,
                CivilExpiryDate = userModel.CivilExpiryDate,
                NationalityId = userModel.nationalityID,
                Email = userModel.Email,
                PhoneNumber = userModel.Mobile,
                Gender = userModel.Gender,
                PassportNumber = userModel.PassportNo,
                PassportExpiryDate = userModel.PassportExpDate,
                PassportCountryId = userModel.PassportCountryCode,
                VisaNumber = userModel.VisaNo,
                VisaExpiryDate = userModel.VisaNoExpDate,
                BuildingNumber = "22",
                WayNumber = "83884",
                TelephoneNumber = "2881038832",
                CountryId = userModel.CountryID,
                DateOfBirth = userModel.DateOfBirth,
                City = userModel.City,
                Password = userModel.Password,
                CreatedBy = userModel.CreatedBy,
                SupervisorUserId = userModel.SupervisorUserId,
                CreatedDate = userModel.CreatedDate,
                UserStatusId = 1
            };
            _userRepository.Update(users, userName);
            _userRepository.Save();
            return true;
        }


        public bool UpdateUserFirstLogin(int UserId, string userName)
        {
            UserModel userModel = _userRepository.ExecuteStoredProcedure<UserModel>("sjc_GetUserById", new Microsoft.Data.SqlClient.SqlParameter("UserId", UserId)).FirstOrDefault();
            Users users = new Users()
            {
                Id = userModel.Id,
                UserName = userModel.Name,
                UserNameAr = userModel.NameAr,
                CivilNumber = userModel.CivilID,
                NationalityId = userModel.nationalityID,
                Email = userModel.Email,
                PhoneNumber = userModel.Mobile,
                Gender = userModel.Gender,
                Password = userModel.Password,
                PassportNumber = userModel.PassportNo,
                PassportExpiryDate = userModel.PassportExpDate,
                PassportCountryId = userModel.PassportCountryCode,
                VisaNumber = userModel.VisaNo,
                VisaExpiryDate = userModel.VisaNoExpDate,
                BuildingNumber = "22",
                WayNumber = "83884",
                TelephoneNumber = "2881038832",
                CountryId = userModel.CountryID,
                DateOfBirth = userModel.DateOfBirth,
                City = userModel.City,
                CreatedBy = userModel.CreatedBy,
                CreatedDate = userModel.CreatedDate,
                LastModifiedBy = userModel.Name,
                LastModifiedDate = DateTime.Now,
                LastLoginDate = DateTime.Now,
                isEmailVerified = userModel.IsEmailVerified,
                isPhoneVerified = userModel.IsPhoneVerified,
                CivilExpiryDate = userModel.CivilExpiryDate
            };
            _userRepository.Update(users, userName);
            _userRepository.Save();

            return true;
        }
        public bool UpdateLoginAttempts(int UserId)
        {
            UserModel userModel = _userRepository.ExecuteStoredProcedure<UserModel>("sjc_GetUserById", new Microsoft.Data.SqlClient.SqlParameter("UserId", UserId)).FirstOrDefault();
            Users users = new Users()
            {
                Id = userModel.Id,
                UserName = userModel.Name,
                UserNameAr = userModel.NameAr,
                CivilNumber = userModel.CivilID,
                NationalityId = userModel.nationalityID,
                Email = userModel.Email,
                PhoneNumber = userModel.Mobile,
                Gender = userModel.Gender,
                PassportNumber = userModel.PassportNo,
                PassportExpiryDate = userModel.PassportExpDate,
                PassportCountryId = userModel.PassportCountryCode,
                VisaNumber = userModel.VisaNo,
                VisaExpiryDate = userModel.VisaNoExpDate,
                BuildingNumber = "22",
                WayNumber = "83884",
                TelephoneNumber = "2881038832",
                CountryId = userModel.CountryID,
                DateOfBirth = userModel.DateOfBirth,
                City = userModel.City,
                Password = userModel.Password,
                CreatedBy = userModel.CreatedBy,
                SupervisorUserId = userModel.SupervisorUserId,
                CreatedDate = userModel.CreatedDate,
                LastLoginDate = DateTime.Now,
                WrongPassword = userModel.WrongPassword + 1
            };
            _userRepository.Update(users, userModel.Name);
            _userRepository.Save();
            return true;
        }

        public UserModel UpdateUserStatus(UserStatusModel userStatus)
        {
            UserModel user = new UserModel();
            var dataMenu = _userRepository.ExecuteStoredProcedure<UserModel>("sp_UpdateUserStatus", new Microsoft.Data.SqlClient.SqlParameter("UserId", userStatus.UserId), new Microsoft.Data.SqlClient.SqlParameter("UserStatusId", userStatus.UserStatusId));
            if (dataMenu.Any())
            {
                user = dataMenu.FirstOrDefault();
                user.AssignRoleIds = GetAllUserRole(user.Id).Where(x => x.Assigned).Select(x => x.RoleId).ToList();
                return user;
            }

            return null;

        }
        public bool AddUserInRole(List<int> roleIds, int userId, string userName)
        {
            List<UserInRole> assignedRoles = _userRoleRepository.GetAll(x => x.UserId == userId).ToList();
            if (assignedRoles.Any() && assignedRoles.Count() > 0)
            {
                List<UserInRole> deletedRoles = assignedRoles.Where(x => !roleIds.Contains(x.RoleId)).ToList();
                foreach (UserInRole userRole in deletedRoles)
                {
                    userRole.Deleted = true;
                    _userRoleRepository.Delete(userRole, userName);
                }
                foreach (int roleId in roleIds)
                {
                    var aroles = _userRoleRepository.GetAll(x => x.UserId == userId && x.RoleId == roleId).FirstOrDefault();
                    if (aroles != null)
                    {
                        aroles.Deleted = false;
                        _userRoleRepository.Update(aroles, userName);
                    }
                    else
                    {
                        UserInRole userRole = new UserInRole() { UserId = userId, RoleId = roleId };
                        _userRoleRepository.Create(userRole, userName);
                    }
                }
                _userRepository.Save();
            }
            else
            {
                foreach (int roleId in roleIds)
                {
                    UserInRole userRole = new UserInRole() { UserId = userId, RoleId = roleId };
                    _userRoleRepository.Create(userRole, userName);
                }
                _userRepository.Save();
            }

            return true;
        }

        public bool AddActivity(UserActivityInfoLogModel userModel, string userName)
        {
            UserActivityInfoLog userActivityInfoLog = new UserActivityInfoLog()
            {
                UserId = userModel.UserId,
                PageName = userModel.PageName,
                Message = userModel.Message,
                TimeLoggedIn = userModel.TimeLoggedIn,
                TimeLoggedOut = userModel.TimeLoggedOut
            };
            _userRepository1.Create(userActivityInfoLog, userName);
            _userRepository1.Save();
            return true;
        }
        public bool AddActivity(int userId, string pageName, string activity, DateTime loggedIn, string userName)
        {
            UserActivityInfoLog userActivityInfoLog = new UserActivityInfoLog()
            {
                UserId = userId,
                PageName = pageName,
                Message = activity,
                TimeLoggedIn = loggedIn,
                CreatedBy = userName,
                LastModifiedBy = userName,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            };
            _userRepository1.Create(userActivityInfoLog, userName);
            _userRepository1.Save();
            return true;
        }
        public UserActivityInfoLogModel GetActivityById(int ID)
        {
            var dataMenu = _userRepository.ExecuteStoredProcedure<UserActivityInfoLogModel>("sjc_GetUserActivityInfoLogById", new Microsoft.Data.SqlClient.SqlParameter("UserId", ID));
            return dataMenu.FirstOrDefault();
        }

        public bool UpdateUserActivity(UserActivityInfoLogModel userModel, string userName)
        {
            UserActivityInfoLog users = new UserActivityInfoLog()
            {
                UserId = userModel.UserId,
                PageName = userModel.PageName,
                Message = userModel.Message,
                TimeLoggedIn = userModel.TimeLoggedIn,
                TimeLoggedOut = userModel.TimeLoggedIn,
                LastModifiedDate = userModel.TimeLoggedIn
            };
            _userRepository1.Update(users, userName);
            _userRepository1.Save();
            return true;
        }

        public UserModel checkDuplicate(string civilNo, string email, string phone)
        {
            SqlParameter[] spParams = new SqlParameter[3];
            spParams[0] = new SqlParameter("Email", email);
            spParams[1] = new SqlParameter("CivilNumber", civilNo);
            spParams[2] = new SqlParameter("PhoneNumber", phone);
            return _systemSettingRepository.ExecuteStoredProcedure<UserModel>("Sjc_CheckDuplicate", spParams).FirstOrDefault();

        }
        public UserModel GetUserByCivilId(string civilId)
        {
            UserModel user = new UserModel();
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@CivilId", civilId);
            var dataMenu = _userRepository.ExecuteStoredProcedure<UserModel>("sjc_GetUserByCivilId", Param);
            if (dataMenu.Any())
            {
                user = dataMenu.FirstOrDefault();
                // user.AssignRoleIds = GetAllUserRole(user.Id).Where(x => x.Assigned).Select(x => x.RoleId).ToList();
                return user;
            }

            return null;
        }
        //--------------------------------------------------------------------------------------------------------------------------
        //public bool AddActivity(UserActivityLog userModel, string userName)
        //{
        //    UserActivityInfoLog users = new UserActivityInfoLog()
        //    {
        //        UserId = userModel.ID 

        //    };
        //    _userRepository.Create(users, userName);
        //    _userRepository.Save();
        //    return true;
        //}
    }
}