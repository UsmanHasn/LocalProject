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
        Task<bool> Add(PermissionModel permissionViewModel);
        Task<PermissionModel> GetPermissionById(int Id);
        Task<bool> UpdatePermission(int Id, PermissionModel permissionViewModel);
        Task<bool> DeletePermission(int Id);
    }
}
