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
        public Task<bool> Add(MenuModel menuViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMenu(int Id)
        {
            throw new NotImplementedException();
        }

        public List<MenuModel> GetAllMenu(int profileId, string profileType)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            if (profileType != "R")
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

        public Task<MenuModel> GetMenuById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMenu(int Id, MenuModel menuViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
