using Domain.Entities;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IService
    {
        Task<List<Services>> GetAllServices();

        List<ServicesSubCategoryModel> BindSubCategory();
        List<ServicesModel> GetAllService();
        ServicesModel GetDataById(int id);
        bool DeleteServiceItem(int Id, string userName);

        bool AddService(ServicesModel services, string userName);
        bool UpdateService(int id, ServicesModel services, string userName);

    }
}
