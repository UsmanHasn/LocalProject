namespace WebAPI.Models
{
    public class MenuModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public string Type { get; set; }
    }
}
