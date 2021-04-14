using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberShoppee.API.Models
{
    public class OrderShoppingCustomer
    {
        public string OrderId { get; set; }
       
        public string ShoppingCartId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
       
        public string CustomerAddress { get; set; }
        public string RecipeId { get; set; }
        public string RecipeName { get; set; }
        public decimal RecipePrice { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
