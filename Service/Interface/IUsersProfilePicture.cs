using Domain.Entities;
using Domain.Modeles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public  interface IUsersProfilePicture
    {
        Task SavePostImageAsync(PostRequest postRequest);
        Task<PostResponse> CreatePostAsync(PostRequest postRequest);

        /// <summary>
        /// ////////////////////
        /// </summary>
        /// <param name="binary"></param>
        /// <returns></returns>

        public Task PostFileAsync(IFormFile fileData, FileType fileType);

        public Task PostMultiFileAsync(List<FileUploadModel> fileData);

        public Task DownloadFileById(int userId);

        public PostRequest GetFileName(int UserId);

        //public   byte[]  GetImage(string UserId, string imageName);
    }
}
