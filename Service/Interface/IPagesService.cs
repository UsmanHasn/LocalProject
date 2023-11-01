using Azure;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IPagesService
    {
        PageModelPagination GetAllPages(int pageSize, int pageNumber, string? SearchText);
        bool Addpages(PagesModel pagesModel, string userName);
        PagesModel GetpagesById(int Id);
        bool Updatepages(PagesModel pagesModel, string userName);
        bool Deletepages(int Id, string userName);
    }
}
