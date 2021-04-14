using System;
using System.Collections.Generic;
using System.Text;
using CyberShoppee.API.Repositories;
using Xunit;
using CyberShoppee.API.Entities;

namespace TestCyberShoppee
{
    public class TestAdminRepository
    {

        private AdminRepository repository = null;
        public TestAdminRepository()
        {
            repository = new AdminRepository();
        }
        [Fact]
        public void TestGetAllRecipes()
        {
            //arrange
            int expected = 3;
            //action
            int actual = repository.GetAllRecipes().Count;
            //assert
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void TestGetRecipe()
        {
            //arrange
            string recipename="Momos";
            //action
            Recipe obj = repository.GetByRecipeName(recipename);
            //assert
            Assert.NotNull(obj);

        }
    }
}
