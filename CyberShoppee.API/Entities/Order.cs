using System;
using System.Collections.Generic;

#nullable disable

namespace CyberShoppee.API.Entities
{
    public partial class Order
    {
        public Order()
        {
            Shippings = new HashSet<Shipping>();
        }

        public string OrderId { get; set; }
        public string ShoppingCartId { get; set; }
        public string CustomerId { get; set; }
        public string RecipeId { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
