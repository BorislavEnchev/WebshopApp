using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebshopApp.Services.DataServices.Contracts;
using WebshopApp.Services.Models;
using WebshopApp.Web.Models;

namespace WebshopApp.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductsService productsService;
        private readonly ICategoriesService categoriesService;

        public ProductController(IProductsService productsService, ICategoriesService categoriesService)
        {
            this.productsService = productsService;
            this.categoriesService = categoriesService;
        }

        public IActionResult Details(int id)
        {
            var product = this.productsService.GetProductById<ProductViewModel>(id);

            return this.View(product);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            this.ViewData["Categories"] = this.categoriesService.GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                });

            var product = this.productsService.GetProductById<EditProductBindingModel>(id);

            return this.View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var id = await this.productsService.Edit(model.Id, model.CategoryId, model.Name, model.Description, model.Price);
            return this.RedirectToAction("Details", new { id = model.Id });
        }

        [Authorize]
        public IActionResult Create()
        {
            this.ViewData["Categories"] = this.categoriesService.GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                });
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var id = await this.productsService.Create(model.CategoryId, model.Name, model.Description, model.Price);
            return this.RedirectToAction("Details", new { id = id });
        }
        
        public IActionResult Delete(int id)
        {
            var product = this.productsService.GetProductById<ProductViewModel>(id);

            return this.View(product);
        }

        [HttpPost]
        public IActionResult Delete(ProductViewModel model)
        {
            this.productsService.Delete(model.Id);

            return this.RedirectToAction("Deleted", "Product");
        }

        public IActionResult Deleted()
        {
            return this.View();
        }
    }
}
