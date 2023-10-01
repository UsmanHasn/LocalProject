using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BaseController : Controller
    {
        //public string acoApiUrl = "https://localhost:7140/api/";
        //public string jcmsApiUrl = "https://localhost:7233/api/";

        public string acoApiUrl = "http://sjcepportal:82/api/";
        public string jcmsApiUrl = "http://sjcepportal:83/api/";
    }
}
