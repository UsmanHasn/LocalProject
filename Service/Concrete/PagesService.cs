using Data.Interface;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class PagesService : IPagesService
    {
        private readonly IRepository<Pages> _pagesRepository;

        public PagesService(IRepository<Pages> pagesRepository)
        {
            _pagesRepository = pagesRepository;
        }

        public bool Addpages(PagesModel pagesModel, string userName)
        {
            Pages pages = new Pages() 
            { 
            PageName = pagesModel.PageName,
            PageNameAr = pagesModel.PageNameAr,
            PageModuleEn=pagesModel.PageModuleEn,
            PageModuleAr=pagesModel.PageModuleAr
            };
            _pagesRepository.Create(pages, userName);
            _pagesRepository.Save();
            return true;
        }

        public bool Deletepages(int Id, string userName)
       {
            try
            {
                PagesModel pageModel = this.GetpagesById(Id);
                Pages pages = new Pages()
                {
                    PageName = pageModel.PageName,
                    PageNameAr = pageModel.PageNameAr,
                    PageModuleEn=pageModel.PageModuleEn,
                    PageModuleAr=pageModel.PageModuleAr,
                    CreatedBy = pageModel.CreatedBy,
                    CreatedDate = pageModel.CreatedDate,
                    Id = pageModel.Id,
                    Deleted = true
                };
                _pagesRepository.Delete(pages,userName);
                _pagesRepository.Save();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<PagesModel> GetAllPages()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            return _pagesRepository.ExecuteStoredProcedure<PagesModel>("sjc_GetPages", parameters).ToList();
        }

        public PagesModel GetpagesById(int Id)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("pageid", Id);
             return _pagesRepository.ExecuteStoredProcedure<PagesModel>("sjc_GetPages", parameters).FirstOrDefault();
        }
      

        public bool Updatepages(PagesModel pagesModel, string userName)
        {
            try
            {
                Pages pages = new Pages()
                {
                    Id = pagesModel.Id,
                    PageName = pagesModel.PageName,
                    PageNameAr = pagesModel.PageNameAr,
                    PageModuleEn=pagesModel.PageModuleEn,
                    PageModuleAr=pagesModel.PageModuleAr,
                    CreatedBy = pagesModel.CreatedBy,
                    CreatedDate = pagesModel.CreatedDate,
                   
                };
                _pagesRepository.Update(pages, userName);
                _pagesRepository.Save();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
