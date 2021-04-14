using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyberShoppee.API.Entities;
using CyberShoppee.API.Models;
namespace CyberShoppee.API.Repositories
{
    public interface IAdminRepository
    {
        public bool AddRecipe(Recipe recipe);
        public bool DeleteRecipe(string recipename);
        public bool UpdateRecipe(Recipe recipe);
        public List<Order> ViewOrder();
        public List<Recipe> GetAllRecipes();
        public List<Shipping> GetAllShippingDetails();
        public bool UpdateShippingCourierDetails(Shipping shipping);
        
        public Recipe GetByRecipeName(string recipename);
        
    }
}
