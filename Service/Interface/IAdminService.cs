﻿using Service.Models;
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
        List<LawyersModels> GetAllLawyers();

       
    }
}