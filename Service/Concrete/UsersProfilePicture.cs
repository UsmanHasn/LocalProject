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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.IO;

namespace Service.Concrete
{
    public class UsersProfilePicture : IUsersProfilePicture
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext socialDbContext;
        public readonly IRepository<SYS_SystemSettings> _systemSettingRepository;
        public string _FileName = "";
        public UsersProfilePicture(IWebHostEnvironment repository, ApplicationDbContext dbContextClass, IRepository<SYS_SystemSettings> systemSettingRepository)
        {
            environment = repository;
            this.socialDbContext = dbContextClass;
            _systemSettingRepository = systemSettingRepository;
        }
        public async Task<PostResponse> CreatePostAsync(PostRequest postRequest)
        {
           
            var post = new Domain.Entities.SEC_UsersProfilePicture
            {
                UserId = postRequest.UserId,
                CreatedBy = postRequest.CreatedBy,
                FilePath = postRequest.FilePath,
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = postRequest.LastModifiedBy,
                Deleted = "false"
            };
            try
            {
                SqlParameter[] spParams = new SqlParameter[1];
                spParams[0] = new SqlParameter("UserId", postRequest.UserId);
                var _find = _systemSettingRepository.ExecuteStoredProcedure<PostRequest>("Sjc_GetUsersProfilePicture", spParams).FirstOrDefault();// socialDbContext.UsersProfilePicture.Find(28);
                if (_find == null)
                {
                    var _ = await socialDbContext.SEC_UsersProfilePicture.AddAsync(post);
                }
                else
                {
                    SqlParameter[] spParam = new SqlParameter[3];
                    spParam[0] = new SqlParameter("FilePath", postRequest.FilePath);
                    spParam[1] = new SqlParameter("UserId", postRequest.UserId);
                    spParam[2] = new SqlParameter("FileName", _FileName);
                    _systemSettingRepository.ExecuteStoredProcedure("Sjc_UpdateUsersProfilePicture", spParam);

                    //var userProfile =  socialDbContext.UsersProfilePicture.Find(28);
                    //userProfile.FilePath = postRequest.FilePath;
                    //userProfile.LastModifiedDate = DateTime.Now;
                    //userProfile.LastModifiedBy = postRequest.LastModifiedBy;
                    //var _ = socialDbContext.UsersProfilePicture.Update(userProfile);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           
            try
            {
                var saveResponse = await socialDbContext.SaveChangesAsync();

                if (saveResponse < 0)
                {
                    return new PostResponse { Success = false, Error = "Issue while saving the post", ErrorCode = "CP01" };
                }
            }
            catch (Exception ex)
            {

            }
            var postModel = new UsersProfilePictureModel
            {
                Id = postRequest.UserId,
                CreatedBy = postRequest.CreatedBy,
                LastModifiedDate = DateTime.Now,
                LastModifiedBy= postRequest.LastModifiedBy,
                FilePath = postRequest.FilePath,
                UserId = postRequest.UserId

            };

            return new PostResponse { Success = true, Post = postModel };

        }

        public async Task SavePostImageAsync(PostRequest postRequest)
        {
            var uniqueFileName = FileHelper.GetUniqueFileName(postRequest.Image.FileName);
            _FileName = uniqueFileName;
            var uploads = Path.Combine(environment.WebRootPath, "users", "posts", postRequest.UserId.ToString());

            var filePath = Path.Combine(uploads, uniqueFileName);

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                await postRequest.Image.CopyToAsync(fs);
            }
           
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
                var file = socialDbContext.SEC_UsersProfilePicture.Where(x => x.UserId == userId).FirstOrDefaultAsync();

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
                var fileDetails = new Domain.Entities.SEC_UsersProfilePicture()
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

                var result = socialDbContext.SEC_UsersProfilePicture.Add(fileDetails);
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

        public PostRequest GetFileName(int UserId)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("UserId", UserId);
            var _find = _systemSettingRepository.ExecuteStoredProcedure<PostRequest>("Sjc_GetUsersProfilePicture", spParams).FirstOrDefault();// socialDbContext.UsersProfilePicture.Find(28);
            return _find;
        }

        public bool UpdateImageUrl(int UserId)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("UserId", UserId);
            _systemSettingRepository.ExecuteStoredProcedure("Sjc_UpdateUsersFilePath", spParams);// socialDbContext.UsersProfilePicture.Find(28);
            return true;
        }

        //public byte[] GetImage(string UserId, string imageName)
        // {
        //     var imagePath = Path.Combine(environment.WebRootPath, "users", "posts", UserId, imageName);
        //     //var imageBytes = File.ReadAllBytes(imagePath);
        //     return File.ReadAllBytes(imagePath);
        // }
    }
}