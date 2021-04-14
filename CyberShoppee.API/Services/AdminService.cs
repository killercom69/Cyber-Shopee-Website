using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyberShoppee.API.Entities;
using CyberShoppee.API.Repositories;
using CyberShoppee.API.Models;
namespace CyberShoppee.API.Services
{
    public class AdminService : IAdminService
    {
        private AdminRepository repository;
        public AdminService()
        {
            this.repository = new AdminRepository();
        }
        public bool AddRecipe(Recipe recipe)
        {
            return repository.AddRecipe(recipe);
        }
        public bool DeleteRecipe(string recipename)
        {
            return repository.DeleteRecipe(recipename);
        }
        public bool UpdateRecipe(Recipe recipe)
        {
            return repository.UpdateRecipe(recipe);
        }
        public List<Order> ViewOrder()
        {
            return repository.ViewOrder();
        }
        public bool UpdateShippingCourierDetails(Shipping shipping)
        {
            return repository.UpdateShippingCourierDetails(shipping);
        }
        
        public List<Recipe> GetAllRecipes()
        {
            return repository.GetAllRecipes();
        }
        public List<Shipping> GetAllShippingDetails()
        {
            return repository.GetAllShippingDetails();
        }
        public Recipe GetByRecipeName(string recipename)
        {
            return repository.GetByRecipeName(recipename);
        }
        
    }
}
