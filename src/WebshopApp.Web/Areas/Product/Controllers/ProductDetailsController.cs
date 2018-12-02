using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebshopApp.Services.Contracts;
using WebshopApp.Web.Areas.Product.Models;

namespace WebshopApp.Web.Areas.Product.Controllers
{
    public class ProductDetailsController : BaseProductsController
    {
        public ProductDetailsController(IProductsServices services, IMapper mapper) 
            : base(services, mapper)
        {
        }

        public IActionResult Details(int id)
        {
            var product = Services.GetProductById(id);

            var viewModel = Mapper.Map<ProductViewModel>(product);

            return this.View("/Views/Product/Details.cshtml", viewModel);
        }
    }
}
