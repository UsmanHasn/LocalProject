using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Service.Interface;
using Service.Models;
using Data.Interface;
using System.Linq.Expressions;
using Domain.Helper;
using Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class RoleService : IRoleService
    {





        public Task<bool> Add(RoleModel roleViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<RoleModel> GetRoleById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRole(int Id, RoleModel roleViewModel)
        {
            throw new NotImplementedException();
        }

        List<RoleModel> IRoleService.GetAllRole()
        {
            List<RoleModel> model = new List<RoleModel>();
            model.Add(new RoleModel()
            {
                Id = 1,
                Name = "Admin",
                Description = "Description of One",
            });
            model.Add(new RoleModel()
            {
                Id = 2,
                Name = "Super Admin",
                Description = "Description of Two",
            });
            model.Add(new RoleModel()
            {
                Id = 3,
                Name = "NUser",
                Description = "Description of Three",
            });
            model.Add(new RoleModel()
            {
                Id = 4,
                Name = "Admin",
                Description = "Description of Foure",
            });
            return model;
        }
    }

}