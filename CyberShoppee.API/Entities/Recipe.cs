using System;
using System.Collections.Generic;

#nullable disable

namespace CyberShoppee.API.Entities
{
    public partial class Recipe
    {
        public Recipe()
        {
            Orders = new HashSet<Order>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public string RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set; }
        public string RecipeStock { get; set; }
        public decimal RecipePrice { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
