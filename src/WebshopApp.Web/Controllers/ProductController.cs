using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebshopApp.Services.DataServices;
using WebshopApp.Web.Areas.Product.Models;
using WebshopApp.Web.Controllers;

namespace WebshopApp.Web.Areas.Product.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IProductsServices services)
        {
        }

        public IActionResult Details(int id)
        {
            //var product = services.GetProductById(id);

            //var viewModel = Mapper.Map<ProductViewModel>(product);

            //return this.View("/Views/Product/Details.cshtml", viewModel);
        }
    }
}
