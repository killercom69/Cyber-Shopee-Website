using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyberShoppee.API.Services;
using CyberShoppee.API.Models;
using CyberShoppee.API.Entities;

namespace CyberShoppee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private AdminService adminService = null;
        public AdminController()
        {
            this.adminService = new AdminService();
        }
        [Route("AddRecipe")]
        [HttpPost]
        public IActionResult AddRecipe(Recipe recipe)
        {
            try
            {
                adminService.AddRecipe(recipe);
                return Ok("Recipe Added");
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        [Route("GetAllRecipes")]
        [HttpGet]
        public IActionResult GetAllRecipes()
        {
            try
            {
                List<Recipe> recipe = adminService.GetAllRecipes();
                return Ok(recipe);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [Route("DeleteRecipe/{recipename}")]
        [HttpDelete]
        public IActionResult DeleteRecipe(string recipename)
        {
            try
            {
                adminService.DeleteRecipe(recipename);
                return Ok("Recipe Deleted");

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
      
        [Route("UpdateRecipe")]
        [HttpPut]
        public IActionResult UpdateRecipe(Recipe recipe)
        {
            try
            {
                adminService.UpdateRecipe(recipe);
                return Ok("Record Updated");

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [Route("GetByRecipeName/{recipename}")]
        [HttpGet]
        public IActionResult GetByRecipeName(string recipename)
        {
            try
            {
                Recipe recipe = adminService.GetByRecipeName(recipename);
                return Ok(recipe);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [Route("ViewOrder")]
        [HttpGet]
        public IActionResult ViewOrder()
        {
            try
            {
                List<Order> list = adminService.ViewOrder();
                return Ok(list);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
       
        [Route("UpdateShipping")]
        [HttpPost]
        public IActionResult UpdateShipping(Shipping shipping)
        {
            try
            {
                adminService.UpdateShippingCourierDetails(shipping);
                return Ok("Record Updated");

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
      

        
        [Route("GetShippingDetails")]
        [HttpGet]
        public IActionResult GetShippingDetails()
        {
            try
            {
                List<Shipping> recipe = adminService.GetAllShippingDetails();
                return Ok(recipe);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        
    }



}

