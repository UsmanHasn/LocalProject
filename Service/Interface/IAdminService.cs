﻿using Domain.Entities;
using Domain.Entities.Lookups;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IAdminService
    {
        List<CourtList> GetAllCourts();
        List<CaseListModel> GetAllCases();
        List<Calendar> GetAllCalendar();
        List<Announcement> GetAllAnnouncements();
        List<UserActivityLog> GetActivityLogs();
        List<LawyersModels> GetAllLawyers(int civilNo);
        List<Notification> GetAllNotifications();
        List<ServicesModel> GetAllServices(int categoryId, int subCategoryId);
        List<ServiceSubCategoryLookupModel> GetAllSubServices(int categoryId, int subCategoryId);
        // Task<bool> SendSmsMessage(SMS_TransModel sms_TransModel);
        bool Add(SMS_TransModel sms_TransModel, string smsId);
        SMS_TransModel GetSmsById(int smsId);
        bool UpdateSms(SMS_TransModel sms_TransModel, string smsId);

        List<Lkt_EntityModel> GetAllEntity();
        string InsUpdLKT_Entity (Lkt_EntityModel lkt_EntityModel, string userName);
        string DeleteEntity(Lkt_EntityModel lkt_EntityModel, string userName);
        Lkt_EntityModel GetEntityById(int entityId);
        List<UserModel> GetUsers();
        List<AlertModel> GetAllAlerts(int userId);
        bool Add(AlertModel alertModel, string userName);
        AlertModel GetAlertById(int Id);
        List<UserActivityLog> GetActivityInfoLogs(int userId, bool isSystemAdmin, string? userName, string? fromdate, string? todate);
    }
}
