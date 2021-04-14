using System;
using System.Collections.Generic;

#nullable disable

namespace CyberShoppee.API.Entities
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            Orders = new HashSet<Order>();
        }

        public string ShoppingCartId { get; set; }
        public string CustomerId { get; set; }
        public string RecipeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
