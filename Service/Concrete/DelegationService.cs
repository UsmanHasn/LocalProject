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
    public class DelegationService : IDelegationService
    {
        private readonly IRepository<RolePermissions> _rolesPermissionRepository;
        private readonly IRepository<UserDelegatedPermissions> _userPermissionRepository;
        public DelegationService(IRepository<RolePermissions> rolesPermissionRepository, IRepository<UserDelegatedPermissions> userPermissionRepository)
        {
            _rolesPermissionRepository = rolesPermissionRepository;
            _userPermissionRepository = userPermissionRepository;
        }

        public bool Add(DelegationModel delegationModel, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[9];
            spParams[0] = new SqlParameter("DeletePermission", delegationModel.DeletePermission);
            spParams[1] = new SqlParameter("ReadPermission", delegationModel.ReadPermission);
            spParams[2] = new SqlParameter("WritePermission", delegationModel.WritePermission);
            spParams[3] = new SqlParameter("UserPermissionId", delegationModel.userPermissionId);
            spParams[4] = new SqlParameter("UserId", delegationModel.userId);
            spParams[5] = new SqlParameter("CreatedBy", userName);
            spParams[6] = new SqlParameter("PageId", delegationModel.pageId);
            spParams[7] = new SqlParameter("Deleted", false);
            spParams[8] = new SqlParameter("DelegatedByUserId", delegationModel.DelegatedByUserId);

            _rolesPermissionRepository.ExecuteStoredProcedure("Sp_dml_userpermissions", spParams);
            return true;
        }

        public List<DelegationModel> GetAllDelegations(string civilId)
        {
            var dataMenu = _rolesPermissionRepository.ExecuteStoredProcedure<DelegationModel>("sjc_GetPagesforAssignUser", new Microsoft.Data.SqlClient.SqlParameter("CivilId", civilId));
            var model = dataMenu.Select(x => new DelegationModel()
            {
                pageId = x.pageId,
                PageNameEn = x.PageNameEn,
                pageNameAr = x.pageNameAr,
                pageModuleEn = x.pageModuleEn,
                ReadPermission = x.ReadPermission,
                WritePermission = x.WritePermission,
                DeletePermission = x.DeletePermission,
                userId = x.userId,
                UsernameEn=x.UsernameEn
            }).ToList();
            return model;
        }
        public List<DelegationModel> GetDelegatedUserPermission(int civilNo, int roleId, int delegatedUserId)
        {
            SqlParameter[] spParams = new SqlParameter[3];
            spParams[0] = new SqlParameter("CivilNo", civilNo);
            spParams[1] = new SqlParameter("RoleId", roleId);
            spParams[2] = new SqlParameter("DelegatedUserId", delegatedUserId);
            var dataMenu = _rolesPermissionRepository.ExecuteStoredProcedure<DelegationModel>("sp_GetUserDelegatedPermission", spParams);
            var model = dataMenu.Select(x => new DelegationModel()
            {
                userPermissionId = x.userPermissionId,
                DelegatedByUserId = x.DelegatedByUserId,
                pageModuleAr = x.pageModuleAr,
                UsernameAr = x.UsernameAr,
                pageId = x.pageId,
                PageNameEn = x.PageNameEn,
                pageNameAr = x.pageNameAr,
                pageModuleEn = x.pageModuleEn,
                ReadPermission = x.ReadPermission,
                WritePermission = x.WritePermission,
                DeletePermission = x.DeletePermission,
                userId = x.userId,
                UsernameEn = x.UsernameEn
            }).ToList();
            return model;
        }
        public bool AddUserDelegate(UserDelegatePermissionModel assignRole, string userName)
        {
            UserDelegatedPermissions userDelegatedPermissions = new UserDelegatedPermissions()
            {
                PageId = assignRole.PageId,
                UserId = assignRole.UserId,
                ReadPermission = assignRole.ReadPermission,
                WritePermission = assignRole.WritePermission,
                DeletePermission = assignRole.DeletePermission,
                DelegatedByUserId = assignRole.DelegatedUserId

            };
            _userPermissionRepository.Create(userDelegatedPermissions, userName);
            _userPermissionRepository.Save();
            return true;
        }
        public bool UpdateUserDelegate(UserDelegatePermissionModel assignRole, string userName)
        {
            UserDelegatedPermissions userDelegatedPermissions = new UserDelegatedPermissions()
            {
                Id = assignRole.UserPermissionId,
                PageId = assignRole.PageId,
                UserId = assignRole.UserId,
                DelegatedByUserId = assignRole.DelegatedUserId,
                ReadPermission = assignRole.ReadPermission,
                WritePermission = assignRole.WritePermission,
                DeletePermission = assignRole.DeletePermission,
                CreatedBy = assignRole.CreatedBy,
                CreatedDate = assignRole.CreatedDate
            };
            _userPermissionRepository.Update(userDelegatedPermissions, userName);
            _userPermissionRepository.Save();
            return true;
        }
        public UserDelegatePermissionModel GetUserPermissionById(int Id)
        {
            var dataMenu = _userPermissionRepository.GetSingle(x => x.Id == Id);
            UserDelegatePermissionModel userDelegatePermissionModel = new UserDelegatePermissionModel() {
                UserPermissionId = dataMenu.Id,
                PageId = dataMenu.PageId,
                UserId = dataMenu.UserId,
                DelegatedUserId = dataMenu.DelegatedByUserId,
                ReadPermission = dataMenu.ReadPermission,
                WritePermission = dataMenu.WritePermission,
                DeletePermission = dataMenu.DeletePermission,
                CreatedBy = dataMenu.CreatedBy,
                CreatedDate = dataMenu.CreatedDate.Value
            };
            return userDelegatePermissionModel;
        }
       
    }
}
