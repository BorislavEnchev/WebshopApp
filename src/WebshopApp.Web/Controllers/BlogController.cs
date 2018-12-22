﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebshopApp.Services.DataServices.Contracts;
using WebshopApp.Services.Models;
using WebshopApp.Services.Models.InputModels;
using WebshopApp.Services.Models.ViewModels;

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

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var id = await this.blogsService.Create(model.Title, model.Content);

            return this.RedirectToAction("Details", "Blog", new { id = id });
        }

        public IActionResult Details(int id)
        {
            var blog = this.blogsService.GetBlogById<BlogViewModel>(id);

            return this.View(blog);
        }
    }
}
