using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System.Net;

namespace WebAPI.Controllers
{
    public class FileViewerController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileViewerController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        [Route("api/FileViewer/ViewFile")]
        public IActionResult ViewFile(string fileName)
        {
            try
            {
                string contentRootPath = _webHostEnvironment.ContentRootPath;

                var filePath = Path.Combine(contentRootPath, fileName);

                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound();
                }
                var fileBytes = System.IO.File.ReadAllBytes(filePath);

                var fileExt = Path.GetExtension(filePath);
                var filecont = "";
                // Define a dictionary to map file extensions to content types
                var contentTypes = new Dictionary<string, string>
            {
                { ".pdf", "application/pdf" },
                { ".png", "image/png" },
                { ".doc", "application/msword" },
                { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
                { ".jpeg", "image/jpeg" },
                 { ".jpg", "image/jpeg" },
                // Add more mappings for other file types as needed
            };

                // Try to get the content type based on the file extension
                if (contentTypes.TryGetValue(fileExt.ToLower(), out var contentType))
                {
                    return File(fileBytes, contentType);
                }
                else
                {
                    // If the file extension is not recognized, return a default content type
                    return File(filePath, "application/octet-stream"); // You can change the default content type as needed
                }

            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
        }
    }
}
