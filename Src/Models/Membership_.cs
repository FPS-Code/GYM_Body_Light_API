namespace GYM_Body_Light_API.Src.Models
{
    public class Membership_
    {
        public int Id { get; set; }
        public string TypeMembership { get; set; } = String.Empty;
        public int price { get; set; }
        public int duration { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}