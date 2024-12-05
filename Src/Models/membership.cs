using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM_Body_Light_API.Src.Models
{
    public class membership
    {
        public int Id { get; set; }
        public string TypeMembership { get; set; } = String.Empty;
        public int price { get; set; }
        public int duration { get; set; }
    }
}