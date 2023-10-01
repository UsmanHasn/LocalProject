using AutoMapper;
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
    public class Service : IService
    {

        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<SystemSettings> _systemSettingRepository;

        public Service(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<Services>> GetAllServices()
        {
            var stafflist = await _unitOfWork.Services.GetAll();
            var staflist = _mapper.Map<List<Services>>(stafflist);
            return staflist;
        }

        public List<ServicesSubCategoryModel> BindSubCategory()
        {
            throw new NotImplementedException();
        }

       

        public bool AddService(ServicesModel services, string userName)
        {
            throw new NotImplementedException();
        }

        public List<ServicesModel> GetAllService()
        {
            throw new NotImplementedException();
        }

        public ServicesModel GetDataById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateService(int id, ServicesModel services, string userName)
        {
            throw new NotImplementedException();
        }

        public bool DeleteService(int id)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("ServiceId ", id);
            _systemSettingRepository.ExecuteStoredProcedure("Sjc_delete_Services", spParams);
            return true;
        }
        public bool DeleteServiceItem(int id, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
