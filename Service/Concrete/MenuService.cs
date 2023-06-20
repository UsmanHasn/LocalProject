using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class MenuService : IMenuService
    {
        public Task<bool> Add(MenuModel menuViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMenu(int Id)
        {
            throw new NotImplementedException();
        }

        public List<MenuModel> GetAllMenu()
        {
            List<MenuModel> model = new List<MenuModel>();
            model.Add(new MenuModel()
            {
                Id = 1,
                Name = "Home",
                Description = "Home...",
                Sequence = 1,
                UrlPath = "dashboards",         
                Type= "M",
                Childrens = null
            });
            model.Add(new MenuModel()
            {
                Id = 2,
                Name = "Account Details",
                Description = "Account Details...",
                Sequence = 2,
                UrlPath = "",
                Type = "M",
                Childrens = new List<MenuModel>() 
                {
                    new MenuModel()
                    {
                        Id = 3,
                        Name = "Activity Log",
                        Description = "Activity Log...",
                        Sequence = 1,
                        UrlPath = "activitylog",
                        Type = "D",
                    },
                    new MenuModel()
                    {
                        Id = 4,
                        Name = "User Profile",
                        Description = "User Profile...",
                        Sequence = 1,
                        UrlPath = "userprofile",
                        Type = "D",
                    }
                }
            });
            model.Add(new MenuModel()
            {
                Id = 5,
                Name = "Administration",
                Description = "Administration...",
                Sequence = 3,
                UrlPath = "",
                Type = "M",
                Childrens = new List<MenuModel>()
                {
                    new MenuModel()
                    {
                        Id = 6,
                        Name = "System Admin",
                        Description = "System Admin...",
                        Sequence = 1,
                        UrlPath = "",
                        Type = "M",
                        Childrens = new List<MenuModel>()
                        {
                            new MenuModel()
                            {
                                Id = 7,
                                Name = "Roles",
                                Description = "Roles...",
                                Sequence = 1,
                                UrlPath = "roles",
                                Type = "D",
                            },
                            new MenuModel()
                            {
                                Id = 8,
                                Name = "Permissions",
                                Description = "Permissions...",
                                Sequence = 2,
                                UrlPath = "permissions",
                                Type = "D",
                            },
                            new MenuModel()
                            {
                                Id = 9,
                                Name = "Users",
                                Description = "Users...",
                                Sequence = 3,
                                UrlPath = "users",
                                Type = "D",
                            }
                        }
                    },
                    new MenuModel()
                    {
                        Id = 10,
                        Name = "Court Admin",
                        Description = "Court Admin...",
                        Sequence = 2,
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
                            }
                        }
                    },

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
