using AutoMapper;
using Data.Concrete;
using Data.Interface;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.Data.SqlClient;
using Org.BouncyCastle.Crypto;
using Service.Interface;
using Service.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.Concrete
{
    public class AdminService : IAdminService
    {
        public readonly IRepository<SMS_Trans> _smsRepository;

        private readonly IRepository<SystemSettings> _systemSettingRepository;
        public AdminService(IRepository<SystemSettings> systemSettingRepository, IRepository<SMS_Trans> smsRepository)
        {
            _systemSettingRepository = systemSettingRepository;
            _smsRepository = smsRepository;

        }
        public List<UserActivityLog> GetActivityLogs()
        {


            //List<UserActivityLog> model = new List<UserActivityLog>();
            //model.Add(new UserActivityLog()
            //{
            //    ID = "0001",
            //    Name = "Waqas Yaqoob",
            //    Email = "abc@xyz.com",
            //    Role = "Administrator",
            //    Date = "06-13-2023",
            //    IPAddress = "192.168.2.6",
            //    Location = "10.15456856, 36542145235",
            //    Device = "Iphone8"
            //});

            return null;
        }
        public List<Announcement> GetAllAnnouncements()
        {
            List<Announcement> model = new List<Announcement>();
            model.Add(new Announcement()
            {
                ID = "0001",
                Type = "Marriage",
                Date = "15/9/2022",
                Description = "The decision was taken to postpone announcing a hearing in file No. 191/1208/2019 for a session on 05/11/2019, the Sessions Affairs " +
                "Department of the Court, the Court of First Instance in Al-Khaboura",
                LastViewedOn = "11/10/2022"
            });

            model.Add(new Announcement()
            {
                ID = "0002",
                Type = "Revision",
                Date = "03/05/2022",
                Description = "Your application has been registered No.: 40/9103/2019, the Department of Commercial" +
                " Execution, Registration of Claims in the Court of First Instance in Haima",
                LastViewedOn = "08/6/2022"
            });

            model.Add(new Announcement()
            {
                ID = "0003",
                Type = "Compensation",
                Date = "06/8/2022",
                Description = "The decision was made, a decision to write off the case in File No. 529/1109/2019 for a session dated by the " +
                "Sessions Affairs Department of the Court of First Instance in Seeb.",
                LastViewedOn = "09/9/2022"
            });

            model.Add(new Announcement()
            {
                ID = "0004",
                Type = "Ignorant request",
                Date = "27/6/2022",
                Description = "Your application No.: 2174/9102/2018 has been registered " +
                "with the Department of Civil Execution, Registration of Claims in the Court of First Instance in Muscat",
                LastViewedOn = "11/10/2022"
            });
            model.Add(new Announcement()
            {
                ID = "0005",
                Type = "Shutdown chapter",
                Date = "02/4/2023",
                Description = "The decision was taken to postpone reconciliation or settlement in file No. 201/1106/2019 for a session on 10/22/2019," +
                " the Sessions Affairs Department of the Court, the First Instance Court in Suwaiq",
                LastViewedOn = "6/5/2023"
            });

            return model;
        }
        public List<Calendar> GetAllCalendar()
        {
            List<Calendar> model = new List<Calendar>();
            model.Add(new Calendar()
            {

                HearingDate = "2014-11-19",
                Description = " Accepting the lawsuit in form, and rejecting it in substance",
                CaseNo = "16",
                CaseParty = "Plaintiff",
                CourtBuilding = "Muscat Court Building"
            });
            model.Add(new Calendar()
            {
                HearingDate = "2016-02-03",
                Description = "The court ruled to accept the lawsuit in form and reject it in substance," +
                " as stated in the reasons, and obligated the plaintiffs to pay the expenses.",
                CaseNo = "5 ",
                CaseParty = "Plaintiff",
                CourtBuilding = "Sohar Court Building"
            });
            model.Add(new Calendar()
            {

                HearingDate = "2016-11-01",
                Description = "Court Decision: The court decided to reserve the case for judgment for the session of 22/11/2016 with permission" +
                " for the defendant to submit response notes within one week.",
                CaseNo = "6543 ",
                CaseParty = "Defendant",
                CourtBuilding = "Salalah Court Building"
            });
            model.Add(new Calendar()
            {

                HearingDate = "  2018-11-19 ",
                Description = "- The attendees of the Royal Oman Police presented what was requested of them in the previous session.  - Court decision: for the session of 4/12/2018 to comment" +
                " on the response of the Royal Oman Police with permission for the plaintiff to review the incident file without photographing.",
                CaseNo = "14514 ",
                CaseParty = "Plaintiff",
                CourtBuilding = "supreme court"
            });
            model.Add(new Calendar()
            {

                HearingDate = "  2022-10-26",
                Description = "- The presenter of the Public Establishment for Industrial Estates submitted to the court a" +
                " memorandum requesting to leave the lawsuit - Judgment at the end of the session",
                CaseNo = "37912 ",
                CaseParty = "Appellee",
                CourtBuilding = "supreme court"
            });
            return model;
        }
        public List<CourtList> GetAllCourts()
        {
            List<CourtList> model = new List<CourtList>();

            model.Add(new CourtList()
            {
                CaseID = "1",
                CourtName = "مجمع المحاكم الخوير، شارع الوزارات، مسقط",
                Description = "مجمع المحاكم الخوير، شارع الوزارات",
                TotalNoCases = "10"

            });
            model.Add(new CourtList()
            {
                CaseID = "2",
                CourtName = "صلالة",
                Description = "صلالة ، شمال العوقدين",
                TotalNoCases = "10"

            });
            model.Add(new CourtList()
            {
                CaseID = "3",
                CourtName = "صحار",
                Description = "صحار ، غيل الشبول",
                TotalNoCases = "10"

            });
            return model;
        }
        public List<CaseListModel> GetAllCases()
        {
            List<CaseListModel> model = new List<CaseListModel>();
            model.Add(new CaseListModel()
            {
                Case_No = "Case I",
                Case_Type = "Civil",
                Description = "file description here",
                Lawyers = "Fahad"
            });
            model.Add(new CaseListModel()
            {
                Case_No = "Case II",
                Case_Type = "Material",
                Description = "file description here",
                Lawyers = "Kamran"
            });
            return model;
        }
        public List<LawyersModels> GetAllLawyers(int civilNo)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("CivilNO", civilNo);
            var model = _systemSettingRepository.ExecuteStoredProcedure<LawyersModels>("sjc_GetLawyer", spParams).ToList();
            return model;
        }
        public List<Notification> GetAllNotifications()
        {
            List<Notification> model = new List<Notification>();
            model.Add(new Notification() { CaseID = "172488", Type = "Marriage", Date = "20-10-2019", Description = "Your application has been registered No.: 2054/9101/2018, the Department of Execution of Legal Claims Registration at the First Instance Court in Seeb", LastViewedOn = "21-11-2019" });
            model.Add(new Notification() { CaseID = "291915", Type = "Power of attorney", Date = "21-10-2019", Description = "The decision was taken to postpone the response to a session in file No. 308/1309/2019 for a session on 05/11/2019, the Sessions Affairs Department of the Court, the Court of First Instance in Sohar", LastViewedOn = "12-11-2019" });
            model.Add(new Notification() { CaseID = "352528", Type = "Commandment", Date = "13-11-2019", Description = "The decision was taken to postpone the publication of a session in file No. 406/1301/2019 for a session on 11/12/2019, the Sessions Affairs Department of the Court of First Instance Court in Sohar", LastViewedOn = "14-12-2019" });
            model.Add(new Notification() { CaseID = "172495", Type = "Other civil claims", Date = "21-10-2019", Description = "Your application has been registered No.: 1253/9103/2019, the Department of Commercial Execution, Registration of Claims in the Court of First Instance in Muscat", LastViewedOn = "22-12-2019" });
            model.Add(new Notification() { CaseID = "173917", Type = "Property", Date = "11-12-2019", Description = "Your request has been accepted in File No. 43/1208/2019. Please refer to the Court of First Instance in Buraimi", LastViewedOn = "02-02-2020" });
            model.Add(new Notification() { CaseID = "234280", Type = "Other civil claims", Date = "29-12-2019", Description = "The decision was taken to postpone the announcement of a session in File No. 621/7102/2019 for a session on 11/10/2019, the Sessions Affairs Department of the Court, Sohar Court of Appeal", LastViewedOn = "02-04-2020" });
            model.Add(new Notification() { CaseID = "441295", Type = "Building Contracting", Date = "09-03-2021", Description = "Your application No.: 196/1506/2019 has been registered, the department is individual for rents, and the session has been scheduled for 04/11/2019 to register lawsuits in the Court of First Instance in Sohar", LastViewedOn = "10-04-2021" });
            model.Add(new Notification() { CaseID = "336797", Type = "Other commercial lawsuits", Date = "22-05-2022", Description = "Your application has been accepted in File No. 114/1401/2019. Please refer to the Court of First Instance in Buraimi", LastViewedOn = "24-05-2022" });
            model.Add(new Notification() { CaseID = "172500", Type = "Property", Date = "19-07-2022", Description = "Your application has been registered No.: 432/9102/2019, the Department of Civil Execution, Registration of Claims at the First Instance Court in Suwaiq", LastViewedOn = "22-08-2022" });
            model.Add(new Notification() { CaseID = "172242", Type = "Divorce", Date = "21-08-2022", Description = "The executor has been announced against him, File No.: 1030/9101/2019, the Department of Sharia Implementation, Registration of Claims in the Court of First Instance in Al-Buraimi, The procedure is in progress", LastViewedOn = "20-09-2022" });
            return model;
        }
        public List<ServicesModel> GetAllServices(int categoryId, int subCategoryId)
        {
            SqlParameter[] spParams = new SqlParameter[2];
            spParams[0] = new SqlParameter("CategoryId", categoryId);
            spParams[1] = new SqlParameter("SubCategoryId", subCategoryId);
            List<ServicesModel> data = _systemSettingRepository.ExecuteStoredProcedure<ServicesModel>("sp_GetServices", spParams).ToList();
            return data;
        }
        //public List<ServicesModel> GetAllSubServices(int categoryId, int subCategoryId)
        //{
        //    SqlParameter[] spParams = new SqlParameter[2];
        //    spParams[0] = new SqlParameter("CategoryId", categoryId);
        //    spParams[1] = new SqlParameter("SubCategoryId", subCategoryId);
        //    List<ServicesModel> data = _systemSettingRepository.ExecuteStoredProcedure<ServicesModel>("sp_GetServices", spParams).ToList();
        //    return data;
        //}


        public bool Add(SMS_TransModel smsModel, string smsId)
        {
            SMS_Trans sms = new SMS_Trans()
            {
                SMS_Trans_ID = smsModel.SMS_Trans_ID,
                Text_Numbers = smsModel.Text_Numbers,
                Text_Message = smsModel.Text_Message,
                Notes = smsModel.Notes,
                CreatedDate = DateTime.Now,
                Created_On = smsModel.Created_On,
                Modified_By = smsModel.Modified_By,
                Modified_On = DateTime.Now

            };
            _smsRepository.Create(sms, smsId);
            _smsRepository.Save();
            return true;

        }

        public SMS_TransModel GetSmsById(int smsId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSms(SMS_TransModel sms_TransModel, string smsId)
        {
            throw new NotImplementedException();
        }

        public bool Add(SMS_TransModel sms_TransModel)
        {
            throw new NotImplementedException();
        }

        List<ServiceSubCategoryLookupModel> IAdminService.GetAllSubServices(int categoryId, int subCategoryId)
        {
            throw new NotImplementedException();
        }

        public List<AlertModel> GetAllAlerts(int userId)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("userid", userId);
            var model = _systemSettingRepository.ExecuteStoredProcedure<AlertModel>("sjc_GetAllAlerts", spParams).ToList();
            return model;
        }

        public bool Add(AlertModel alertModel, string userName)
        {

            SqlParameter[] spParams = new SqlParameter[12];
            spParams[0] = new SqlParameter("Alertid", alertModel.alertId);
            spParams[1] = new SqlParameter("UserId", alertModel.userId);
            spParams[2] = new SqlParameter("AlertType", alertModel.alertType);
            spParams[3] = new SqlParameter("Subject", alertModel.subject);
            spParams[4] = new SqlParameter("Email", alertModel.email);
            spParams[5] = new SqlParameter("MobileNo", alertModel.mobileNo);
            spParams[6] = new SqlParameter("Message", alertModel.message);
            spParams[7] = new SqlParameter("CreatedBy", userName);
            spParams[8] = new SqlParameter("LastModifiedBy", userName);
            spParams[9] = new SqlParameter("Deleted", false);
            spParams[10] = new SqlParameter("IsViewed", false);
            spParams[11] = new SqlParameter("ViewedOn", DBNull.Value);
            _systemSettingRepository.ExecuteStoredProcedure("Sp_dml_alerts", spParams);
            return true;
        }

        public AlertModel GetAlertById(int Id)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("Alertid", Id);
            var model = _systemSettingRepository.ExecuteStoredProcedure<AlertModel>("sjc_GetAllAlerts", spParams).FirstOrDefault();
            return model;
        }

        public List<UserModel> GetUsers()
        {
            SqlParameter[] spParams = new SqlParameter[0];
            // List<UserModel> model = new List<UserModel>();
            var model = _systemSettingRepository.ExecuteStoredProcedure<UserModel>("sjc_GetUser", spParams).ToList();
            var data = model.Select(x => new UserModel()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
            return data;
        }


        public List<UserActivityLog> GetActivityInfoLogs(int userId, bool isSystemAdmin, string? userName, string? fromdate, string? todate)
        {
            SqlParameter[] spParams = new SqlParameter[4];
            spParams[0] = new SqlParameter("UserId", isSystemAdmin != true ? userId : DBNull.Value);
            spParams[1] = new SqlParameter("UserName", string.IsNullOrEmpty(userName)  ? "" : userName);
            spParams[2] = new SqlParameter("FromDate", string.IsNullOrEmpty(fromdate) ? "" : fromdate);
            spParams[3] = new SqlParameter("ToDate", string.IsNullOrEmpty(todate) ? "" : todate);
            var model = _systemSettingRepository.ExecuteStoredProcedure<UserActivityLog>("sjc_GetUserActivityInfoLogById", spParams).ToList();
            var data = model.Select(x => new UserActivityLog()
            {
                UserId = x.UserId,
                UserName = x.UserName,
                UserNameAr = x.UserNameAr,
                PageName = x.PageName,
                Message = x.Message,
                TimeLoggedIn = x.TimeLoggedIn
            }).ToList();
            return data;
        }


    }
}
