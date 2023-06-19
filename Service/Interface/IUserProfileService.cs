﻿using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserProfileService
    {
        List<UserProfileModel> GetAllUserFile();
        Task<bool> Add(UserProfileModel UserProfileViewModel);
        Task<UserProfileModel> GetUserProfileById(int Id);
        Task<bool> UpdateUserProfile(int Id, UserProfileModel UserProfileViewModel);
        Task<bool> DeleteUserProfile(int Id);
    }
}
