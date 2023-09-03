using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

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
        public IActionResult ViewFile(string fullPath)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;

            string path = "";
            path = Path.Combine(webRootPath, fullPath);
            //var pdfFilePath =  "C:\\Projects\\SJC\\Backend\\WebAPI\\Assets\\Attachments\\" + filename;
            var pdfFilePath = path; // "C:\\Projects\\SJC\\Backend\\WebAPI\\Assets\\Attachments\\" + filename;


            if (!System.IO.File.Exists(pdfFilePath))
            {
                return NotFound();
            }
            var pdfBytes = System.IO.File.ReadAllBytes(pdfFilePath);

            var fileExt = Path.GetExtension(pdfFilePath);
            var filecont = "";
            if (fileExt == ".pdf")
            {
                filecont = "application/pdf";
            }
            else if (fileExt == ".png")
            {
                filecont = "image/png";
            }
            return File(pdfBytes, filecont);

        }
    }
}
