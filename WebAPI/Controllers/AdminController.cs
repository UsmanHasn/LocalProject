using Data.Context;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using Service.Helper;
using Service.Interface;
using Service.Models;
using System.Net;
using WebAPI.Models;

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
        public IActionResult GetAllCourt()
        {
            List<CourtList> model = new List<CourtList>();
            try
            {
                model = _AdminService.GetAllCourts();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }
        }
        [HttpGet]
        [Route("getallcases")]
        public IActionResult GetAllCases()
        {
            List<Service.Models.CaseListModel> model = new List<Service.Models.CaseListModel>();
            try
            {
                model = _AdminService.GetAllCases();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }
        }

        [HttpGet]
        [Route("getallcalendar")]
        public IActionResult GetAllCalendar()
        {
            List<Calendar> model = new List<Calendar>();
            try
            {
                model = _AdminService.GetAllCalendar();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }
        }


        [HttpGet]
        [Route("getallannouncement")]
        public IActionResult GetAllAccouncement()
        {
            List<Announcement> model = new List<Announcement>();
            try
            {
                model = _AdminService.GetAllAnnouncements();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }



        [HttpGet]
        [Route("getallnotification")]
        public IActionResult GetAllNotification()
        {
            List<Notification> model = new List<Notification>();
            try
            {
                model = _AdminService.GetAllNotifications();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }


        [HttpGet]
        [Route("getalluseractivitylog")]
        public IActionResult GetAllUseractivitylog()
        {
            List<UserActivityLog> model = new List<UserActivityLog>();
            try
            {
                model = _AdminService.GetActivityLogs();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("getalllawyers")]
        public IActionResult GetAllLawyers(int civilNo)
        {
            List<LawyersModels> model = new List<LawyersModels>();
            try
            {
                model = _AdminService.GetAllLawyers(civilNo);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("getallservices")]
        public IActionResult GetAlServices(int categoryId, int subCategoryId)
        {
            List<ServicesModel> model = new List<ServicesModel>();
            try
            {
                model = _AdminService.GetAllServices(categoryId, subCategoryId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("GetallEntity")]
        public IActionResult GetallEntity()
        {
            List<Lkt_EntityModel> model = new List<Lkt_EntityModel>();
            try
            {
                model = _AdminService.GetAllEntity();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("DeleteEntity")]
        public IActionResult DeleteEntity(Lkt_EntityModel model, string userName)
        {
            string Message;
            try
            {
                Message = _AdminService.DeleteEntity(model, userName);
                return new JsonResult(new { data = true, status = HttpStatusCode.OK, msg = Message });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("GetEntityById")]
        public IActionResult GetEntityById(int EntityId)
        {
            Lkt_EntityModel lkt_EntityModel = new Lkt_EntityModel();
            try
            {
                lkt_EntityModel = _AdminService.GetEntityById(EntityId);
                return new JsonResult(new { data = lkt_EntityModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpPost]
        [Route("InsUpdLKT_Entity")]
        public IActionResult InsUpdLKT_Entity(Lkt_EntityModel model, string userName)
        {
            try
            {
                string Message;
                Message = _AdminService.InsUpdLKT_Entity(model, userName);
                return new JsonResult(new { data = true, status = HttpStatusCode.OK, msg = Message });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }
        }

        [HttpPost]
        [Route("InsertSms")]
        public IActionResult Add(SMS_TransModel model, string smsId)
        {

            try
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
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///




        [HttpGet]
        [Route("getSJCESP_AlertandNotification")]
        [ProducesResponseType(typeof(SJCESP_AlertandNotification), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Int64 CaseID, Boolean Affichable)
        {
            try
            {
                var issue = await _context.SJCESP_AlertandNotification.FindAsync(CaseID, Affichable);
                return issue == null ? NotFound() : Ok(issue);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }


        [HttpGet]
        [Route("getSJCESP_CaseInformation")]
        [ProducesResponseType(typeof(SJCESP_CaseInformation), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdentifiantAndAffichable(Int64 Identifiant, Boolean Affichable)
        {
            try
            {
                var issue = await _context.SJCESP_CaseInformation.FindAsync(Identifiant, Affichable);
                return issue == null ? NotFound() : Ok(issue);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("getSJCESP_Casese")]
        [ProducesResponseType(typeof(SJCESP_Cases), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSJCESP_Cases(string CRNO, Int64 IdDossierCivil)
        {
            try
            {
                var issue = await _context.SJCESP_Cases.FindAsync(CRNO, IdDossierCivil);
                return issue == null ? NotFound() : Ok(issue);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("SJCESP_civilno")]
        [ProducesResponseType(typeof(SJCESP_civilno), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSJCESP_civilno(Int64 IdDossierCivil, string NumeroPieceIdentite)
        {
            try
            {
                var issue = await _context.SJCESP_civilno.FindAsync(IdDossierCivil, NumeroPieceIdentite);
                return issue == null ? NotFound() : Ok(issue);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("SJCESP_Denominations")]
        [ProducesResponseType(typeof(SJCESP_Denominations), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSJCESP_Denominations(Int64 IdDossierCivil, string NumRegistreCommerce)
        {
            try
            {
                var issue = await _context.SJCESP_Denominations.FindAsync(IdDossierCivil, NumRegistreCommerce);
                return issue == null ? NotFound() : Ok(issue);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

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
            try
            {
                var issue = await _context.SJCESP_Judge_Information.FindAsync(IdDossierCivil);
                return issue == null ? NotFound() : Ok(issue);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("SJCESP_LawyerAddress")]
        [ProducesResponseType(typeof(SJCESP_LawyerAddress), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSSJCESP_LawyerAddress(string LicenseNo)
        {
            try
            {
                var issue = await _context.SJCESP_LawyerAddress.FindAsync(LicenseNo);
                return issue == null ? NotFound() : Ok(issue);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("SJCESP_LawyerCaces")]
        [ProducesResponseType(typeof(SJCESP_LawyerCaces), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSJCESP_LawyerCaces(Int64 CaseID, string NumeroPieceIdentite)
        {
            try
            {
                var issue = await _context.SJCESP_LawyerCaces.FindAsync(CaseID, NumeroPieceIdentite);
                return issue == null ? NotFound() : Ok(issue);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("SJCESP_LawyerInformation")]
        [ProducesResponseType(typeof(SJCESP_LawyerCaces), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSJCESP_LawyerInformation(Int64 lawyerid, string CivilNo)
        {
            try
            {
                var issue = await _context.SJCESP_LawyerInformation.FindAsync(lawyerid, CivilNo);
                return issue == null ? NotFound() : Ok(issue);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("SJCESP_RoleParties")]
        [ProducesResponseType(typeof(SJCESP_RoleParties), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSJCESP_RoleParties(Int64 CaseID, string CivilNumberParties)
        {
            try
            {
                var issue = await _context.SJCESP_RoleParties.FindAsync(CaseID, CivilNumberParties);
                return issue == null ? NotFound() : Ok(issue);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("SJCESP_Session_Information")]
        [ProducesResponseType(typeof(SJCESP_Session_Information), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSJCESP_Session_Information(Int64 CaseID)
        {
            try
            {
                var issue = await _context.SJCESP_Session_Information.FindAsync(CaseID);
                return issue == null ? NotFound() : Ok(issue);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }






        [HttpPost]
        [Route("insertalert")]
        public IActionResult Add(AlertModel alertModel, string userName)
        {
            try
            {
                _AdminService.Add(alertModel, userName);
                if (alertModel.alertType == "E")
                {
                    string messageBody = alertModel.message;
                    EmailHelper.sendMail(alertModel.email, alertModel.subject, messageBody);
                }
                return new JsonResult(new { data = alertModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
        }
        [HttpGet]
        [Route("getusers")]
        public IActionResult Getusers()
        {
            //List<UserModel> model = new List<UserModel>();
            try
            {
                var model = _AdminService.GetUsers();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }
        [HttpGet]
        [Route("getalerts")]
        public IActionResult GetAll(int userId)
        {
            //  List<UserModel> model = new List<UserModel>();
            try
            {
                var model = _AdminService.GetAllAlerts(userId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }

        }
        [HttpGet]
        [Route("getAlertbyId")]
        public IActionResult GetAlertById(int Id)
        {
            AlertModel model = new AlertModel();
            try
            {
                model = _AdminService.GetAlertById(Id);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }

        [HttpGet]
        [Route("getUserActivityInfoLog")]
        public IActionResult GetUserActivityInfoLog(int Id, bool isSystemAdmin, string? userName, string? fromdate, string? todate)
        {

            List<UserActivityLog> model = new List<UserActivityLog>();
            try
            {
                model = _AdminService.GetActivityInfoLogs(Id, isSystemAdmin, userName, fromdate, todate);
                //var groupData = model.Select(x => new { group=x.UserName,groupAr=x.UserNameAr }).Distinct();
                //List<UserActivityLogModel> modelPermissions = groupData.Select(x =>
                //                    new UserActivityLogModel()
                //                    {
                //                        items = model.Where(y => y.UserName == x.group)
                //                        .Select(y => new UserActivityLog()
                //                        {
                //                            UserId = y.UserId,
                //                            UserNameAr=y.UserNameAr,
                //                            PageName = y.PageName,
                //                            Message = y.Message,
                //                            TimeLoggedIn = y.TimeLoggedIn,
                //                            TimeLoggedOut = y.TimeLoggedOut

                //                        }).ToList(),
                //                        group = x.group,
                //                        groupAr=x.groupAr
                //                    }).ToList();
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }

        }



    }
}
