using Data.Interface;
using Domain.Entities;
using Microsoft.Data.SqlClient;
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
        private readonly IRepository<RolePermissions> _rolesPermissionRepository;
        
        public PermissionService(IRepository<RolePermissions> rolesPermissionRepository)
        {
            _rolesPermissionRepository = rolesPermissionRepository;
        }

        public bool Add(AssignRole assignRole, string userName)
        {
            RolePermissions role = new RolePermissions()
            {
                PageId = assignRole.pageId,
                RoleId=assignRole.roleId,
                ReadPermission=assignRole.ReadPermission,
                WritePermission=assignRole.WritePermission,
                DeletePermission=assignRole.DeletePermission

            };
            _rolesPermissionRepository.Create(role, userName);
            _rolesPermissionRepository.Save();
            return true;
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

        public List<AssignRole> GetAssignRoles(string roleId)
        {
            var dataMenu = _rolesPermissionRepository.ExecuteStoredProcedure<AssignRole>("sjc_GetPagesforAssign", new Microsoft.Data.SqlClient.SqlParameter("RoleId", roleId));
            var model = dataMenu.Select(x => new AssignRole()
            {
                pageId = x.pageId,
                PageNameEn = x.PageNameEn,
                pageNameAr = x.pageNameAr,
                pageModuleEn=x.pageModuleEn,
                pageModuleAr = x.pageModuleAr,
                ReadPermission = x.ReadPermission,
                WritePermission=x.WritePermission,
                DeletePermission=x.DeletePermission,
                roleId= Convert.ToInt32(roleId),
                RolePermissionId = x.RolePermissionId

            }).ToList();
            return model;
        }

        public AssignRole GetPermissionById(int Id)
        {
            var dataMenu = _rolesPermissionRepository.ExecuteStoredProcedure<AssignRole>("sjc_GetRolePermissionsById", new Microsoft.Data.SqlClient.SqlParameter("RolePermissionId", Id));
            return dataMenu.FirstOrDefault();
        }

        public bool UpdatePermission(AssignRole assignRole, string userName)
        {
            RolePermissions role = new RolePermissions()
            {
                Id=assignRole.RolePermissionId,
                PageId = assignRole.pageId,
                RoleId = assignRole.roleId,
                ReadPermission = assignRole.ReadPermission,
                WritePermission = assignRole.WritePermission,
                DeletePermission = assignRole.DeletePermission,
                CreatedBy = assignRole.CreatedBy,
                CreatedDate = assignRole.CreatedDate
            };
            _rolesPermissionRepository.Update(role, userName);
            _rolesPermissionRepository.Save();
            return true;
        }
        public bool AddUpdRolePermission(List<AssignRole> rolePermissions, string userName)
        {
            try
            {
                SqlParameter[] spParams = new SqlParameter[2];
                spParams[0] = new SqlParameter("@RolePermissions", rolePermissions);
                spParams[1] = new SqlParameter("@UserName", userName);
                _rolesPermissionRepository.ExecuteStoredProcedure("sp_dml_rolePermissions", spParams);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
       
    }
}
