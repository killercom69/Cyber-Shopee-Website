using System;
using System.Collections.Generic;

#nullable disable

namespace CyberShoppee.API.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            Shippings = new HashSet<Shipping>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerContact { get; set; }
        public DateTime? CustomerRegistationDate { get; set; }
        public string CustomerRole { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
