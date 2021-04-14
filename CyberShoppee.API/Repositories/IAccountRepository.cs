using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyberShoppee.API.Entities;

namespace CyberShoppee.API.Repositories
{
    interface IAccountRepository
    {
        public bool CustomerRegistration(Customer customer);
        Customer ValidateCustomer(string email, string Pwd);
        List<Customer> GetCustomers();
        Customer GetCustomer(string customerid);
    }
}
