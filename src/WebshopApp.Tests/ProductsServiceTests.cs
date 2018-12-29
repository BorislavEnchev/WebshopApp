using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shouldly;
using WebshopApp.Data;
using WebshopApp.Data.Common;
using WebshopApp.Models;
using WebshopApp.Services.DataServices.Contracts;
using WebshopApp.Services.MappingServices;
using WebshopApp.Services.Models;
using WebshopApp.Services.Models.ViewModels;
using Xunit;

namespace WebshopApp.Services.DataServices.Tests
{
    public class ProductsServiceTests : FakeServices
    {
        // RUN ALL TEST SEPARATED!
        public Product[] GetTestData()
        {
            return new Product[]
            {
                new Product
                {
                    Id = 1,
                    Name = "1",
                    CategoryId = 1,
                    Description = "12345",
                    Price = 1.11m,
                    Quantity = 4
                },

                new Product
                {
                    Id = 2,
                    Name = "2",
                    CategoryId = 2,
                    Description = "12345",
                    Price = 1.12m,
                    Quantity = 2
                }
            };
        }

        //Run separated
        [Fact]
        public void All_ShouldReturn_AllProducts()
        {
            Mapper.Initialize(x => { x.AddProfile<MapperConfiguration>(); });
            var repo = new Mock<IRepository<Product>>();

            var products = GetTestData().AsQueryable();
            repo.Setup(x => x.All()).Returns(products);
            var service = new ProductsService(repo.Object, null);
            
            //act
            var result = service.GetAllProducts();

            //assert

            Assert.Equal(2, result.Count());
        }

        //Run separated
        [Fact]
        public void Create_ShouldCreateANewProduct()
        {
            Mapper.Initialize(x => { x.AddProfile<MapperConfiguration>(); });
            var repo = new Mock<IRepository<Product>>();

            var product = new Product
            {
                CategoryId = 1,
                Name = "product",
                Description = "123",
                Price = 11.11m,
            };
            repo.Setup(x => x.AddAsync(product));
            var service = new ProductsService(repo.Object, null);

            //act
            var result = service.Create(1, "product", "123", 11.11m);

            //assert

            result.ShouldNotBeNull();
        }
    }
}
