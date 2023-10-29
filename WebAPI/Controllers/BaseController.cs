using Microsoft.AspNetCore.Mvc;
using WebAPI.Helper;

namespace WebAPI.Controllers
{
    public class BaseController : Controller
    {
        //public string acoApiUrl = "https://localhost:7140/api/";
        //public string jcmsApiUrl = "https://localhost:7233/api/";

        //public string acoApiUrl = "http://"+ SjcConstants.baseIp + "82/api/";
        //public string jcmsApiUrl = "http://"+ SjcConstants.baseIp + "83/api/";

        public string acoApiUrl = "http://"+ SjcConstants.baseIp + "82/api/";
        public string jcmsApiUrl = "http://"+ SjcConstants.baseIp + "83/api/";
    }
}
