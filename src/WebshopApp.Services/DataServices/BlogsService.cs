using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebshopApp.Data.Common;
using WebshopApp.Models;
using WebshopApp.Services.DataServices.Contracts;
using WebshopApp.Services.MappingServices;
using WebshopApp.Services.Models;

namespace WebshopApp.Services.DataServices
{
    public class BlogsService : IBlogsService
    {
        private readonly IRepository<Blog> blogsRepository;

        public BlogsService(IRepository<Blog> blogsRepository)
        {
            this.blogsRepository = blogsRepository;
        }

        public IEnumerable<BlogViewModel> GetAll() => this.blogsRepository.All().To<BlogViewModel>();

        public async Task<int> Create(string title, string content)
        {
            var blog = new Blog
            {
                Title = title,
                Content = content,
                PostedOn = DateTime.UtcNow
            };

            await this.blogsRepository.AddAsync(blog);
            await this.blogsRepository.SaveChangesAsync();

            return blog.Id;
        }
    }
}
