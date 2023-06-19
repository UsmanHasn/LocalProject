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
                Name = "Cameron Williams",
                Email = "CW@123gmail.com",
                Role = "User",
                MobileNumber = 1234567890,
                CivilId = 4567,
                Status = "Block"
            }); ;

            return model;
        }
    }
}
