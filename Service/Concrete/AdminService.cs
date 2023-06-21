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
        public List<UserActivityLog> GetActivityLogs()
        {
            List<UserActivityLog> model = new List<UserActivityLog>();
            model.Add(new UserActivityLog()
            {
                ID = "0001",
                Name = "Waqas Yaqoob",
                Email = "abc@xyz.com",
                Role = "Administrator",
                Date = "06/13-2023",
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
                Type = "marriage",
                Date = "15/9/2022",
                Description = "The decision was taken to postpone announcing a hearing in file No. 191/1208/2019 for a session on 05/11/2019, the Sessions Affairs " +
                "Department of the Court, the Court of First Instance in Al-Khaboura"
            });

            model.Add(new Announcement()
            {
                ID = "0002",
                Type = "revision",
                Date = "03/05/2022",
                Description = "Your application has been registered No.: 40/9103/2019, the Department of Commercial" +
                " Execution, Registration of Claims in the Court of First Instance in Haima"
            });

            model.Add(new Announcement()
            {
                ID = "0003",
                Type = "compensation",
                Date = "06/8/2022",
                Description = "The decision was made, a decision to write off the case in File No. 529/1109/2019 for a session dated by the " +
                "Sessions Affairs Department of the Court of First Instance in Seeb."
            });

            model.Add(new Announcement()
            {
                ID = "0004",
                Type = "Ignorant request",
                Date = "27/6/2022",
                Description = "Your application No.: 2174/9102/2018 has been registered " +
                "with the Department of Civil Execution, Registration of Claims in the Court of First Instance in Muscat"
            });
            model.Add(new Announcement()
            {
                ID = "0005",
                Type = "Shutdown chapter",
                Date = "02/4/2023",
                Description = "The decision was taken to postpone reconciliation or settlement in file No. 201/1106/2019 for a session on 10/22/2019," +
                " the Sessions Affairs Department of the Court, the First Instance Court in Suwaiq"
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
                CourtName = "Abc",
                Description = "Abc",
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
                Lawyers = "Lawyer1"
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
    }
}
