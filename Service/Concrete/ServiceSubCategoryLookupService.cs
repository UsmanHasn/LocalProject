using Data.Context;
using Data.Interface;
using Domain.Entities;
using Domain.Entities.Lookups;
using Domain.Modeles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        private readonly IRepository<ServiceSubCategoryLookup> _rolesRepository;
        private readonly ApplicationDbContext dbContextClass;
        public readonly IRepository<Services> _userRepository;

        public ServiceSubCategoryLookupService(IRepository<ServiceSubCategoryLookup> repository, ApplicationDbContext dbContextClass)
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

        List<Domain.Entities.ServiceCategoryLookup> IServiceSubCategoryLookupService.GetAllServiceLookup()
        {
            throw new NotImplementedException();
        }
        ////////////////////////////
        ///

        public bool Add(Domain.Modeles.ServicesModel userModel, string userName)
        {
            Services users = new Services()
            {
                Name = userModel.Name,
                NameAr = userModel.NameAr,
            
            };
            _userRepository.Create(users, userName);
            _userRepository.Save();
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
