using System;
using System.Collections.Generic;

#nullable disable

namespace CyberShoppee.API.Entities
{
    public partial class Shipping
    {
        public string ShippingId { get; set; }
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public DateTime? ShippingDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }
    }
}
