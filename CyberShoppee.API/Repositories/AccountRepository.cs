using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyberShoppee.API.Entities;

namespace CyberShoppee.API.Repositories
{

    public class AccountRepository : IAccountRepository
    {
        private CyberShoppeeSprint2Context context;
        public AccountRepository()
        {
            this.context = new CyberShoppeeSprint2Context();

        }
        public bool CustomerRegistration(Customer customer)
        {
            customer.CustomerId = "C" + new Random().Next(100, 999);
            customer.CustomerRole = "customer";
            customer.CustomerRegistationDate = DateTime.Now;
            context.Customers.Add(customer);
            context.SaveChanges();
            return true;
        }
        public Customer GetCustomer(string customerid)
        {
            return context.Customers.Find(customerid);
        }

        public List<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }

        public Customer ValidateCustomer(string email, string Pwd)
        {
            return context.Customers.SingleOrDefault(u => u.CustomerEmail == email && u.CustomerPassword == Pwd);
        }

    }
}
