using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interface;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Service.Interface;
using Service.Models;

namespace Service.Concrete
{
    public class SystemParameterService : ISystemParameterService
    {
        public readonly IRepository<SystemSettings> _systemSettingRepository;

        public SystemParameterService(IRepository<SystemSettings> systemSettingRepository)
        {
            _systemSettingRepository = systemSettingRepository;
        }

        public bool Add(SystemParameterModel systemParameterModel, string userName)
        {
            SystemSettings settings = new SystemSettings()
            {
                KeyName = systemParameterModel.KeyName,
                KeyValue = systemParameterModel.KeyValue,
                Description = systemParameterModel.Description,
            };
            _systemSettingRepository.Create(settings,userName);
            _systemSettingRepository.Save();
            return true;
        }

        public bool DeletesystemParameter(int Id, string userName)
        {
            try
            {
                SystemParameterModel sysModel = this.GetsystemParameterById(Id);
                SystemSettings model = new SystemSettings()
                {
                    KeyName = sysModel.KeyName,
                    KeyValue = sysModel.KeyValue,
                    Description = sysModel.Description,
                    CreatedBy = sysModel.CreatedBy,
                    CreatedDate = sysModel.CreatedDate,
                    Id = Id,
                    Deleted = true
                };
                _systemSettingRepository.Update(model, userName);
                _systemSettingRepository.Save();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            

        }

        public List<SystemParameterModel> GetAllsystemParameter()
        {
            SqlParameter[] spParams = new SqlParameter[0];
            return _systemSettingRepository.ExecuteStoredProcedure<SystemParameterModel>("sjc_GetSystemSettings", spParams).ToList();
        }

        public SystemParameterModel GetsystemParameterById(int Id)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("SettingId", Id);
            return _systemSettingRepository.ExecuteStoredProcedure<SystemParameterModel>("sjc_GetSystemSettings", spParams).FirstOrDefault();
        }

        public bool UpdatesystemParameter(SystemParameterModel systemParameterModel, string userName)
        {
            try
            {
                SystemSettings model = new SystemSettings()
                {
                    KeyName = systemParameterModel.KeyName,
                    KeyValue = systemParameterModel.KeyValue,
                    Description = systemParameterModel.Description,
                    CreatedBy = systemParameterModel.CreatedBy,
                    CreatedDate = systemParameterModel.CreatedDate,
                    Id = systemParameterModel.Id
                };
                _systemSettingRepository.Update(model, userName);
                _systemSettingRepository.Save();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
