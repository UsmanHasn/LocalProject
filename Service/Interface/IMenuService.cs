using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IMenuService
    {
        List<MenuModel> GetAllMenu();
        List<MenuModel> GetAllMenuCompany();
        Task<bool> Add(MenuModel menuViewModel);
        Task<MenuModel> GetMenuById(int Id);
        Task<bool> UpdateMenu(int Id, MenuModel menuViewModel);
        Task<bool> DeleteMenu(int Id);
    }
}
