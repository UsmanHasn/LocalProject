using Service.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Modeles;

namespace Service.Interface
{
    public interface IServiceSubCategoryLookupService
    {
        List<ServiceSubCategoryLookupModel> GetAllSubService();
        List<Domain.Entities.ServiceCategoryLookup> GetAllServiceLookup();
        List<Domain.Modeles.ServicesModel> GetAllServices();


        //bool Add(Domain.Modeles.ServicesModel userModel, string userName);
        //bool UpdateUser(Domain.Modeles.ServicesModel userModel, string userName);
        //Domain.Modeles.ServicesModel GetUserById(int ServiceId);
    }
}
