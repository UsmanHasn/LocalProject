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
    public class AdminService : IAdminService
    {
        private readonly IRepository<SystemSettings> _systemSettingRepository;
        public AdminService(IRepository<SystemSettings> systemSettingRepository)
        {
            _systemSettingRepository = systemSettingRepository;
        }
        public List<UserActivityLog> GetActivityLogs()
        {
            List<UserActivityLog> model = new List<UserActivityLog>();
            model.Add(new UserActivityLog()
            {
                ID = "0001",
                Name = "Waqas Yaqoob",
                Email = "abc@xyz.com",
                Role = "Administrator",
                Date = "06-13-2023",
                IPAddress = "192.168.2.6",
                Location = "10.15456856, 36542145235",
                Device = "Iphone8"
            });

            return model;
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
                CaseID = "0001",
                CourtName = "Administrative Court",
                Description = "Description file here",
                TotalNoCases = "10"

            });
            model.Add(new CourtList()
            {
                CaseID = "0001",
                CourtName = "Supreme Court",
                Description = "Description file here",
                TotalNoCases = "10"

            });
            model.Add(new CourtList()
            {
                CaseID = "0001",
                CourtName = "Commercial Court",
                Description = "Description file here",
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
                Lawyers ="Fahad"
            });
            model.Add(new CaseListModel()
            {
                Case_No = "Case I",
                Case_Type = "Material",
                Description = "file description here",
                Lawyers = "Kamran"
            });
            return model;
        }
        public List<LawyersModels> GetAllLawyers()
        {
            List<LawyersModels> model = new List<LawyersModels>();
            model.Add(new LawyersModels()
            {
                LawyerName = "Fahad",
                CaseId = 1101,
                Description = "file description here",
                CaseType = "Civil"
            }); model.Add(new LawyersModels()
            {
                LawyerName = "Kamran",
                CaseId = 1102,
                Description = "file description here",
                CaseType = "Material"
            });
            return model;
        }
        public List<Notification> GetAllNotifications()
        {
            List<Notification> model = new List<Notification>();
            model.Add(new Notification() { CaseID = "172488", Type = "Marriage", Date = "20-10-2019", Description= "Your application has been registered No.: 2054/9101/2018, the Department of Execution of Legal Claims Registration at the First Instance Court in Seeb", LastViewedOn="21-11-2019"});
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
    }
}
