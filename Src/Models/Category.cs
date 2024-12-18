namespace GYM_Body_Light_API.Src.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; } = String.Empty;

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}