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
    public class ServicesService : IService
    {
        private readonly IRepository<SystemSettings> _systemSettingRepository;

        public ServicesService(IRepository<SystemSettings> systemSettingRepository)
        {
            _systemSettingRepository = systemSettingRepository;
        }

        public bool AddService(ServicesModel services, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[13];
            spParams[0] = new SqlParameter("ServiceId", services.ServiceId);
            spParams[1] = new SqlParameter("ServiceSubCategoryId", services.SubCategoryId);
            spParams[2] = new SqlParameter("Name", services.ServiceNameEn);
            spParams[3] = new SqlParameter("NameAr", services.ServiceNameAr);
            spParams[4] = new SqlParameter("Sequence", services.Sequence);
            spParams[5] = new SqlParameter("IsActive", false);
            spParams[6] = new SqlParameter("ImagePath", services.ImagePath);
            spParams[7] = new SqlParameter("Description", services.ServiceDescEn);
            spParams[8] = new SqlParameter("DescriptionAr", services.ServiceDescAr);
            spParams[9] = new SqlParameter("CreatedBy", userName);
            spParams[10] = new SqlParameter("LastModifiedBy", userName);
            spParams[11] = new SqlParameter("Deleted", false);
            spParams[12] = new SqlParameter("DML", "I");
            _systemSettingRepository.ExecuteStoredProcedure("Sp_dml_services", spParams);
            return true;
        }

        public List<ServicesSubCategoryModel> BindSubCategory()
        {
            SqlParameter[] spParams = new SqlParameter[0];
            // List<UserModel> model = new List<UserModel>();
            var model = _systemSettingRepository.ExecuteStoredProcedure<ServicesSubCategoryModel>("sjc_GetServicesSubCategory", spParams).ToList();
            var data = model.Select(x => new ServicesSubCategoryModel()
            {
                ServiceSubCategoryId = x.ServiceSubCategoryId,
                NameEn = x.NameEn,
            }).ToList();
            return data;
        }

        public List<ServicesModel> GetAllService()
        {
            SqlParameter[] spParams = new SqlParameter[0];
            //spParams[0] = new SqlParameter("ServiceId", null);
            var model = _systemSettingRepository.ExecuteStoredProcedure<ServicesModel>("sjc_GetService", spParams).ToList();
            return model;
        }

        public Task<List<Services>> GetAllServices()
        {
            throw new NotImplementedException();
        }

        public ServicesModel GetDataById(int id)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("ServiceId", id);
            var model = _systemSettingRepository.ExecuteStoredProcedure<ServicesModel>("sjc_GetService", spParams).FirstOrDefault();
            return model;
        }

        public bool UpdateService(int id, ServicesModel services, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[13];
            spParams[0] = new SqlParameter("ServiceId", services.ServiceId);
            spParams[1] = new SqlParameter("ServiceSubCategoryId", services.SubCategoryId);
            spParams[2] = new SqlParameter("Name", services.ServiceNameEn);
            spParams[3] = new SqlParameter("NameAr", services.ServiceNameAr);
            spParams[4] = new SqlParameter("Sequence", services.Sequence);
            spParams[5] = new SqlParameter("IsActive", false);
            spParams[6] = new SqlParameter("ImagePath", services.ImagePath);
            spParams[7] = new SqlParameter("Description", services.ServiceDescEn);
            spParams[8] = new SqlParameter("DescriptionAr", services.ServiceDescAr);
            spParams[9] = new SqlParameter("CreatedBy", userName);
            spParams[10] = new SqlParameter("LastModifiedBy", userName);
            spParams[11] = new SqlParameter("Deleted", false);
            spParams[12] = new SqlParameter("DML", "U");
            _systemSettingRepository.ExecuteStoredProcedure("Sp_dml_services", spParams);
            return true;
        }
    }
}
