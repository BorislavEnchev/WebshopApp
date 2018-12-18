using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebshopApp.Services.DataServices.Contracts;
using WebshopApp.Services.Models;

namespace WebshopApp.Web.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IBlogsService blogsService;

        public BlogController(IBlogsService blogsService)
        {
            this.blogsService = blogsService;
        }

        public IActionResult Index()
        {
            var blogs = this.blogsService.GetAll().ToList();

            var viewModels = new List<BlogViewModel>();

            foreach (var blog in blogs)
            {
                viewModels.Add(blog);
            }

            return this.View(viewModels);
        }
    }
}
