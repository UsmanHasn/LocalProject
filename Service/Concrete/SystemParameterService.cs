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
        public readonly IRepository<SYS_SystemSettings> _systemSettingRepository;

        public SystemParameterService(IRepository<SYS_SystemSettings> systemSettingRepository)
        {
            _systemSettingRepository = systemSettingRepository;
        }

        public bool Add(SystemParameterModel systemParameterModel, string userName)
        {
            //SystemParameterModel sysModel = this.GetsystemParameterByName(systemParameterModel.keyName);
            //if (sysModel==null)
            //{
                SYS_SystemSettings settings = new SYS_SystemSettings()
                {
                    KeyName = systemParameterModel.keyName,
                    KeyValue = systemParameterModel.keyValue,
                    Description = systemParameterModel.description,

                };
                _systemSettingRepository.Create(settings, userName);
                _systemSettingRepository.Save();
                return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public bool DeletesystemParameter(int Id, string userName)
        {
            try
            {
                SystemParameterModel sysModel = this.GetsystemParameterById(Id);
                SYS_SystemSettings model = new SYS_SystemSettings()
                {
                    KeyName = sysModel.keyName,
                    KeyValue = sysModel.keyValue,
                    Description = sysModel.description,
                    CreatedBy = sysModel.createdBy,
                    CreatedDate = sysModel.createdDate,
                    Id = Id,
                    Deleted = true
                };
                _systemSettingRepository.Delete(model, userName);
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


        public SystemParameterModel GetsystemParameterByName(string name)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("KeyName", name);
            return _systemSettingRepository.ExecuteStoredProcedure<SystemParameterModel>("sjc_GetSystemSettingsName", spParams).FirstOrDefault();
        }

        public bool UpdatesystemParameter(SystemParameterModel systemParameterModel, string userName)
        {
            try
            {
                SYS_SystemSettings model = new SYS_SystemSettings()
                {
                    KeyName = systemParameterModel.keyName,
                    KeyValue = systemParameterModel.keyValue,
                    Description = systemParameterModel.description,
                    CreatedBy = systemParameterModel.createdBy,
                    CreatedDate = systemParameterModel.createdDate,
                    Id = systemParameterModel.systemSettingId
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
