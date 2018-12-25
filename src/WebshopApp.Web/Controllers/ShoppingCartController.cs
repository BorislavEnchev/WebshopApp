using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WebshopApp.Data;
using WebshopApp.Models;

namespace WebshopApp.Web.Controllers
{
    public class ShoppingCartController : BaseController
    {
        private const string SessionKey = "CartId";

        public ShoppingCartController()
        {
            
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            
            string cartId = session.GetString(SessionKey) ?? Guid.NewGuid().ToString();

            session.SetString(SessionKey, cartId);

            return new ShoppingCart() { Id = cartId };
        }

        //public void AddToCart(Product product, int amount)
        //{
        //    var shoppingCartItem =
        //        context.ShoppingCartItems.SingleOrDefault(
        //            s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);

        //    if (shoppingCartItem == null)
        //    {
        //        shoppingCartItem = new ShoppingCartItem
        //        {
        //            ShoppingCartId = ShoppingCartId,
        //            Product = product,
        //        };

        //        context.ShoppingCartItems.Add(shoppingCartItem);
        //    }
        //    else
        //    {
        //        shoppingCartItem.Amount++;
        //    }
        //    context.SaveChanges();
        //}
    }
}
