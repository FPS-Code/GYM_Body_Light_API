using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM_Body_Light_API.Src.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public int Duration { get; set; }
        public DateOnly Date { get; set; }

        public TimeOnly time { get; set; }
        TypeClass TypeClass { get; set; } 
    }
}