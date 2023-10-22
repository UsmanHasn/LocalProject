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
        private readonly IRepository<SEC_Roles> _rolesRepository;
        public RoleService(IRepository<SEC_Roles> repository)
        {
            _rolesRepository = repository;
        }
        public int Add(RoleModel roleModel, string userName)
        {
            SEC_Roles role = new SEC_Roles()
            {
                Id = roleModel.Id,
                Name = roleModel.Name,
                NameAr = roleModel.NameAr,
                Description = roleModel.Description,
                DescriptionAr = roleModel.DescriptionAr
            };
            _rolesRepository.Create(role, userName);
            _rolesRepository.Save();
            return role.Id;
        }

        public bool DeleteRole(RoleModel roleModel, string userName)
        {
            SEC_Roles role = new SEC_Roles()
            {
                Id = roleModel.Id,
                Name = roleModel.Name,
                NameAr = roleModel.NameAr,
                Description = roleModel.Description,
                DescriptionAr = roleModel.DescriptionAr,
                CreatedBy = roleModel.CreatedBy,
                CreatedDate = roleModel.CreatedDate,
                Deleted = true
            };
            _rolesRepository.Delete(role, userName);
            _rolesRepository.Save();
            return true;
        }

        public RoleModel GetRoleById(int Id)
        {
            var dataMenu = _rolesRepository.ExecuteStoredProcedure<RoleModel>("sjc_GetRoleById", new Microsoft.Data.SqlClient.SqlParameter("RoleId", Id));
            return dataMenu.FirstOrDefault();
        }

        public bool UpdateRole(RoleModel roleModel, string userName)
        {
            SEC_Roles role = new SEC_Roles()
            {
                Id = roleModel.Id,
                Name = roleModel.Name,
                NameAr = roleModel.NameAr,
                Description = roleModel.Description,
                DescriptionAr = roleModel.DescriptionAr,
                CreatedBy=roleModel.CreatedBy,
                CreatedDate=roleModel.CreatedDate
            };
            _rolesRepository.Update(role, userName);
            _rolesRepository.Save();
            return true;
        }

        List<RoleModel> IRoleService.GetAllRole()
        {
            // List<RoleModel> model = new List<RoleModel>();
            //model.Add(new RoleModel()
            //{
            //    Id = 1,
            //    Name = "Admin",
            //    Description = "Description of One",
            //});
            //model.Add(new RoleModel()
            //{
            //    Id = 2,
            //    Name = "Super Admin",
            //    Description = "Description of Two",
            //});
            //model.Add(new RoleModel()
            //{
            //    Id = 3,
            //    Name = "NUser",
            //    Description = "Description of Three",
            //});
            //model.Add(new RoleModel()
            //{
            //    Id = 4,
            //    Name = "Admin",
            //    Description = "Description of Foure",
            //});

            var dataMenu = _rolesRepository.ExecuteStoredProcedure<RoleModel>("sjc_GetRole");
            var model = dataMenu.Select(x => new RoleModel()
            {
                Id = x.Id,
                Name = x.Name,
                NameAr = x.NameAr,
                Description = x.Description,
                DescriptionAr = x.DescriptionAr
            }).ToList();
            return model;
        }
    }

}