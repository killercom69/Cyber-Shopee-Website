using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyberShoppee.API.Entities;
using CyberShoppee.API.Repositories;

namespace CyberShoppee.API.Services
{
    public class AccountService : IAccountService
    {
        private AccountRepository repository;
        public AccountService()
        {
            this.repository = new AccountRepository();
        }
        public bool CustomerRegistration(Customer customer)
        {
            return repository.CustomerRegistration(customer);
        }
        public Customer GetCustomer(string customerid)
        {
            return repository.GetCustomer(customerid);
        }

        public List<Customer> GetCustomers()
        {
            return repository.GetCustomers();
        }

        public Customer ValidateCustomer(string email, string Pwd)
        {
            return repository.ValidateCustomer(email, Pwd);
        }

    }
}
