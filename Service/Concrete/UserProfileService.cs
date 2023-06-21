using Data.Interface;
using Domain.Helper;
using Service.Helper;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class UserProfileService : IUserProfileService
    {
        private readonly List<UserProfileModel> _UserProfileModel = new List<UserProfileModel>();

        public Task<bool> Add(UserProfileModel UserProfileViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserProfile(int Id)
        {
            throw new NotImplementedException();
        }

        public List<UserProfileModel> GetAllUserFile()
        {
            List<UserProfileModel> model = new List<UserProfileModel>();
            model.Add(new UserProfileModel()
            {
                Id = 1,
                FirstName = "Abubaker",
                LastName = "Elzaki",
                Email = "zaki@gmail.com",
                UserUniqueId = "admin",
                Address1 = "Ghala",
                Address2 = "Muscat",
                City = "Muscat",
                SupervisorName = "1",
                Status = "Activ",
            });
            return model;
        }

        public UserProfileModel GetUserProfileById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserProfile(int Id, UserProfileModel UserProfileViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
