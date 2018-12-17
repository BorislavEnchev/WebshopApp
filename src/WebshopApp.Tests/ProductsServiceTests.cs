using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Moq;
using WebshopApp.Data;
using WebshopApp.Data.Common;
using WebshopApp.Models;
using WebshopApp.Services.Models;
using Xunit;

namespace WebshopApp.Services.DataServices.Tests
{
    public class ProductsServiceTests
    {
        [Fact]
        public void GetAll_ShouldReturnCorrectNumber()
        {
            var productsRepository = new Mock<IRepository<Product>>();

            //productsRepository.Setup(r => r.All()).Returns(new List<Product>
            //{
            //    new Product(),
            //    new Product(),
            //    new Product()
            //});
        }
    }
}
