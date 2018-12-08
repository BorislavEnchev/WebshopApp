using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebshopApp.Services.DataServices;
using WebshopApp.Services.DataServices.Contracts;
using WebshopApp.Services.Models;
using WebshopApp.Web.Models;

namespace WebshopApp.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductsService productsService;

        public ProductController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult Details(int id)
        {
            var product = this.productsService.GetProductById<ProductViewModel>(id);

            return this.View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var id = await this.productsService.Create(input.CategoryId, input.Name, input.Description, input.Price);
            return this.RedirectToAction("Details", new { id = id });
        }
    }
}
