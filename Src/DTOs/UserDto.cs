namespace GYM_Body_Light_API.Src.DTOs
{
    public class UserDto
    {
        public string Name { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        
        public string Email { get; set; } = string.Empty;
       
        public string Role { get; set; } = string.Empty;
        
        public DateOnly DateAdmission { get; set; }

        public string District { get; set; } = String.Empty;
    }
}