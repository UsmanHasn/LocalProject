using Domain.Entities;
using Domain.Entities.Lookups;
using Domain.Modeles;
using Microsoft.Data.SqlClient;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService
    {
        List<UserListModel> GetAllUsers(int userId);
        List<UserAssignRole> GetAllUserRole(int UID);

        bool Add(UserModel userModel, string userName);
        bool UpdateUser(UserModel userModel, string userName);
        bool UpdateUserFirstLogin(int UserId, string userName);
        bool UpdateLoginAttempts(int UserId);
        UserModel GetUserById(int Id);
        bool InsertOtp(OtpModel Data);
        bool VerifyOtp(OtpModel Data);
        public UserModel checkDuplicate(string civilNo,string email,string phone);
        
        bool AddActivity(UserActivityInfoLogModel userModel, string userName);
        bool AddActivity(int userId, string pageName, string activity, DateTime loggedIn, string userName);
        UserModel UpdateUserStatus(UserStatusModel model);
        UserActivityInfoLogModel GetActivityById(int UserId);

        bool UpdateUserActivity(UserActivityInfoLogModel userModel, string userName);
        bool AddUserInRole(List<int> roleIds, int userId, string userName);
        UserModel GetUserByCivilId(string civilId);


        void InsertrevokedTokenModel(RevokedTokenModel revokedToken);
        void UpdaterevokedTokenModel(RevokedTokenModel revokedToken);
        RevokedTokenModel GetrevokedTokenModel(string? CivilID, string? Token);
    }
}
