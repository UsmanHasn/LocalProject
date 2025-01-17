﻿using Domain.Entities;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ISystemParameterService
    {
        paginationSystemParameterModel GetAllsystemParameter(int pageSize, int pageNumber, string? SearchText);
        bool Add(SystemParameterModel systemParameterModel,string userName);
        SystemParameterModel GetsystemParameterById(int Id);
        bool UpdatesystemParameter(SystemParameterModel systemParameterModel, string userName);
        bool DeletesystemParameter(int Id, string userName);
        public SystemParameterModel GetsystemParameterByName(string name);
    }
}
