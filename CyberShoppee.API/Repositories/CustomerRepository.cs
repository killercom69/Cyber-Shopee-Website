using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyberShoppee.API.Entities;
using CyberShoppee.API.Models;

namespace CyberShoppee.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private CyberShoppeeSprint2Context context;
        public CustomerRepository()
        {
            this.context = new CyberShoppeeSprint2Context();
        }
        public List<Recipe> ViewRecipe()
        {
            return context.Recipes.ToList();
        }


        public Recipe ViewIngredientDetails(string recipename)
        {
            return context.Recipes.SingleOrDefault(i => i.RecipeName == recipename);

        }

        public Recipe SearchRecipe(string recipename)
        {
            return context.Recipes.SingleOrDefault(i => i.RecipeName == recipename);
        }

        public bool AddProductToShoppingCart(ShoppingCart shoppingCart)
        {
            shoppingCart.ShoppingCartId = "Sc" + new Random().Next(100, 999);
            context.ShoppingCarts.Add(shoppingCart);
            context.SaveChanges();
            return true;

        }
        public List<ShoppingcartCustomerRecipe> GetShoppingCartDetails(string customerid)
        {
            List<ShoppingcartCustomerRecipe> shoppingcartCustomerRecipes = (from sc in context.ShoppingCarts
                                                                            join c in context.Customers
                                                                            on sc.CustomerId equals c.CustomerId
                                                                            join r in context.Recipes
                                                                            on sc.RecipeId equals r.RecipeId
                                                                            where sc.CustomerId==customerid
                                                                            select new ShoppingcartCustomerRecipe() { ShoppingCartId = sc.ShoppingCartId, CustomerId = c.CustomerId, RecipeId = r.RecipeId, RecipeName = r.RecipeName, CustomerName = c.CustomerName }).ToList();
            return shoppingcartCustomerRecipes;
        }
        

        public bool PlaceOrder(Order order)
        {
            order.OrderId = "O" + new Random().Next(100, 999);
            order.OrderDate = DateTime.Now;
            context.Orders.Add(order);
            context.SaveChanges();
            return true;
        }
        public List<OrderShoppingCustomer> MyOrders(string customerid)
        {
            List<OrderShoppingCustomer> orderShippingCustomers = (from o in context.Orders
                                                                  join sc in context.ShoppingCarts
                                                                  on o.CustomerId equals sc.CustomerId
                                                                  join r in context.Recipes
                                                                  on o.RecipeId equals r.RecipeId
                                                                  join c in context.Customers
                                                                  on o.CustomerId equals c.CustomerId
                                                                  where o.CustomerId == customerid
                                                                  select new OrderShoppingCustomer() { OrderId = o.OrderId, ShoppingCartId = sc.ShoppingCartId, CustomerId = c.CustomerId, CustomerName = c.CustomerName, CustomerAddress = c.CustomerAddress, RecipeId = r.RecipeId, RecipeName = r.RecipeName, RecipePrice = r.RecipePrice, OrderDate = o.OrderDate } ).ToList();
            return orderShippingCustomers;
        }


        public Shipping TrackShipping(string shippingid)
        {
            return context.Shippings.Find(shippingid);
        }
        public List<ShippingCustomerOrder> GetShippingDetails(string customerid)
        {
            List<ShippingCustomerOrder> shippingCustomerorder = (from s in context.Shippings
                                                                    join o in context.Orders on s.OrderId equals o.OrderId
                                                                    join c in context.Customers on s.CustomerId equals c.CustomerId
                                                                    where s.CustomerId == customerid
                                                                    select new ShippingCustomerOrder() { ShippingId = s.ShippingId, OrderId = o.OrderId, CustomerId = c.CustomerId, ShoppingCartId = o.ShoppingCartId, ShippingDate = s.ShippingDate }).ToList();
            return shippingCustomerorder;

        }
        public bool DeleteRecipeInCart(string shoppingid)
        {
            ShoppingCart shopping = context.ShoppingCarts.SingleOrDefault(i => i.ShoppingCartId == shoppingid);
            context.ShoppingCarts.Remove(shopping);
            context.SaveChanges();
            return true;
        }

        
    }
}


