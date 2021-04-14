using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyberShoppee.API.Entities;
using CyberShoppee.API.Models;


namespace CyberShoppee.API.Repositories
{
    public interface ICustomerRepository
    {
        public List<Recipe> ViewRecipe();
        public Recipe ViewIngredientDetails(string recipename);
        public Recipe SearchRecipe(string recipename);
        public bool AddProductToShoppingCart(ShoppingCart shoppingCart);
        public bool DeleteRecipeInCart(string shoppingid);
        public bool PlaceOrder(Order order);
        public Shipping TrackShipping(string shippingid);
        public List<ShippingCustomerOrder> GetShippingDetails(string customerid);
        public List<ShoppingcartCustomerRecipe> GetShoppingCartDetails(string customerid);
        public List<OrderShoppingCustomer> MyOrders(string customerid);
       



    }

}
