using Data.Interface;
using Domain.Entities;
using MailKit.Search;
using Microsoft.Data.SqlClient;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class PagesService : IPagesService
    {
        private readonly IRepository<SYS_Pages> _pagesRepository;

        public PagesService(IRepository<SYS_Pages> pagesRepository)
        {
            _pagesRepository = pagesRepository;
        }

        public bool Addpages(PagesModel pagesModel, string userName)
        {
            SYS_Pages pages = new SYS_Pages() 
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
                if (pageModel != null)
                {
                    SYS_Pages pages = new SYS_Pages()
                    {
                        PageName = pageModel.PageName,
                        PageNameAr = pageModel.PageNameAr,
                        PageModuleEn = pageModel.PageModuleEn,
                        PageModuleAr = pageModel.PageModuleAr,
                        CreatedBy = pageModel.CreatedBy,
                        CreatedDate = pageModel.CreatedDate,
                        Id = pageModel.Id,
                        Deleted = true
                    };
                    _pagesRepository.Delete(pages, userName);
                    _pagesRepository.Save();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public PageModelPagination GetAllPages(int pageSize, int pageNumber, string? SearchText)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("pageSize", pageSize);
            param[1] = new SqlParameter("pageNumber", pageNumber);
            param[2] = new SqlParameter("SearchText", SearchText);
            var data = _pagesRepository.ExecuteStoredProcedure<PagesModel>("sjc_GetPagesPagination", param).ToList();
            int countItem = 0;
            if (SearchText != null)
            {
                SqlParameter[] paramSearch = new SqlParameter[1];
                paramSearch[0] = new SqlParameter("SearchText", SearchText);

                var count = _pagesRepository.ExecuteStoredProcedure<TotalCountModel>("sjc_GetAll_PageCount", paramSearch).FirstOrDefault();
                countItem = count.TotalCount;
            }
            else
            {
                var count = _pagesRepository.ExecuteStoredProcedure<TotalCountModel>("sjc_GetAll_PageCount").FirstOrDefault();
                countItem = count.TotalCount;
            }
            PageModelPagination paginatedLanguageLookupModel = new PageModelPagination()
            {
                PaginatedData = data,
                TotalCount = countItem
            };
            return paginatedLanguageLookupModel;
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
                SYS_Pages pages = new SYS_Pages()
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
