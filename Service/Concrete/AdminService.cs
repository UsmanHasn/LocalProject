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
                Date= "06/13-2023",
                IPAddress= "192.168.2.6",
                Location= "10.15456856, 36542145235",
                Device="Iphone8"
            });

            return model;
        }

        public List<Announcement> GetAllAnnouncements()
        {
            List<Announcement> model = new List<Announcement>();
            model.Add(new Announcement()
            {
                ID = "0001",
                Type = "Case Announcement",
                Date = "06/11/2023",
                Description = "Appeal - Annouces that a case is under appeal"
            });

            model.Add(new Announcement()
            {
                ID = "0002",
                Type = "Document Announcement",
                Date = "06/11/2023",
                Description = "Warrant Document – Provides the warrant image when available.\t"
            });

            model.Add(new Announcement()
            {
                ID = "0003",
                Type = "Party Announcement",
                Date = "06/11/2023",
                Description = "Party Merge – Indicates when two party records have been merged into one."
            });

            model.Add(new Announcement()
            {
                ID = "0004",
                Type = "Case Announcement",
                Date = "06/11/2023",
                Description = "Case Initiation Criminal – A case in the criminal category has been initiated."
            });

            return model;
        }

        public List<Calendar> GetAllCalendar()
        {
            List<Calendar> model = new List<Calendar>();
            model.Add(new Calendar()
            {
                HearingDate = "18-06-2023",
                Description = "Abc",
                CaseNo = "0001",
                CaseParty = "abc",
                CourtBuilding = "222"
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
    }
}
