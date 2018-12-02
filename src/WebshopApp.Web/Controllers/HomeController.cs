using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebshopApp.Services.Contracts;
using WebshopApp.Web.Areas.Product.Models;
using WebshopApp.Web.Models;

namespace WebshopApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsServices _services;

        public HomeController(IProductsServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            var allProducts = _services.All()
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price
                })
                .ToList();

            var allProductsViewModel = new ProductsCollectionViewModel()
            {
                Products = allProducts
            };

            return View(allProductsViewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
