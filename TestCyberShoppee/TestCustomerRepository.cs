using System;
using Xunit;
using CyberShoppee.API.Repositories;
using CyberShoppee.API.Entities;


namespace TestCyberShoppee
{
    public class TestCustomerRepository
    {
        private CustomerRepository repository = null;
        public TestCustomerRepository()
        {
            repository = new CustomerRepository();
        }
        [Fact]
         
            public void TestSearchRecipe()
            {
                //arrange
                string recipename = "Momos";
                //action
                Recipe obj = repository.SearchRecipe(recipename);
                //assert
                Assert.NotNull(obj);

            }
        [Fact]

        public void TestViewRecipe()
        {
            //arrange
            int expected = 3;
            //action
            int actual = repository.ViewRecipe().Count;
            //assert
            Assert.Equal(expected, actual);

        }

    }
    }

