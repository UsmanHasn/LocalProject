using Domain.Entities;
using Domain.Entities.Lookups;
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
        List<MenuModel> GetAllMenu(int profileId, string profileType, int profileDelegatedId);
        List<MenuModel> GetAllMenuCompany();

        List<MenuModel> GetMenu();
        bool Add(MenuModel menuViewModel,string username);
        MenuModel GetMenuById(int Id);
        bool UpdateMenu(int Id, MenuModel menuViewModel, string username);
        bool DeleteMenu(int Id);
        List<PagesModel> Getpages();

        List<MenuModel> getParentMenu();
    }
}
