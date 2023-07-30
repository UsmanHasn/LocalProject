using Data.Context;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/admin/")]
    public class AdminController : Controller
    {
        private readonly IAdminService? _AdminService;
        private readonly ApplicationDbContext _context;
        public AdminController(IAdminService adminService, ApplicationDbContext context)
        {
            _AdminService = adminService;
            _context = context;
        }

        [HttpGet]
        [Route("getallcourt")]
        public IActionResult  GetAllCourt()
        {
            List<CourtList> model = new List<CourtList>();
            model = _AdminService.GetAllCourts();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getallcases")]
        public IActionResult GetAllCases()
        {
            List<CaseListModel> model = new List<CaseListModel>();
            model = _AdminService.GetAllCases();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("getallcalendar")]
        public IActionResult GetAllCalendar()
        {
            List<Calendar> model = new List<Calendar>();
            model = _AdminService.GetAllCalendar();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }


        [HttpGet]
        [Route("getallannouncement")]
        public IActionResult GetAllAccouncement()
        {
            List<Announcement> model = new List<Announcement>();
            model = _AdminService.GetAllAnnouncements();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }



        [HttpGet]
        [Route("getallnotification")]
        public IActionResult GetAllNotification()
        {
            List<Notification> model = new List<Notification>();
            model = _AdminService.GetAllNotifications();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }


        [HttpGet]
        [Route("getalluseractivitylog")]
        public IActionResult GetAllUseractivitylog()
        {
            List<UserActivityLog> model = new List<UserActivityLog>();
            model = _AdminService.GetActivityLogs();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("getalllawyers")]
        public IActionResult GetAllLawyers()
        {
            List<LawyersModels> model = new List<LawyersModels>();
            model = _AdminService.GetAllLawyers();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getallservices")]
        public IActionResult GetAlServices(int categoryId, int subCategoryId)
        {
            List<ServicesModel> model = new List<ServicesModel>();
            model = _AdminService.GetAllServices(categoryId, subCategoryId);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }


        [HttpPost]
        [Route("InsertSms")]
        public IActionResult Add(SMS_TransModel model, string smsId)
        {
            if (model.SMS_Trans_ID > 0)
            {
                SMS_TransModel _smsModel = _AdminService.GetSmsById(model.SMS_Trans_ID);
                model.CreatedDate = _smsModel.CreatedDate;
                model.Created_On = _smsModel.Created_On;
                _AdminService.UpdateSms(model, smsId);
            }
            else
            {
                _AdminService.Add(model, smsId);
            }
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///


      

        [HttpGet]
        [Route("getSJCESP_AlertandNotification")]
        [ProducesResponseType(typeof(SJCESP_AlertandNotification), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Int64 CaseID, Boolean Affichable)
        {
            var issue = await _context.SJCESP_AlertandNotification.FindAsync(CaseID , Affichable);
            return issue == null ? NotFound() : Ok(issue);
        }

        
        [HttpGet]
        [Route("getSJCESP_CaseInformation")]
        [ProducesResponseType(typeof(SJCESP_CaseInformation), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdentifiantAndAffichable(Int64 Identifiant , Boolean Affichable)
        {
            var issue = await _context.SJCESP_CaseInformation.FindAsync(Identifiant, Affichable);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpGet]
        [Route("getSJCESP_Casese")]
        [ProducesResponseType(typeof(SJCESP_Cases), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSJCESP_Cases(string CRNO, Int64 IdDossierCivil)
        {
            var issue = await _context.SJCESP_Cases.FindAsync(CRNO , IdDossierCivil);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpGet]
        [Route("SJCESP_civilno")]
        [ProducesResponseType(typeof(SJCESP_civilno), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSJCESP_civilno(Int64 IdDossierCivil, string NumeroPieceIdentite)
        {
            var issue = await _context.SJCESP_civilno.FindAsync(IdDossierCivil, NumeroPieceIdentite);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpGet]
        [Route("SJCESP_Denominations")]
        [ProducesResponseType(typeof(SJCESP_Denominations), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSJCESP_Denominations(Int64 IdDossierCivil, string NumRegistreCommerce)
        {
            var issue = await _context.SJCESP_Denominations.FindAsync(IdDossierCivil, NumRegistreCommerce);
            return issue == null ? NotFound() : Ok(issue);
        }


        [HttpGet]
        [Route("SJCESP_Decision")]
        [ProducesResponseType(typeof(SJCESP_Decision), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSJCESP_Decision(Int64 IdDossierCivil)
        {
            var issue = await _context.SJCESP_Decision.FindAsync(IdDossierCivil);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpGet]
        [Route("SJCESP_Judge_Information")]
        [ProducesResponseType(typeof(SJCESP_Judge_Information), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSJCESP_Judge_Information(Int64 IdDossierCivil)
        {
            var issue = await _context.SJCESP_Judge_Information.FindAsync(IdDossierCivil);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpGet]
        [Route("SJCESP_LawyerAddress")]
        [ProducesResponseType(typeof(SJCESP_LawyerAddress), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSSJCESP_LawyerAddress(string LicenseNo)
        {
            var issue = await _context.SJCESP_LawyerAddress.FindAsync(LicenseNo);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpGet]
        [Route("SJCESP_LawyerCaces")]
        [ProducesResponseType(typeof(SJCESP_LawyerCaces), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSJCESP_LawyerCaces(Int64 CaseID, string NumeroPieceIdentite)
        {
            var issue = await _context.SJCESP_LawyerCaces.FindAsync(CaseID, NumeroPieceIdentite);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpGet]
        [Route("SJCESP_LawyerInformation")]
        [ProducesResponseType(typeof(SJCESP_LawyerCaces), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSJCESP_LawyerInformation(Int64 lawyerid, string CivilNo)
        {
            var issue = await _context.SJCESP_LawyerInformation.FindAsync(lawyerid, CivilNo);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpGet]
        [Route("SJCESP_RoleParties")]
        [ProducesResponseType(typeof(SJCESP_RoleParties), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSJCESP_RoleParties(Int64 CaseID, string CivilNumberParties)
        {
            var issue = await _context.SJCESP_RoleParties.FindAsync(CaseID, CivilNumberParties);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpGet]
        [Route("SJCESP_Session_Information")]
        [ProducesResponseType(typeof(SJCESP_Session_Information), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSJCESP_Session_Information(Int64 CaseID)
        {
            var issue = await _context.SJCESP_Session_Information.FindAsync(CaseID);
            return issue == null ? NotFound() : Ok(issue);
        }






        [HttpPost]
        [Route("insertalert")]
        public IActionResult Add(AlertModel alertModel,string userName)
        {
            _AdminService.Add(alertModel, userName);
            return new JsonResult(new {data = alertModel, status = HttpStatusCode.OK});
        }
        [HttpGet]
        [Route("getusers")]
        public IActionResult Getusers()
        {
            //List<UserModel> model = new List<UserModel>();
            var model = _AdminService.GetUsers();
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getalerts")]
        public IActionResult GetAll(int userId)
        {
          //  List<UserModel> model = new List<UserModel>();
           var model = _AdminService.GetAllAlerts(userId);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
        [HttpGet]
        [Route("getAlertbyId")]
        public IActionResult GetAlertById(int Id)
        {
            AlertModel model = new AlertModel();
            model = _AdminService.GetAlertById(Id);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
    }
}
