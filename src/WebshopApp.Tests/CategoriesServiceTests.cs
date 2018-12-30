using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using WebshopApp.Data.Common;
using WebshopApp.Models;
using Xunit;

namespace WebshopApp.Services.DataServices.Tests
{
    //RUN ALL TESTS SEPARATED
    public class CategoriesServiceTests
    {
        private Category[] GetTestData()
        {
            return new Category[]
            {
                new Category
                {
                    Id = 1,
                    Name = "category1"
                },

                new Category
                {
                    Id = 2,
                    Name = "category2"
                }
            };
        }

        [Fact]
        public void GetAll_ShouldReturnAllCategories()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Category>>();

            var categories = GetTestData().AsQueryable();
            repo.Setup(x => x.All()).Returns(categories);
            var service = new CategoriesService(repo.Object, null);

            //do
            var result = service.GetAll();

            //assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetAll_ShouldReturnEmpty_IfNothingIsGiven()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Category>>();

            var categories = new List<Category>().AsQueryable();
            repo.Setup(x => x.All()).Returns(categories);
            var service = new CategoriesService(repo.Object, null);

            //do
            var result = service.GetAll();

            //assert
            Assert.Empty(result);
        }

        [Fact]
        public void Create_ShouldCreateACategory()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Category>>();

            var service = new CategoriesService(repo.Object, null);

            //do
            var result = service.Create("category");

            //assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void Create_ShouldThrowArgumentException_IfNameIsNullOrWhiteSpace()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Category>>();

            var category = new Category { Name = "category" };
            repo.Setup(r => r.AddAsync(category));
            var service = new CategoriesService(repo.Object, null);

            //do
            var result = service.GetAll();

            var expected = typeof(ArgumentException);
            Type actual = null;
            try
            {
                await service.Create("");
            }
            catch (ArgumentException e)
            {
                actual = e.GetType();
            }

            Assert.Equal(expected, actual);
        }
    }
}
