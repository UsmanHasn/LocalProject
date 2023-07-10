namespace WebAPI.Models
{
    public class HttpResponseModel<T> where T : class
    {
        public List<T> data { get; set; }
        public bool status { get; set; }
    }
}
