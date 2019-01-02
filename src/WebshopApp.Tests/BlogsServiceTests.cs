using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using WebshopApp.Data.Common;
using WebshopApp.Models;
using WebshopApp.Services.Models.ViewModels;
using Xunit;

namespace WebshopApp.Services.DataServices.Tests
{
    public class BlogsServiceTests
    {
        private Blog[] GetTestData()
        {
            return new Blog[]
            {
                new Blog
                {
                    Id = 1,
                    Title = "Title1",
                    Content = "Content1"
                },

                new Blog
                {
                    Id = 2,
                    Title = "Title2",
                    Content = "Content2"
                }
            };
        }

        [Fact]
        public void GetAll_ShouldReturnCorrectNumberOfBlogs()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Blog>>();

            var categories = GetTestData().AsQueryable();
            repo.Setup(x => x.All()).Returns(categories);
            var service = new BlogsService(repo.Object);

            //do
            var result = service.GetAll();

            //assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetAll_ShouldReturnEmpty_WithNoDataGiven()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Blog>>();

            var categories = new List<Blog>().AsQueryable();
            repo.Setup(x => x.All()).Returns(categories);
            var service = new BlogsService(repo.Object);

            //do
            var result = service.GetAll();

            //assert
            Assert.Empty(result);
        }

        [Fact]
        public void Create_ShouldCreateBlogAndReturnTheId()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Blog>>();
            
            var service = new BlogsService(repo.Object);
            
            //do
            var result = service.Create("Title", "Content");

            //assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetBlogById_ShouldReturnTheViewModel_ForTheGivenId()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Blog>>();

            var categories = GetTestData().AsQueryable();
            repo.Setup(x => x.All()).Returns(categories);
            var service = new BlogsService(repo.Object);

            //do
            var result = service.GetBlogById<BlogViewModel>(1);

            //assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetBlogById_ShouldThrowKeyNotFoundException_IfInvalidIdIsGiven()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Blog>>();

            var categories = GetTestData().AsQueryable();
            repo.Setup(x => x.All()).Returns(categories);
            var service = new BlogsService(repo.Object);

            //do            
            var expected = typeof(KeyNotFoundException);
            Type actual = null;
            try
            {
                var result = service.GetBlogById<BlogViewModel>(3);
            }
            catch (KeyNotFoundException e)
            {
                actual = e.GetType();
            }

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
