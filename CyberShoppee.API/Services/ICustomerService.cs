using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyberShoppee.API.Entities;
using CyberShoppee.API.Models;

namespace CyberShoppee.API.Services
{
    interface ICustomerService
    {

        public List<Recipe> ViewRecipe();
        public Recipe ViewIngredientDetails(string recipename);
        public Recipe SearchRecipe(string recipename);
        public bool AddProductToShoppingCart(ShoppingCart shoppingcart);
        public bool DeleteRecipeInCart(string shoppingid);
        public bool PlaceOrder(Order order);
        public Shipping TrackShipping(string shippingid);
        public List<ShoppingcartCustomerRecipe> GetShoppingCartDetails(string customerid);
        public List<OrderShoppingCustomer> MyOrders(string customerid);
        public List<ShippingCustomerOrder> GetShippingDetails(string customerid);
       
    }

}

