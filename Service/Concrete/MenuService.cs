using Data.Interface;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Service.Concrete
{
    public class MenuService : IMenuService
    {
        private readonly IRepository<Menu> _menuRepository;
        public MenuService(IRepository<Menu> menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public bool Add(MenuModel menuViewModel, string username)
        {
            SqlParameter[] spParams = new SqlParameter[11];
            spParams[0] = new SqlParameter("MenuId", menuViewModel.Id);
            spParams[1] = new SqlParameter("Name", menuViewModel.Name);
            spParams[2] = new SqlParameter("NameAr", menuViewModel.NameAr);
            spParams[3] = new SqlParameter("MenuType", menuViewModel.Type);
            spParams[4] = new SqlParameter("ParentMenuId", menuViewModel.ParentId);
            spParams[5] = new SqlParameter("UrlPath", menuViewModel.UrlPath);
            spParams[6] = new SqlParameter("Sequence", menuViewModel.Sequence);
            spParams[7] = new SqlParameter("PageId", menuViewModel.PageId);
            spParams[8] = new SqlParameter("CreatedBy", username);
            spParams[9] = new SqlParameter("Deleted", false);
            spParams[10] = new SqlParameter("DML", "I");

            _menuRepository.ExecuteStoredProcedure("Sp_dml_menu", spParams);
            return true;
        }

        public bool DeleteMenu(int Id)
        {
            SqlParameter[] spParams = new SqlParameter[11];
            spParams[0] = new SqlParameter("MenuId",Id);
            spParams[1] = new SqlParameter("Name", "");
            spParams[2] = new SqlParameter("NameAr", "");
            spParams[3] = new SqlParameter("MenuType", "");
            spParams[4] = new SqlParameter("ParentMenuId", "");
            spParams[5] = new SqlParameter("UrlPath", "");
            spParams[6] = new SqlParameter("Sequence","");
            spParams[7] = new SqlParameter("PageId", "");
            spParams[8] = new SqlParameter("CreatedBy", "");
            spParams[9] = new SqlParameter("Deleted", true);
            spParams[10] = new SqlParameter("DML", "D");

            _menuRepository.ExecuteStoredProcedure("Sp_dml_menu", spParams);
            return true;
        }

        public List<MenuModel> GetAllMenu(int profileId, string profileType, int profileDelegatedId)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            if (profileType == "D")
            {
                spParams = new SqlParameter[2];
                spParams[0] = new Microsoft.Data.SqlClient.SqlParameter("UserId", profileId);
                spParams[1] = new Microsoft.Data.SqlClient.SqlParameter("DelegateUserId", profileDelegatedId);
            }
            else if (profileType != "R")
            {
                spParams[0] = new Microsoft.Data.SqlClient.SqlParameter("UserId", profileId);
            }
            else
            {
                spParams[0] = new Microsoft.Data.SqlClient.SqlParameter("RoleId", profileId);
            }
            var dataMenu = _menuRepository.ExecuteStoredProcedure<MenuModel>("sjc_GetMenu", spParams);
            var model = dataMenu.Where(x => x.Type == "M" && x.ParentId == 0).Select(x => new MenuModel()
            {
                Id = x.Id,
                Name = x.Name,
                NameAr = x.NameAr,
                Sequence = x.Sequence,
                UrlPath = x.UrlPath,
                Type = x.Type,
                Childrens = dataMenu
                .Where(y => y.ParentId == x.Id).Select(y => new MenuModel()
                {
                    Id = y.Id,
                    Name = y.Name,
                    NameAr = y.NameAr,
                    Sequence = y.Sequence,
                    UrlPath = y.UrlPath,
                    Type = y.Type,
                    ParentId = x.Id,
                    Childrens = dataMenu.Where(z => z.ParentId == y.Id).Select(z => new MenuModel()
                    {
                        Id = z.Id,
                        Name = z.Name,
                        NameAr = z.NameAr,
                        Sequence = z.Sequence,
                        UrlPath = z.UrlPath,
                        Type = z.Type,
                        ParentId = y.Id
                        //Childrens = dataMenu.Where(a => a.ParentId == a.Id).Select(a => new MenuModel()
                        //            {
                        //                Id = a.Id,
                        //                Name = a.Name,
                        //                NameAr = a.NameAr,
                        //                Sequence = a.Sequence,
                        //                UrlPath = a.UrlPath,
                        //                Type = a.Type,
                        //            }).ToList()
                    }).ToList()
                })
                .ToList()
            }).ToList();
            model = FilterMenus(model);
            return model;
        }
        // Define a recursive method to filter the menus
        List<MenuModel> FilterMenus(List<MenuModel> menus)
        {
            List<MenuModel> filteredMenus = new List<MenuModel>();

            foreach (var menu in menus)
            {
                // Recursive call to filter children menus
                if (menu.Childrens != null)
                {
                    menu.Childrens = FilterMenus(menu.Childrens);
                }
                

                // Check if menu type is "M" and it has no children
                if (!(menu.Type == "M" && string.IsNullOrEmpty(menu.UrlPath) && menu.Childrens.Count == 0))
                {
                    filteredMenus.Add(menu);
                }
            }

            return filteredMenus;
        }
        public List<MenuModel> GetAllMenuCompany()
        {
            List<MenuModel> model = new List<MenuModel>();
            model.Add(new MenuModel()
            {
                Id = 1,
                Name = "Home",
                Description = "Home...",
                Sequence = 1,
                UrlPath = "dashboards",
                Type = "M",
                Childrens = null
            });
            model.Add(new MenuModel()
            {
                Id = 5,
                Name = "Court Admin",
                Description = "Court Admin...",
                Sequence = 3,
                UrlPath = "",
                Type = "M",
                Childrens = new List<MenuModel>()
                {
                    new MenuModel()
                            {
                                Id = 11,
                                Name = "Courts",
                                Description = "Courts...",
                                Sequence = 1,
                                UrlPath = "courts",
                                Type = "D",
                            },
                            new MenuModel()
                            {
                                Id = 12,
                                Name = "Lawyers",
                                Description = "Lawyers...",
                                Sequence = 2,
                                UrlPath = "lawyers",
                                Type = "D",
                            },
                            new MenuModel()
                            {
                                Id = 13,
                                Name = "Cases",
                                Description = "Cases...",
                                Sequence = 3,
                                UrlPath = "cases",
                                Type = "D",
                            },

                }
            });
            model.Add(new MenuModel()
            {
                Id = 14,
                Name = "Reports",
                Type = "M",
                UrlPath = "",
                Childrens = new List<MenuModel>() {
                new MenuModel()
                    {
                        Id = 3,
                        Name = "Activity Log",
                        Description = "Activity Log...",
                        Sequence = 1,
                        UrlPath = "activitylog",
                        Type = "D",
                    }
                }
            });
            return model;
        }

        public MenuModel GetMenuById(int Id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("MenuId", Id);
            return _menuRepository.ExecuteStoredProcedure<MenuModel>("sjc_GetAllMenu", parameters).FirstOrDefault();
        }

        public bool UpdateMenu(int Id, MenuModel menuViewModel, string username)
        {
            SqlParameter[] spParams = new SqlParameter[11];
            spParams[0] = new SqlParameter("MenuId", menuViewModel.Id);
            spParams[1] = new SqlParameter("Name", menuViewModel.Name);
            spParams[2] = new SqlParameter("NameAr", menuViewModel.NameAr);
            spParams[3] = new SqlParameter("MenuType", menuViewModel.Type);
            spParams[4] = new SqlParameter("ParentMenuId", menuViewModel.ParentId);
            spParams[5] = new SqlParameter("UrlPath", menuViewModel.UrlPath);
            spParams[6] = new SqlParameter("Sequence", menuViewModel.Sequence);
            spParams[7] = new SqlParameter("PageId", menuViewModel.PageId);
            spParams[8] = new SqlParameter("CreatedBy", username);
            spParams[9] = new SqlParameter("Deleted", false);
            spParams[10] = new SqlParameter("DML", "U");

            _menuRepository.ExecuteStoredProcedure("Sp_dml_menu", spParams);
            return true;
        }

        public List<PagesModel> Getpages()
        {
           // List<PagesModel> model = new List<PagesModel>();
            SqlParameter[] spParams = new SqlParameter[0];
            var dataMenu = _menuRepository.ExecuteStoredProcedure<PagesModel>("sjc_GetPages", spParams);
            var model = dataMenu.Select(x => new PagesModel()
            {
                Id = x.Id,
                PageName = x.PageName,
                PageNameAr=x.PageNameAr
            }).ToList();
            return model;
        }

        public List<MenuModel> getParentMenu()
        {
            SqlParameter[] spParams = new SqlParameter[0];
            var dataMenu = _menuRepository.ExecuteStoredProcedure<MenuModel>("sjc_GetParentMenu", spParams);
            var model = dataMenu.Select(x => new MenuModel()
            {
                Id = x.Id,
                Name = x.Name,
                NameAr=x.NameAr
            }).ToList();
            return model;
        }

        public List<MenuModel> GetMenu()
        {
            // List<PagesModel> model = new List<PagesModel>();
            SqlParameter[] spParams = new SqlParameter[0];
            //spParams[0] = new SqlParameter("MenuId", menuId);
            var dataMenu = _menuRepository.ExecuteStoredProcedure<MenuModel>("sjc_GetAllMenu", spParams);
            var model = dataMenu.Select(x => new MenuModel()
            {
                Id = x.Id,
                Name = x.Name,
                NameAr=x.NameAr,
                Sequence=x.Sequence
            }).ToList();
            return model;
        }
    }
}