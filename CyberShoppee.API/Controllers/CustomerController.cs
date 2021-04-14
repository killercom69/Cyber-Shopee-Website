using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyberShoppee.API.Services;
using CyberShoppee.API.Models;
using System.Net;
using CyberShoppee.API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CyberShoppee.API.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private CustomerService customerService = null;
        public CustomerController()
        {
            this.customerService = new CustomerService();
        }
        [Route("ViewRecipe")]
        [HttpGet]
        public IActionResult ViewRecipe()
        {
            try
            {
                List<Recipe> list = customerService.ViewRecipe();
                return Ok(list);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [Route("ViewIngredientDetails/{recipename}")]
        [HttpGet]
        public IActionResult ViewIngredientDetails(string recipename)
        {
            try
            {
                Recipe recipe = customerService.ViewIngredientDetails(recipename);
                return Ok(recipe);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [Route("SearchRecipe/{recipename}")]
        [HttpGet]
        public IActionResult SearchRecipe(string recipename)
        {
            try
            {
                Recipe recipe = customerService.SearchRecipe(recipename);
                return Ok(recipe);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [Route("AddProductToShoppingCart")]
        [HttpPost]
        public IActionResult AddProductToShoppingCart(ShoppingCart shoppingCart)
        {
            try
            {
                customerService.AddProductToShoppingCart(shoppingCart);
                return Ok("Recipe Added to shoppingcart");
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        [Route("GetShoppingCartDetails/{customerid}")]
        [HttpGet]
        public IActionResult GetShoppingCartDetails(string customerid)
        {
            try
            {
                List<ShoppingcartCustomerRecipe> shoppingcartCustomerRecipes = customerService.GetShoppingCartDetails(customerid);
                return Ok(shoppingcartCustomerRecipes);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [Route("DeleteRecipeInCart/{shoppingid}")]
        [HttpDelete]
        public IActionResult DeleteRecipeInCart(string shoppingid)
        {
            try
            {
                customerService.DeleteRecipeInCart(shoppingid);
                return Ok("Recipe Deleted");

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [Route("PlaceOrder")]
        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {
            try
            {
                customerService.PlaceOrder(order);
                return Ok("Order placed successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        [Route("MyOrders/{customerid}")]
        [HttpGet]
        public IActionResult MyOrders(string customerid)
        {
            try
            {
                List<OrderShoppingCustomer> orderShoppingCustomers = customerService.MyOrders(customerid);
                return Ok(orderShoppingCustomers);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [Route("TrackShipping/{shippingId}")]
        [HttpGet]
        public IActionResult TrackShipping(string shippingid)
        {
            try
            {
               Shipping shipping= customerService.TrackShipping(shippingid);
                return Ok(shipping);
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
       
       
        [Route("GetShippingDetails/{customerid}")]
        [HttpGet]
        public IActionResult GetShippingDetails(string customerid)
        {
            try
            {
                List<ShippingCustomerOrder> shippingcustomerorder = customerService.GetShippingDetails(customerid);
                return Ok(shippingcustomerorder);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        

    }

}
