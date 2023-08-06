using Data.Context;
using Domain.Entities;
using Domain.Modeles;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Concrete;
using Service.Interface;
using System.Data.Entity;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersProfilePictureController : Controller
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly ILogger<UsersProfilePictureController> logger;
        private readonly IUsersProfilePicture postService;
        public UsersProfilePictureController(ApplicationDbContext Db ,ILogger<UsersProfilePictureController> logger, IUsersProfilePicture postService)
        {
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

    }
}
