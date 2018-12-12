using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebshopApp.Services.DataServices.Contracts;
using WebshopApp.Services.Models;

namespace WebshopApp.Web.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public CategoryController(ICategoriesService categoriesService, IProductsService productsService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult ListAllProductFromCategory(int id)
        {
            this.ViewData["Categories"] = this.categoriesService.GetAll()
                .Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();

            if (ViewData["Categories"] == null)
            {
                throw new ArgumentException("Categories are empty");
            }

            var products = this.categoriesService.GetAllProductsFromCategory(id).ToList();

            return this.View(products);
        }
    }
}
