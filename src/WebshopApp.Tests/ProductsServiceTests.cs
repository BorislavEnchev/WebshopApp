using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using WebshopApp.Data.Common;
using WebshopApp.Models;
using WebshopApp.Services.Models.ViewModels;
using Xunit;

namespace WebshopApp.Services.DataServices.Tests
{
    public class ProductsServiceTests
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
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Product>>();

            var products = GetTestData().AsQueryable();
            repo.Setup(x => x.All()).Returns(products);
            var service = new ProductsService(repo.Object, null);
            
            //do
            var result = service.GetAllProducts();

            //assert
            Assert.Equal(2, result.Count());
        }
        
        //Run separated
        [Fact]
        public void GetProductById_ShouldReturnProductWithTheGivenId()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Product>>();

            var products = GetTestData().AsQueryable();
            repo.Setup(x => x.All()).Returns(products);
            var service = new ProductsService(repo.Object, null);

            //do
            var id = service.GetAllProducts().Select(x => x.Id).FirstOrDefault();
            var result = service.GetProductById<Product>(id);

            //assert
            result.Should().NotBeNull().And.BeOfType<Product>();
        }

        //Run separated
        [Fact]
        public void GetProductById_ShouldThrowException_If_InvalidIdIsGiven()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
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

            //do            
            Action action = () => service.GetProductById<Product>(2);

            //assert
            action.Should().Throw<KeyNotFoundException>();
        }

        //Run separated
        [Fact]
        public void GetAllByCategory_ShouldNotBeNull_IfValidCategoryIsGiven()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Product>>();

            var products = GetTestData().AsQueryable();
            repo.Setup(x => x.All()).Returns(products);
            var service = new ProductsService(repo.Object, null);

            //do
            var categoryId = service.GetAllProducts().Select(x => x.CategoryId).FirstOrDefault();
            var result = service.GetAllByCategory(categoryId);

            //assert
            result.Should().NotBeNull();
        }

        //Run Separated
        [Fact]
        public void GetAllByCategory_ShouldReturnEmpty_IfInvalidCategory()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Product>>();

            var products = GetTestData().AsQueryable();
            repo.Setup(x => x.All()).Returns(products);
            var service = new ProductsService(repo.Object, null);

            //do
            var categoryId = 99;
            var result = service.GetAllByCategory(categoryId);

            //assert
            Assert.Empty(result);
        }

        //Run separated
        [Fact]
        public void Create_ShouldCreateANewProductAndReturnTheId()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Product>>();

            var service = new ProductsService(repo.Object, null);

            //do
            var result = service.Create(1, "product", "123", 11.11m);

            //assert
            result.Should().NotBeNull().And.BeOfType<Task<int>>();
        }
        
        [Fact]
        public void Delete_ShouldThrowKeyNotFoundException_IfInvalidIdIsGiven()
        {
            Mapper.Initialize(x => { x.AddProfile<MapperConfiguration>(); });
            var repo = new Mock<IRepository<Product>>();

            var products = GetTestData().AsQueryable();
            repo.Setup(x => x.All()).Returns(products);
            var service = new ProductsService(repo.Object, null);

            //do
            Action action = () => service.Delete(3);

            //assert
            action.Should().Throw<KeyNotFoundException>();
        }
    }
}
