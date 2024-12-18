using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM_Body_Light_API.Src.DTOs
{
    public class RegisterDto
    {
        
        public string Name { get; set; } = string.Empty;

        
        public string LastName { get; set; } = string.Empty;

        
        public string Email { get; set; } = string.Empty;

        
        public string Password { get; set; } = string.Empty;

      
        public DateOnly BirthDate { get; set; }

        
        public string District { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;
    }
    
}