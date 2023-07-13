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
        public DelegationService(IRepository<RolePermissions> rolesPermissionRepository)
        {
            _rolesPermissionRepository = rolesPermissionRepository;
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
                Username=x.Username
            }).ToList();
            return model;
        }
    }
}
