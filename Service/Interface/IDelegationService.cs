﻿using Domain.Entities;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IDelegationService
    {
        List<DelegationModel> GetAllDelegations(string civilId);

        bool Add(DelegationModel delegationModel, string userName);
        List<DelegationModel> GetDelegatedUserPermission(int civilNo, int roleId, int delegatedUserId);
        bool AddUserDelegate(UserDelegatePermissionModel assignRole, string userName);
        bool UpdateUserDelegate(UserDelegatePermissionModel assignRole, string userName);
        UserDelegatePermissionModel GetUserPermissionById(int Id);

    }
}
