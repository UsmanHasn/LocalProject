﻿using Domain.Entities;
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
        private readonly IUserService _userService;
        public DelegationController(IDelegationService delegationService, IUserService userService)
        {
            _delegationService = delegationService;
            _userService = userService;
        }

        [HttpGet]
        [Route("GetAllDelegations")]
        public IActionResult GetAllDelegations(string civilId)
        {
            List<DelegationModel> model = new List<DelegationModel>();
            try
            {
                model = _delegationService.GetAllDelegations(civilId);

                var distinctModules = model.Select(x => new { pageModuleEn = x.pageModuleEn, pageModuleAr = x.pageModuleAr }).Distinct();
                List<UserDelegationModel> modelPermissions = distinctModules.Select(x =>
                                    new UserDelegationModel()
                                    {
                                        items = model.Where(y => y.pageModuleEn == x.pageModuleEn)
                                        .Select(y => new DelegationModel()
                                        {
                                            userPermissionId = y.userPermissionId,
                                            userId = y.userId,
                                            pageId = y.pageId,
                                            ReadPermission = y.ReadPermission,
                                            WritePermission = y.WritePermission,
                                            DeletePermission = y.DeletePermission,
                                            NameEn = y.NameEn,
                                            NameAr = y.NameAr,
                                            pageModuleEn = y.pageModuleEn,
                                            UsernameEn = y.UsernameEn

                                        }).ToList(),
                                        group = x.pageModuleEn,
                                        groupAr = x.pageModuleAr,
                                    }).ToList();

                return new JsonResult(new { data = modelPermissions, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
        }


        [HttpPost]
        [Route("manageDelegation")]
        public IActionResult Add(DelegationModel model, string userName)
        {
            try
            {
                _delegationService.Add(model, userName);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }
        }
        [HttpGet]
        [Route("GetDelegatedUserPermission")]
        public IActionResult GetDelegatedUserPermission(int civilNo, int roleId, int delegatedUserId)
        {
            List<DelegationModel> model = new List<DelegationModel>();
            try
            {
                model = _delegationService.GetDelegatedUserPermission(civilNo, roleId, delegatedUserId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
                var distinctModules = model.Select(x => new { pageModeueEn = x.pageModuleEn, pageModuleAr = x.pageModuleAr }).Distinct();
                List<UserDelegationModel> modelPermissions = distinctModules.Select(x =>
                                    new UserDelegationModel()
                                    {
                                        items = model.Where(y => y.pageModuleEn == x.pageModeueEn)
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
                                            NameEn = y.NameEn,
                                            NameAr = y.NameAr,
                                            pageModuleEn = y.pageModuleEn,
                                            EffectiveFrom = y.EffectiveFrom,
                                            EffectiveTo = y.EffectiveTo,
                                            CivilExpiryDate = y.CivilExpiryDate

                                        }).ToList(),
                                        group = x.pageModeueEn,
                                        groupAr = x.pageModuleAr
                                    }).ToList();

                return new JsonResult(new { data = modelPermissions, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
        }
        [HttpPost]
        [Route("AddDelegationPermission")]
        public IActionResult Add(List<UserDelegatePermissionModel> model, string userId, string userName, string delegatedUserName)
        {
            try
            {
                _delegationService.DeleteUserDelegation(model.First().UserId, model.First().DelegatedUserId);
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
                if (Convert.ToInt32(userId) > 0)
                {
                    _userService.AddActivity(Convert.ToInt32(userId), "Delegation", "Delegate Role to " + delegatedUserName, DateTime.Now, userName);
                }
                _userService.InsertAlert(model.First().UserId, "", userName, "", "", userName + " Delegate Role to you", userName + " Delegate Role to you");
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
        }

        [HttpGet]
        [Route("GetUserDelegatedPermission")]
        public IActionResult GetUserDelegatedPermission(int delegatedByUserId)
        {
            List<DelegationModel> model = new List<DelegationModel>();
            try
            {
                model = _delegationService.GetUserDelegatedPermission(delegatedByUserId);
                return new JsonResult(new { data = model, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
        }

        [HttpDelete]
        [Route("DeleteUserDelegation")]
        public IActionResult DeleteUserDelegation(int userId, int delegatedByUserId)
        {
            try
            {
                _delegationService.DeleteUserDelegation(userId, delegatedByUserId);
                return new JsonResult(new { data = userId, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
        }

        [HttpGet]
        [Route("CheckDelegatedUser")]
        public IActionResult CheckDelegatedUser(string CivilNo, int delegatedUserBy)
        {
            try
            {
                var data = _delegationService.CheckDelegatedUser(CivilNo, delegatedUserBy);
                if (data != null)
                {
                    return new JsonResult(new { data = data, msg = "exist", status = HttpStatusCode.OK });
                }
                else
                {
                    return new JsonResult(new { data = data, msg = "notexist", status = HttpStatusCode.OK });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
        }
    }
}

