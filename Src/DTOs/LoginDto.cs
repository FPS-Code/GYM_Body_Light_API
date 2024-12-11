using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM_Body_Light_API.Src.DTOs
{
    
    public class LoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

