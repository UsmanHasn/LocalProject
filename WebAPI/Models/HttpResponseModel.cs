namespace WebAPI.Models
{
    public class HttpResponseModel<T> where T : class
    {
        public List<T> data { get; set; }
        public bool status { get; set; }
    }
    public class HttpStringResponseModel
    {
        public string data { get; set; }
        public bool status { get; set; }
    }
    public class HttpPKIResponseModel
    {
        public string data { get; set; }
        public int status { get; set; }
    }
}
