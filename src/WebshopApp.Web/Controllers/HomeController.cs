using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebshopApp.Services.DataServices;
using WebshopApp.Web.Areas.Product.Models;
using WebshopApp.Web.Models;
using X.PagedList;

namespace WebshopApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsServices _services;
        private readonly IMapper _mapper;

        public HomeController(IProductsServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        public IActionResult Index(int? page)
        {
            var products = _services.All().ToList();

            var viewModels = new List<ProductViewModel>();

            foreach (var product in products)
            {

                var productViewModel = _mapper.Map<ProductViewModel>(product);

                viewModels.Add(productViewModel);
            }

            var nextPage = page ?? 1;

            var pagedViewModels = viewModels.ToPagedList(nextPage, 3);

            return View(pagedViewModels);
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
