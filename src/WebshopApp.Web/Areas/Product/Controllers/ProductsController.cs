using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebshopApp.Services.Contracts;

namespace WebshopApp.Web.Areas.Product.Controllers
{
    [Area("Product")]
    public class ProductsController : Controller
    {
        private readonly IProductsServices _services;
        private readonly IMapper _mapper;

        public ProductsController(IProductsServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }


    }
}
