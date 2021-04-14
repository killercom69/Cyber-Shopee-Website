using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberShoppee.API.Models
{
    public class ShippingCustomerOrder
    {
        public string ShippingId { get; set; }
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public string ShoppingCartId { get; set; }
        public DateTime? ShippingDate { get; set; }
    }
}
