using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebshopApp.Services.Contracts;

namespace WebshopApp.Web.Areas.Product.Controllers
{
    [Area("Product")]
    public abstract class BaseProductsController : Controller
    {
        protected IProductsServices Services { get; }
        protected IMapper Mapper { get; }

        protected BaseProductsController(IProductsServices services, IMapper mapper)
        {
            Services = services;
            Mapper = mapper;
        }
    }
}
