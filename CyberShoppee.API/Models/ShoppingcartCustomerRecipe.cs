using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberShoppee.API.Models
{
    public class ShoppingcartCustomerRecipe
    {
        public string ShoppingCartId { get; set; }
        public string CustomerId { get; set; }
        public string RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string CustomerName { get; set; }
    }
}
