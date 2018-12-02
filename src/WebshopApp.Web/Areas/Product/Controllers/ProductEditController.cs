using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebshopApp.Services.Contracts;

namespace WebshopApp.Web.Areas.Product.Controllers
{
    public class ProductEditController : BaseProductsController
    {
        public ProductEditController(IProductsServices services, IMapper mapper) 
            : base(services, mapper)
        {
        }

        public IActionResult Edit(int id)
        {
            return this.View();
        }
    }
}
