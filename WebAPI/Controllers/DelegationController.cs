using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Net;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/delegations/")]
    public class DelegationController : Controller
    {
        private readonly IDelegationService? _delegationService;
        public DelegationController(IDelegationService delegationService)
        {
            _delegationService = delegationService;
        }

        [HttpGet]
        [Route("GetAllDelegations")]
        public IActionResult GetAllDelegations(string civilId)
        {
            List<DelegationModel> model = new List<DelegationModel>();
            model = _delegationService.GetAllDelegations(civilId);

            var distinctModules = model.Select(x => x.pageModuleEn).Distinct();
            List<UserDelegationModel> modelPermissions = distinctModules.Select(x =>
                                new UserDelegationModel()
                                {
                                    items = model.Where(y => y.pageModuleEn == x)
                                    .Select(y => new DelegationModel()
                                    {
                                        userId = y.userId,
                                        pageId = y.pageId,
                                        ReadPermission = y.ReadPermission,
                                        WritePermission = y.WritePermission,
                                        DeletePermission = y.DeletePermission,
                                        PageNameEn = y.PageNameEn,
                                        pageNameAr = y.pageNameAr,
                                        pageModuleEn = y.pageModuleEn,
                                        Username=y.Username
                                        
                                    }).ToList(),
                                    group = x,
                                }).ToList();

            return new JsonResult(new { data = modelPermissions, status = HttpStatusCode.OK });
        }


        [HttpPost]
        [Route("manageDelegation")]
        public IActionResult Add(DelegationModel model, string userName)
        {
            _delegationService.Add(model, userName);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }
    }
}
