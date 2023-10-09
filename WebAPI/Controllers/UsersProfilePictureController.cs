using Data.Context;
using Domain.Entities;
using Domain.Modeles;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System;
using System.Data.Entity;
using System.IO;
using System.Net;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersProfilePictureController : Controller
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly ILogger<UsersProfilePictureController> logger;
        private readonly IUsersProfilePicture postService;
        private readonly IWebHostEnvironment environment;
        public string userId = "";
        public UsersProfilePictureController(IWebHostEnvironment repository, ApplicationDbContext Db, ILogger<UsersProfilePictureController> logger, IUsersProfilePicture postService)
        {
            environment = repository;
            this._DbContext = Db;
            this.logger = logger;
            this.postService = postService;
        }
        [HttpGet]
        [Route("UserProfile")]
        [ProducesResponseType(typeof(UsersProfilePictureView), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int UserId)
        {
            var issue = await _DbContext.UsersProfilePictureView.FindAsync(UserId);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPut]
        [Route("UpdateImageFilePath")]
        [RequestSizeLimit(5 * 1024 * 1024)]
        public async Task<IActionResult> SubmitPost(int UserId, [FromForm] PostRequest postRequest)
        {
            userId = postRequest.UserId.ToString();
            if (postRequest == null)
            {
                return BadRequest(new PostResponse { Success = false, ErrorCode = "S01", Error = "Invalid post request" });
            }

            if (string.IsNullOrEmpty(Request.GetMultipartBoundary()))
            {
                return BadRequest(new PostResponse { Success = false, ErrorCode = "S02", Error = "Invalid post header" });
            }

            if (postRequest.Image != null)
            {
                await postService.SavePostImageAsync(postRequest);
            }
           
            var postResponse = await postService.CreatePostAsync(postRequest);

            if (!postResponse.Success)
            {
                return NotFound(postResponse);
            }

            //  this.GetImage(postRequest.UserId.ToString(), postRequest.Image.FileName);
            return Ok(postResponse.Post);

        }


        /// <summary>
        /// ////////////////////
        /// </summary>
        /// <param name="binary"></param>
        /// <returns></returns>
        /// 


        [HttpPost("UploadUserProfileImage")]
        public async Task<ActionResult> PostUserProfile([FromForm] FileUploadModel fileDetails)
        {
            if (fileDetails == null)
            {
                return BadRequest();
            }

            try
            {
                await postService.PostFileAsync(fileDetails.FileDetails, fileDetails.FileType);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }



        [HttpGet("DownloadProfileImage")]
        public async Task<ActionResult> DownloadFile(int userId)
        {
            if (userId < 1)
            {
                return BadRequest();
            }

            try
            {
                await postService.DownloadFileById(userId);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }



        //[HttpPut]
        //[Route("UpdateUsers")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> Update(int UserId, Users issue)
        //{
        //    _DbContext.Entry(issue).State = System.Data.Entity.EntityState.Modified;
        //    await _DbContext.SaveChangesAsync();
        //    return NoContent();
        //}



        [HttpPost]
        [Route("DownloadPathImage")]
        // Implement the file download logic
        public IActionResult Download(int id)
        {
            var fileModel = _DbContext.DwonloadUsersProfilePicture.FirstOrDefault(f => f.UserId == id);
            if (fileModel != null)
            {
                var fileStream = new FileStream(fileModel.FilePath, FileMode.Open);
                return File(fileStream, "application/octet-stream", fileModel.FileName);
            }
            return NotFound();
        }


        [HttpGet("{imageName}")]
        public IActionResult GetImage(string UserId, string imageName)
        {
            // Retrieve the image file and return it as a file result.
            var imagePath = Path.Combine(environment.WebRootPath, "users", "posts", UserId, imageName);

            if (System.IO.File.Exists(imagePath))
            {
                var imageBytes = System.IO.File.ReadAllBytes(imagePath);
                return File(imageBytes, "image/PNG"); // Adjust the content type as needed.
            }
            else
            {
                var noImage = Path.Combine(environment.WebRootPath, "users", "posts", "", "no_image.jpg");
                var imageBytes = System.IO.File.ReadAllBytes(noImage);
                return File(imageBytes, "image/PNG"); // Adjust the content type as needed.
            }
        }

        [HttpDelete("{fileName}")]
        public IActionResult DeleteImage(string UserId, string fileName)
        {
            try
            {
                string filePath = Path.Combine(environment.WebRootPath, "users", "posts", UserId, fileName); // Replace with your folder path
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                    postService.UpdateImageUrl(Convert.ToInt32(UserId));
                    //GetImage(UserId, fileName);
                    //GetFileName(Convert.ToInt32(UserId));
                    return File(filePath, "image/PNG");

                }
                else
                {
                    return NotFound($"File {filePath} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("GetFileName")]
        public IActionResult GetFileName(int UserId)
        {
            PostRequest model = new PostRequest();
            var data = "no_image.jpg";
            model = postService.GetFileName(UserId);
            if (model == null)
            {
                //var data =  model.FileName == "" ? "no_image.jpg" : model.FileName;
                // var data = model.FileName;
                return new JsonResult(new { data = data, status = HttpStatusCode.OK });
            }
            data = model.FileName == "" ? "no_image.jpg" : model.FileName;
            return new JsonResult(new { data = data, status = HttpStatusCode.OK });
        }
    }
}