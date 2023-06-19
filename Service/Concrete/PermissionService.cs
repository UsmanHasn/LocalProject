using Data.Interface;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class PermissionService : IPermissionService
    {


        public Task<bool> Add(PermissionModel permissionViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePermission(int Id)
        {
            throw new NotImplementedException();
        }

        public List<PermissionModel> GetAllPermission()
        {
            List<PermissionModel> model = new List<PermissionModel>();
            model.Add(new PermissionModel()
            {
                Id = 1,
                Name = "Insert",
                RoleId = 1,
            });
            model.Add(new PermissionModel()
            {
                Id = 2,
                Name = "Save",
                RoleId = 1,
            });
            model.Add(new PermissionModel()
            {
                Id = 3,
                Name = "Update",
                RoleId = 1,
            });
            model.Add(new PermissionModel()
            {
                Id = 4,
                Name = "Delete",
                RoleId = 1,
            });
            return model;
        }

        public Task<PermissionModel> GetPermissionById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePermission(int Id, PermissionModel permissionViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
