using Microsoft.AspNetCore.Http;
using WebshopApp.Services.Models.ViewModels;

namespace WebshopApp.Services.DataServices.Contracts
{
    public interface ICartsService
    {
        ShoppingCartViewModel GetShoppingCart(HttpContext context);

        ShoppingCartViewModel AddToShoppingCart(HttpContext context, string productId, int quantity);
    }
}
