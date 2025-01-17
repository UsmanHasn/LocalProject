﻿using Data.Context;
using Data.Interface;
using Domain.Entities;
using Domain.Entities.Lookups;
using Domain.Modeles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Service.Helper;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class ServiceSubCategoryLookupService : IServiceSubCategoryLookupService
    {

        private readonly IRepository<SYS_ServiceSubCategory> _rolesRepository;
        private readonly ApplicationDbContext dbContextClass;
        public readonly IRepository<SYS_Services> _userRepository;

        public ServiceSubCategoryLookupService(IRepository<SYS_ServiceSubCategory> repository, ApplicationDbContext dbContextClass)
        {
            _rolesRepository = repository;
            this.dbContextClass = dbContextClass;
        }
       

        public List<Models.ServiceCategoryLookup> GetAllServiceLookup()
        {
            var dataMenu = _rolesRepository.ExecuteStoredProcedure<Models.ServiceCategoryLookup>("sjc_GetServiceSubCategoryLookup");
            var model = dataMenu.Select(x => new Models.ServiceCategoryLookup()
            {
                ServiceSubCategoryId = x.ServiceSubCategoryId,
                Name = x.Name,
                NameAr = x.NameAr,
                ServiceCategoryId = x.ServiceCategoryId

            }).ToList();
            return model;
        }

     

        List<ServiceSubCategoryLookupModel> IServiceSubCategoryLookupService.GetAllSubService()
        {
    

            var dataMenu = _rolesRepository.ExecuteStoredProcedure<ServiceSubCategoryLookupModel>("sjc_GetServicesSubCategory");
            var model = dataMenu.Select(x => new ServiceSubCategoryLookupModel()
            {
                Id = x.Id,    
                NameEn = x.NameEn,
                NameAr = x.NameAr,
                CategoryId = x.CategoryId
               
            }).ToList();
            return model;
        }
        public List<Domain.Modeles.ServicesModel> GetAllServices()
        {
            var dataMenu = _rolesRepository.ExecuteStoredProcedure<Domain.Modeles.ServicesModel>("sjc_GetService");
            var model = dataMenu.Select(x => new Domain.Modeles.ServicesModel()
            {
                ServiceId = x.ServiceId,
                Name = x.Name,
                NameAr = x.NameAr,
                ServiceSubCategoryId = x.ServiceSubCategoryId

            }).ToList();
            return model;
        }

        List<Domain.Entities.SYS_ServiceCategory> IServiceSubCategoryLookupService.GetAllServiceLookup()
        {
            throw new NotImplementedException();
        }
        ////////////////////////////
        ///

        public bool Add(Domain.Modeles.ServicesModel userModel, string userName)
        {
            SYS_Services users = new SYS_Services()
            {
                Name = userModel.Name,
                NameAr = userModel.NameAr,
            
            };
            _userRepository.Create(users, userName);
            _userRepository.Save();
            return true;
        }

        public bool AddServiceSubCat(ServiceSubCategoryLookupModel model, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[9];
            spParams[0] = new SqlParameter("ServiceSubCategoryId", model.Id);
            spParams[1] = new SqlParameter("ServiceCategoryId", model.CategoryId);
            spParams[2] = new SqlParameter("Name", model.NameEn);
            spParams[3] = new SqlParameter("NameAr", model.NameAr);
            spParams[4] = new SqlParameter("ImagePath", model.ImagePath);
            spParams[5] = new SqlParameter("CreatedBy", userName);
            spParams[6] = new SqlParameter("LastModifiedBy", userName);
            spParams[7] = new SqlParameter("Deleted", false);
            spParams[8] = new SqlParameter("DML", "I");
            _rolesRepository.ExecuteStoredProcedure("Sp_dml_servicesubcategory", spParams);
            return true;
        }

        public bool UpdateServiceSubCat(int id,ServiceSubCategoryLookupModel model, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[9];
            spParams[0] = new SqlParameter("ServiceSubCategoryId", model.Id);
            spParams[1] = new SqlParameter("ServiceCategoryId", model.CategoryId);
            spParams[2] = new SqlParameter("Name", model.NameEn);
            spParams[3] = new SqlParameter("NameAr", model.NameAr);
            spParams[4] = new SqlParameter("ImagePath", model.ImagePath);
            spParams[5] = new SqlParameter("CreatedBy", userName);
            spParams[6] = new SqlParameter("LastModifiedBy", userName);
            spParams[7] = new SqlParameter("Deleted", false);
            spParams[8] = new SqlParameter("DML", "U");
            _rolesRepository.ExecuteStoredProcedure("Sp_dml_servicesubcategory", spParams);
            return true;
        }

        public List<Models.ServiceCategoryLookup> BindServiceCategory()
        {
            SqlParameter[] spParams = new SqlParameter[0];
            // List<UserModel> model = new List<UserModel>();
            var model = _rolesRepository.ExecuteStoredProcedure<Models.ServiceCategoryLookup>("sjc_GetServiceCategoryLookup", spParams).ToList();
            var data = model.Select(x => new Models.ServiceCategoryLookup()
            {
                ServiceCategoryId = x.ServiceCategoryId,
                Name = x.Name,
            }).ToList();
            return data;
        }

        public Models.ServiceSubCategoryLookupModel GetDataById(int id)
        {
           
                SqlParameter[] spParams = new SqlParameter[1];
                spParams[0] = new SqlParameter("Id", id);
                var model = _rolesRepository.ExecuteStoredProcedure<Models.ServiceSubCategoryLookupModel>("sjc_GetServiceSubCategoryLookupById", spParams).FirstOrDefault();
                return model;
            
        }

        public bool DeleteServiceSubCat(int id)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("ServiceSubCategoryId ", id);
            _rolesRepository.ExecuteStoredProcedure("Sjc_delete_ServicesSubCat", spParams);
            return true;
        }

        //public Domain.Modeles.ServicesModel GetUserById(int ServiceId)
        //{
        //    var dataMenu = _userRepository.ExecuteStoredProcedure<Domain.Modeles.ServicesModel>("sjc_GetServiceId", new Microsoft.Data.SqlClient.SqlParameter("ServiceId", ServiceId));
        //    return dataMenu.FirstOrDefault();
        //}

        //public bool UpdateUser(Domain.Modeles.ServicesModel userModel, string userName)
        //{
        //    Services users = new Services()
        //    {
        //        Name = userModel.Name,
        //        NameAr = userModel.NameAr,
        //    };
        //    _userRepository.Update(users, userName);
        //    _userRepository.Save();
        //    return true;
        //}



    }
}
