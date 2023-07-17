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
        bool Add(RoleModel roleViewModel,string userName);
        RoleModel GetRoleById(int Id);
        bool UpdateRole(RoleModel roleModel, string userName);
        bool DeleteRole(RoleModel roleModel, string userName);
    }
}
