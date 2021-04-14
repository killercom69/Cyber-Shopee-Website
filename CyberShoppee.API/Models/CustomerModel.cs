using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberShoppee.API.Models
{
    public class CustomerModel
    {
        public string CustomerId { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
