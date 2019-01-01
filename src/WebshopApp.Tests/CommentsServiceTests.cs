using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using WebshopApp.Data.Common;
using WebshopApp.Models;
using WebshopApp.Services.Models.InputModels;
using WebshopApp.Services.Models.ViewModels;
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

        [Fact]
        public void GetAllByProduct_ShouldReturnCorrectNumber()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Comment>>();
            var comments = GetTestData().AsQueryable();

            repo.Setup(r => r.All()).Returns(comments);
            var service = new CommentsService(repo.Object);

            //do
            var result = service.GetAllByProduct(1);

            //assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetAllByProduct_ShouldThrowArgumentException_IfNoProductsForTheGivenId()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Comment>>();
            var comments = GetTestData().AsQueryable();

            repo.Setup(r => r.All()).Returns(comments);
            var service = new CommentsService(repo.Object);

            var expected = typeof(ArgumentException);
            Type actual = null;
            try
            {
                //do
                var result = service.GetAllByProduct(2);
            }
            catch (ArgumentException e)
            {
                actual = e.GetType();
            }

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_ShouldAddComment_AndReturnTheId()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Comment>>();
            var comments = new List<Comment>().AsQueryable();

            repo.Setup(r => r.All()).Returns(comments);
            var service = new CommentsService(repo.Object);

            //do
            var model = new CreateCommentInputModel
            {
                Content = "asdjkhaskdjhsjsjsjsjssjjsjssjjssjsjsjsjsjjssjjssjsjjs",
                ProductId = 1,
                UserId = new Guid().ToString()
            };
            var result = service.Add(model);

            //assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void Delete_ShouldThrowKeyNotFoundException_IfInvalidIdIsGiven()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Comment>>();
            var comments = GetTestData().AsQueryable();

            repo.Setup(r => r.All()).Returns(comments);
            var service = new CommentsService(repo.Object);

            var expected = typeof(KeyNotFoundException);
            Type actual = null;
            try
            {
                //do
                await service.Delete(3);
            }
            catch (KeyNotFoundException e)
            {
                actual = e.GetType();
            }

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetById_ShouldReturnCommentViewModel_OfTheGivenCommentId()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Comment>>();
            var comments = GetTestData().AsQueryable();

            repo.Setup(r => r.All()).Returns(comments);
            var service = new CommentsService(repo.Object);

            //do
            var result = service.GetById(1);

            //assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetById_ShouldThrowKeyNotFoundException_IfInvalidIdIsGiven()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Comment>>();
            var comments = GetTestData().AsQueryable();

            repo.Setup(r => r.All()).Returns(comments);
            var service = new CommentsService(repo.Object);

            var expected = typeof(KeyNotFoundException);
            Type actual = null;
            try
            {
                //do
                var result = service.GetById(3);
            }
            catch (KeyNotFoundException e)
            {
                actual = e.GetType();
            }

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Edit_ShouldEditCommentAndReturnId()
        {
            Mapper.Initialize(x => x.AddProfile<MapperConfiguration>());
            var repo = new Mock<IRepository<Comment>>();
            var comments = GetTestData().AsQueryable();

            repo.Setup(r => r.All()).Returns(comments);
            var service = new CommentsService(repo.Object);

            //do
            var model = new CommentViewModel
            {
                Id = 1,
                Content = "sssjjjsss",
                ProductId = 1,
                UserId = "asd"
            };
            var result = service.Edit(model);

            //assert
            Assert.NotNull(result);
            //TODO: check if its updated
        }
    }
}
