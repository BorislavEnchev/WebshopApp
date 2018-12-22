using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopApp.Data.Common;
using WebshopApp.Models;
using WebshopApp.Services.DataServices.Contracts;
using WebshopApp.Services.MappingServices;
using WebshopApp.Services.Models.ViewModels;

namespace WebshopApp.Services.DataServices
{
    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> commentsRepository;

        public CommentsService(IRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public IEnumerable<CommentViewModel> GetAll()
        {
            var models = this.commentsRepository.All().To<CommentViewModel>();

            return models;
        }

        public async Task<int> Add(int userId, int productId, string content)
        {
            var comment = new Comment()
            {
                UserId = userId,
                ProductId = productId,
                Content = content
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();

            return comment.Id;
        }

        public async Task<int> Edit(int id, int userId, int productId, string content)
        {
            var comments = commentsRepository.All();

            var comment = comments.FirstOrDefault(x => x.Id == id);

            if (comment == null)
            {
                throw new KeyNotFoundException();
            }

            comment.Id = id;
            comment.ProductId = productId;
            comment.UserId = userId;
            comment.Content = content;

            await this.commentsRepository.SaveChangesAsync();

            return comment.Id;
        }

        public void Delete(int id)
        {
            var comment = this.commentsRepository.All().FirstOrDefault(x => x.Id == id);

            if (comment == null)
            {
                throw new KeyNotFoundException();
            }

            this.commentsRepository.Delete(comment);
            this.commentsRepository.SaveChangesAsync();
        }
    }
}
