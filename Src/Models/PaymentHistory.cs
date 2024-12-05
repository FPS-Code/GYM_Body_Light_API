using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM_Body_Light_API.Src.Models
{
    public class PaymentHistory
    {
        public int Id { get; set; }
        public DateOnly DatePayment { get; set; }
        public double Amount { get; set; }
    }
}