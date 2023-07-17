using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IPermissionService
    {
        List<PermissionModel> GetAllPermission();
       bool Add(AssignRole assignRole, string userName);
        AssignRole GetPermissionById(int Id);
        bool UpdatePermission(AssignRole assignRole, string userName);
        Task<bool> DeletePermission(int Id);

        List<AssignRole> GetAssignRoles(string roleId);
        bool AddUpdRolePermission(List<AssignRole> rolePermissions, string userName);
    }
}
