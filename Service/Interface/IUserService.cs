using Domain.Entities.Lookups;
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
        UserModel GetUserById(int Id);
        bool AddUserInRole(List<int> roleIds, int userId, string userName);

    }
}
