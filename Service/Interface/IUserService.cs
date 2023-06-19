﻿using Service.Models;
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
        List<UserRole> GetAllUserRole();
    }
}
