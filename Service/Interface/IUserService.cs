using Domain.Entities;
using Domain.Entities.Lookups;
using Domain.Modeles;
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
        List<UserListModel> GetAllUsers();
        //List<UserRole> GetAllUserRole();
        List<UserAssignRole> GetAllUserRole(int UID);

        bool Add(UserModel userModel, string userName);
        bool UpdateUser(UserModel userModel, string userName);
        bool UpdateUserFirstLogin(int UserId, string userName);
        bool UpdateUserLock(int UserId, string userName);
        UserModel GetUserById(int Id);

        bool AddActivity(UserActivityInfoLogModel userModel, string userName);
        bool AddActivity(int userId, string pageName, string activity, DateTime loggedIn, string userName);
        UserActivityInfoLogModel GetActivityById(int UserId);

        bool UpdateUserActivity(UserActivityInfoLogModel userModel, string userName);
        bool AddUserInRole(List<int> roleIds, int userId, string userName);

    }
}
