using System.ComponentModel.DataAnnotations;

namespace GYM_Body_Light_API.Src.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string LastName { get; set; } = String.Empty;
        [Required]
        public string Email { get; set; } = String.Empty;
        [Required]
        public string Password { get; set; } = String.Empty;
        [Required]
        public string Role { get; set; } = string.Empty;
        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        public string District { get; set; } = String.Empty;
        [Required]
        public DateOnly DateAdmission { get; set; }
        [Required]
        public string Gender { get; set; } = String.Empty;


        
    }
}