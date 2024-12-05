using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM_Body_Light_API.Src.Models
{
    public class Share
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string state { get; set; } = String.Empty;
        public DateOnly date { get; set; }
    }
}