using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BaseController : Controller
    {
        public string acoApiUrl = "https://localhost:7140/api/";
        public string jcmsApiUrl = "https://localhost:7233/api/";

        //public string acoApiUrl = "http://sjcepacoapi/api/";
        //public string jcmsApiUrl = "http://sjcepjcmsapi/api/";
    }
}
