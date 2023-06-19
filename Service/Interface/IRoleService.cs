using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRoleService
    {
        List<RoleModel> GetAllRole();
        Task<bool> Add(RoleModel roleViewModel);
        Task<RoleModel> GetRoleById(int Id);
        Task<bool> UpdateRole(int Id, RoleModel roleViewModel);
        Task<bool> DeleteUser(int Id);
    }
}
