using AutoMapper;
using Data.Interface;
using Domain.Entities;
using Service.Interface;
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
    }
}
