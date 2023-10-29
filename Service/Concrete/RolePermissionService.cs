using Data.Interface;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IRepository<SEC_RolePermissions> _rolePermissionRepository;

        public RolePermissionService(IRepository<SEC_RolePermissions> rolePermissionRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
        }

        public bool AddRolePermission(RolePermissionModel rolePermissionModel, string userName)
        {
            SEC_RolePermissions rolePermissions = new SEC_RolePermissions()
            {
                RoleId = rolePermissionModel.RoleId,
                PageId = rolePermissionModel.PageId,
                ReadPermission = rolePermissionModel.ReadPermission,
                WritePermission = rolePermissionModel.WritePermission,
                DeletePermission = rolePermissionModel.DeletePermission,
            };
            _rolePermissionRepository.Create(rolePermissions, userName);
            _rolePermissionRepository.Save();
            return true;
        }

        public bool DeleteRolePermission(int id, string userName)
        {
            try
            {
                RolePermissionModel rolePermissionModel = this.GetRolePermissionById(id);
                SEC_RolePermissions rolePermissions = new SEC_RolePermissions()
                {
                    RoleId = rolePermissionModel.RoleId,
                    PageId = rolePermissionModel.PageId,
                    ReadPermission = rolePermissionModel.ReadPermission,
                    WritePermission = rolePermissionModel.WritePermission,
                    DeletePermission = rolePermissionModel.DeletePermission,
                    CreatedBy = rolePermissionModel.CreatedBy,
                    CreatedDate = rolePermissionModel.CreatedDate,
                    Id = id,
                    Deleted = true
                };
                _rolePermissionRepository.Update(rolePermissions, userName);
                _rolePermissionRepository.Save();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public RolePermissionModel GetRolePermissionById(int id)
        {
            SqlParameter[] parameter = new SqlParameter[0];
            parameter[0] = new SqlParameter("rolepermissionid", id);
            return _rolePermissionRepository.ExecuteStoredProcedure<RolePermissionModel>("sjc_GetRolePermission", parameter).FirstOrDefault();
        }

        public List<RolePermissionModel> GetAllRolePermissions()
        {
            SqlParameter[] parameter = new SqlParameter[0];
            return _rolePermissionRepository.ExecuteStoredProcedure<RolePermissionModel>("sjc_GetRolePermission", parameter).ToList();

        }

        public bool UpdateRolePermission(RolePermissionModel rolePermissionModel, string userName)
        {
            try
            {
                SEC_RolePermissions rolePermissions = new SEC_RolePermissions()
                {
                    RoleId = rolePermissionModel.RoleId,
                    PageId = rolePermissionModel.PageId,
                    ReadPermission = rolePermissionModel.ReadPermission,
                    WritePermission = rolePermissionModel.WritePermission,
                    DeletePermission = rolePermissionModel.DeletePermission,
                    CreatedBy = rolePermissionModel.CreatedBy,
                    CreatedDate = rolePermissionModel.CreatedDate,
                    Id = rolePermissionModel.Id,
                };
                _rolePermissionRepository.Update(rolePermissions, userName);
                _rolePermissionRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
