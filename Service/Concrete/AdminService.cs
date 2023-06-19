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
