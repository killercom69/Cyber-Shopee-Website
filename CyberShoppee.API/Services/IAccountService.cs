using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyberShoppee.API.Entities;

namespace CyberShoppee.API.Services
{
    interface IAccountService
    {
        public bool CustomerRegistration(Customer customer);
        Customer ValidateCustomer(string email, string Pwd);
        List<Customer> GetCustomers();
        Customer GetCustomer(string customerid);
    }
}
