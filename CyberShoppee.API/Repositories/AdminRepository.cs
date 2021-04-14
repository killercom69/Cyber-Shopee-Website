using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyberShoppee.API.Entities;
using CyberShoppee.API.Models;


namespace CyberShoppee.API.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private CyberShoppeeSprint2Context context;
        public AdminRepository()
        {
            this.context = new CyberShoppeeSprint2Context();
        }
        public bool AddRecipe(Recipe recipe)
        {
            recipe.RecipeId = "R" + new Random().Next(100, 999);
            context.Recipes.Add(recipe);
            context.SaveChanges();
            return true;
        }
        public List<Recipe> GetAllRecipes()
        {
            return context.Recipes.ToList();
        }
        public bool DeleteRecipe(string recipename)
        {
            Recipe recipe = context.Recipes.SingleOrDefault(i => i.RecipeName == recipename);
            context.Recipes.Remove(recipe);
            context.SaveChanges();
            return true;
        }
        public bool UpdateRecipe(Recipe recipe)
        {
            
            context.Recipes.Update(recipe);
            context.SaveChanges();
            return true;
        }
        public Recipe GetByRecipeName(string recipename)
        {
            return context.Recipes.SingleOrDefault(i => i.RecipeName == recipename);

        }
        public List<Order> ViewOrder()
        {
            return context.Orders.ToList();
        }
        public bool UpdateShippingCourierDetails(Shipping shipping)
        {
            shipping.ShippingId = "S" + new Random().Next(100, 999);
            shipping.ShippingDate = DateTime.Now.AddDays(7);
            context.Shippings.Add(shipping);
            context.SaveChanges();
            return true;
        }
       public List<Shipping> GetAllShippingDetails()
        {
            return context.Shippings.ToList();
        }
       
     
    }
}
