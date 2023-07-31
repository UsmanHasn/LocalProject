using Data.Context;
using Data.Interface;
using Domain.Entities.Lookups;
using Domain.Helper;
using Domain.Modeles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Service.Concrete
{
    public class UsersProfilePicture : IUsersProfilePicture
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext socialDbContext;

        public UsersProfilePicture(IWebHostEnvironment repository, ApplicationDbContext dbContextClass)
        {
            environment = repository;
            this.socialDbContext = dbContextClass;
        }
        public async Task<PostResponse> CreatePostAsync(PostRequest postRequest)
        {
            var post = new Domain.Entities.UsersProfilePicture
            {
                UserId = postRequest.UserId,
                CreatedBy = postRequest.CreatedBy,
                FilePath = postRequest.FilePath,
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "123",
                Deleted = "true"
            };

            var postEntry = await socialDbContext.UsersProfilePicture.AddAsync(post);

            var saveResponse = await socialDbContext.SaveChangesAsync();

            if (saveResponse < 0)
            {
                return new PostResponse { Success = false, Error = "Issue while saving the post", ErrorCode = "CP01" };
            }

            var postEntity = postEntry.Entity;
            var postModel = new UsersProfilePictureModel
            {
                Id = postEntity.UserId,
                CreatedBy = postEntity.CreatedBy,
                LastModifiedDate = DateTime.Now,
                LastModifiedBy="123",
                FilePath = Path.Combine(postEntity.FilePath),
                UserId = postEntity.UserId

            };

            return new PostResponse { Success = true, Post = postModel };

        }

        public async Task SavePostImageAsync(PostRequest postRequest)
        {
            var uniqueFileName = FileHelper.GetUniqueFileName(postRequest.Image.FileName);

            var uploads = Path.Combine(environment.WebRootPath, "users", "posts", postRequest.UserId.ToString());

            var filePath = Path.Combine(uploads, uniqueFileName);

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            await postRequest.Image.CopyToAsync(new FileStream(filePath, FileMode.Create));

            postRequest.FilePath = filePath;

            return;
        }



        /// <summary>
        /// ////////////////////
        /// </summary>
        /// <param name="binary"></param>
        /// <returns></returns>
        /// 


        public async Task DownloadFileById(int userId)
        {
            try
            {
                var file = socialDbContext.UsersProfilePicture.Where(x => x.UserId == userId).FirstOrDefaultAsync();

                var content = new System.IO.MemoryStream(file.Result.FileContent);
                var path = Path.Combine(
                   Directory.GetCurrentDirectory(), "FileDownloaded",
                   file.Result.FileName);

                await CopyStream(content, path);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }

        public async Task PostFileAsync(IFormFile fileData, FileType fileType)
        {
            try
            {
                var fileDetails = new Domain.Entities.UsersProfilePicture()
                {
                    //  UserId = 0,
                    FileName = fileData.FileName,
                    FileExt = fileType,
                    CreatedBy = "123",
                    CreatedDate = DateTime.Now,
                    LastModifiedBy = "234",
                    LastModifiedDate = DateTime.Now,
                    Deleted = "1",
                    ContentLength = "23",
                    FilePath = "123",
                    UserId = 14,
                };

                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    fileDetails.FileContent = stream.ToArray();
                }

                var result = socialDbContext.UsersProfilePicture.Add(fileDetails);
                await socialDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task PostMultiFileAsync(List<FileUploadModel> fileData)
        {
            throw new NotImplementedException();
        }
    }
}
