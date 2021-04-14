using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyberShoppee.API.Entities;
using CyberShoppee.API.Repositories;
using CyberShoppee.API.Models;
namespace CyberShoppee.API.Services
{
    public class CustomerService : ICustomerService
    {
        private CustomerRepository repository;
        public CustomerService()
        {
            this.repository = new CustomerRepository();
        }

        public List<Recipe> ViewRecipe()
        {
            return repository.ViewRecipe();
        }

        public Recipe ViewIngredientDetails(string recipename)
        {
            return repository.ViewIngredientDetails(recipename);
        }

        public Recipe SearchRecipe(string recipename)
        {
            return repository.SearchRecipe(recipename);
        }

        public bool AddProductToShoppingCart(ShoppingCart shoppingcart)
        {
            return repository.AddProductToShoppingCart(shoppingcart);

        }
        public List<ShippingCustomerOrder> GetShippingDetails(string customerid)
        {
            return repository.GetShippingDetails(customerid);
        }
        public bool DeleteRecipeInCart(string shoppingid)
        {
            return repository.DeleteRecipeInCart(shoppingid);
        }

        public bool PlaceOrder(Order order)
        {
            return repository.PlaceOrder(order);
        }


        public Shipping TrackShipping(string shippingid)
        {
            return repository.TrackShipping(shippingid);
        }
        public List<ShoppingcartCustomerRecipe> GetShoppingCartDetails(string customerid)
        {
            return repository.GetShoppingCartDetails(customerid);
        }
        public List<OrderShoppingCustomer> MyOrders(string customerid)
        {
            return repository.MyOrders(customerid);
        }
        
    }
}
