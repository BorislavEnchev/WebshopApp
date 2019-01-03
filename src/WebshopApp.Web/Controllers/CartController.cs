using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebshopApp.Services.DataServices.Contracts;

namespace WebshopApp.Web.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICartsService cartsService;

        public CartController(ICartsService cartsService)
        {
            this.cartsService = cartsService;
        }

        public IActionResult Index()
        {
            var cartModel = this.cartsService.GetShoppingCart(HttpContext);

            return View(cartModel);
        }

        [HttpPost]
        public IActionResult AddToCart(string productId, int quantity)
        {
            var cartModel = this.cartsService.AddToShoppingCart(HttpContext, productId, quantity);

            return View("Index", cartModel);
        }
    }
}
