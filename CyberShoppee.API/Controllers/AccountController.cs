using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyberShoppee.API.Services;
using CyberShoppee.API.Models;
using CyberShoppee.API.Entities;
using CyberShoppee.API.Repositories;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CyberShoppee.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private AccountService accountService = null;
        public AccountController()
        {
            this.accountService = new AccountService();
        }
        [Route("CustomerRegistration")]
        [HttpPost]
        public IActionResult CustomerRegistration(Customer customer)
        {
            try
            {
                accountService.CustomerRegistration(customer);
                return Ok("Customer Registered");
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetCustomers")]
        [Authorize(Roles = "customer")]
        public IActionResult GetUsers()
        {
            return Ok(accountService.GetCustomers());
        }

        [HttpGet]
        [Route("GetCustomerById/{customerid}")]
        [Authorize(Roles = "customer,Admin")]
        public IActionResult GetUserById(string customerid)
        {
            return Ok(accountService.GetCustomer(customerid));
        }
        [HttpGet]
        [Route("Login/{email}/{Pwd}")]
        public IActionResult Login(string email, string Pwd)
        {
            CustomerModel model = null;
            Customer customer = accountService.ValidateCustomer(email, Pwd);
            if (customer != null)
            {
                string token = GetToken(customer);
                model = new CustomerModel() { CustomerId = customer.CustomerId, Token = token, Role = customer.CustomerRole };
            }
            else
            {
                model = new CustomerModel() { CustomerId = "", Token = "", Role = "" };
            }

            return Ok(model);
        }

        private string GetToken(Customer customer)
        {
            var _config = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json").Build();
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials
        (securityKey, SecurityAlgorithms.HmacSha256);

            //    var token = new JwtSecurityToken(issuer: issuer,
            //audience: audience,

            //expires: DateTime.Now.AddMinutes(120),
            //signingCredentials: credentials);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                   {
                    new Claim(ClaimTypes.Name, customer.CustomerId.ToString()),
                    new Claim(ClaimTypes.Role, customer.CustomerRole)
                   }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;


        }
    }
}



