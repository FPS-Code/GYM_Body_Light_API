using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM_Body_Light_API.Src.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        
        public string Email { get; set; } 
        public string Password { get; set; } = String.Empty;
        public string Role { get; set; }
        public DateOnly BirthDate { get; set; }
        public string district { get; set; } = String.Empty;
        public DateOnly DateAdmission { get; set; }
        
    }
}