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
                URL = "url",         
           
                Type= "M",
            });
            model.Add(new MenuModel()
            {
                Id = 2,
                Name = "Account Details",
                Description = "Account Details...",
                URL = "url",
            
                Type = "M",
            });
            model.Add(new MenuModel()
            {
                Id = 3,
                Name = "Activity Log",
                Description = "Activity Log...",
                URL = "url",
                ParentId = 2,
                Type = "D",
            });
            model.Add(new MenuModel()
            {
                Id = 4,
                Name = "User Profile",
                Description = "User Profile...",
                URL = "url",
                ParentId = 2,
                Type = "D",
            });
            model.Add(new MenuModel()
            {
                Id = 5,
                Name = "Administration",
                Description = "Administration...",
                URL = "url",
    
                Type = "M",
            });
            model.Add(new MenuModel()
            {
                Id = 6,
                Name = "System Admin",
                Description = "System Admin...",
                URL = "url",
                ParentId = 5,
                Type = "D",
            });
            model.Add(new MenuModel()
            {
                Id = 7,
                Name = "Roles",
                Description = "Roles...",
                URL = "url",
                ParentId = 5,
                Type = "D",
            });
            model.Add(new MenuModel()
            {
                Id = 8,
                Name = "Permissions",
                Description = "Permissions...",
                URL = "url",
                ParentId = 5,
                Type = "D",
            });
            model.Add(new MenuModel()
            {
                Id = 8,
                Name = "Users",
                Description = "Users...",
                URL = "url",
                ParentId = 5,
                Type = "D",
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
