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
                                        userPermissionId = y.userPermissionId,
                                        userId = y.userId,
                                        pageId = y.pageId,
                                        ReadPermission = y.ReadPermission,
                                        WritePermission = y.WritePermission,
                                        DeletePermission = y.DeletePermission,
                                        PageNameEn = y.PageNameEn,
                                        pageNameAr = y.pageNameAr,
                                        pageModuleEn = y.pageModuleEn,
                                        UsernameEn=y.UsernameEn
                                        
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
        [HttpGet]
        [Route("GetDelegatedUserPermission")]
        public IActionResult GetDelegatedUserPermission(int civilNo, int roleId, int delegatedUserId)
        {
            List<DelegationModel> model = new List<DelegationModel>();
            model = _delegationService.GetDelegatedUserPermission(civilNo, roleId, delegatedUserId);

            var distinctModules = model.Select(x => x.pageModuleEn).Distinct();
            List<UserDelegationModel> modelPermissions = distinctModules.Select(x =>
                                new UserDelegationModel()
                                {
                                    items = model.Where(y => y.pageModuleEn == x)
                                    .Select(y => new DelegationModel()
                                    {
                                        userPermissionId = y.userPermissionId,
                                        DelegatedByUserId = y.DelegatedByUserId,
                                        UsernameEn = y.UsernameEn,
                                        UsernameAr = y.UsernameAr,
                                        pageModuleAr = y.pageModuleAr,
                                        userId = y.userId,
                                        pageId = y.pageId,
                                        ReadPermission = y.ReadPermission,
                                        WritePermission = y.WritePermission,
                                        DeletePermission = y.DeletePermission,
                                        PageNameEn = y.PageNameEn,
                                        pageNameAr = y.pageNameAr,
                                        pageModuleEn = y.pageModuleEn,
                                        EffectiveFrom=y.EffectiveFrom,
                                        EffectiveTo=y.EffectiveTo,
                                        CivilExpiryDate=y.CivilExpiryDate

                                    }).ToList(),
                                    group = x,
                                }).ToList();

            return new JsonResult(new { data = modelPermissions, status = HttpStatusCode.OK });
        }
        [HttpPost]
        [Route("AddDelegationPermission")]
        public IActionResult Add(List<UserDelegatePermissionModel> model, string userId, string userName)
        {
            foreach (UserDelegatePermissionModel item in model)
            {
                if (item.UserPermissionId > 0)
                {
                    UserDelegatePermissionModel _roleModel = _delegationService.GetUserPermissionById(item.UserPermissionId);
                    item.CreatedDate = _roleModel.CreatedDate;
                    item.CreatedBy = _roleModel.CreatedBy;
                    _delegationService.UpdateUserDelegate(item, userName);
                }
                else
                {
                    _delegationService.AddUserDelegate(item, userName);
                }
            }

            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpGet]
        [Route("GetUserDelegatedPermission")]
        public IActionResult GetUserDelegatedPermission(int delegatedByUserId)
        {
            List<DelegationModel> model = new List<DelegationModel>();
            model = _delegationService.GetUserDelegatedPermission(delegatedByUserId);
            return new JsonResult(new { data = model, status = HttpStatusCode.OK });
        }

        [HttpDelete]
        [Route("DeleteUserDelegation")]
        public IActionResult DeleteUserDelegation(int userId)
        {
            _delegationService.DeleteUserDelegation(userId);
            return new JsonResult(new { data = userId, status = HttpStatusCode.OK });
        }
    }
}

