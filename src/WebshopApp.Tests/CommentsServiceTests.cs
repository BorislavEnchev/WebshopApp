using AutoMapper;
using Moq;
using System;
using System.Linq;
using WebshopApp.Data.Common;
using WebshopApp.Models;
using Xunit;

namespace WebshopApp.Services.DataServices.Tests
{
    public class CommentsServiceTests
    {
        public Comment[] GetTestData()
        {
            return new Comment[]
            {
                new Comment
                {
                    Id = 1,
                    Content = "asdasdasdasdasdasdas",
                    ProductId = 1,
                    UserId = "asd"
                },

                new Comment
                {
                    Id = 2,
                    Content = "asdasdasdasdasdasdas",
                    ProductId = 1,
                    UserId = "asd"
                }
            };
        }

        [Fact]
        public void GetAll_ShouldReturnCorrectNumberOfComments()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Comment>>();
            var comments = GetTestData().AsQueryable();

            repo.Setup(r => r.All()).Returns(comments);
            var service = new CommentsService(repo.Object);

            //do
            var result = service.GetAll();

            //assert
            Assert.Equal(2, result.Count());
        }
    }
}
