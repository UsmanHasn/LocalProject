using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRolePermissionService
    {
        List<RolePermissionModel> GetAllRolePermissions();

        bool AddRolePermission(RolePermissionModel rolePermissionModel,string userName);
        RolePermissionModel GetRolePermissionById(int id);
        bool UpdateRolePermission(RolePermissionModel rolePermissionModel, string userName);
        bool DeleteRolePermission(int id,string userName);

    }
}
