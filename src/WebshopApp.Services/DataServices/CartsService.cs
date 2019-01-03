using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using WebshopApp.Data.Common;
using WebshopApp.Models;
using WebshopApp.Services.DataServices.Contracts;
using WebshopApp.Services.Models.ViewModels;
using SessionExtensions = WebshopApp.Data.Common.SessionExtensions;
using Microsoft.AspNetCore;

namespace WebshopApp.Services.DataServices
{
    public class CartsService : ICartsService
    {
        private IDistributedCache cache;
        private readonly IRepository<ShoppingCart> cartRepository;
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<Product> productRepository;

        public CartsService(IRepository<ShoppingCart> cartRepository, IRepository<Order> orderRepository, IRepository<Product> productRepository, /*IOrdersService ordersService,*/ IDistributedCache cache)
        {
            this.cartRepository = cartRepository;
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            this.cache = cache;
        }

        public ShoppingCartViewModel GetShoppingCart(HttpContext context)
        {

            if (SessionExtensions.Get<ShoppingCart>(context.Session, "Cart") == null)
            {
                var cart = new ShoppingCart
                {
                    Id = Guid.NewGuid().ToString(),
                    Products = new List<Product>()
                };

                SessionExtensions.Set(context.Session, "Cart", cart);
                
            }

            var shoppingCart = SessionExtensions.Get<ShoppingCart>(context.Session, "Cart");// == null
                

            var model = new ShoppingCartViewModel
            {
                Id = shoppingCart.Id,
                Products = shoppingCart.Products,
            };

            return model;
        }

        public ShoppingCartViewModel AddToShoppingCart(HttpContext context, string productId, int quantity)
        {
            ShoppingCart cart;
            var id = productId;
            if (SessionExtensions.Get<ShoppingCart>(context.Session, "Cart") == null)
            {
                cart = new ShoppingCart
                {
                    Id = Guid.NewGuid().ToString()
                };

                SessionExtensions.Set(context.Session, "Cart", cart);
                
            }

            var shoppingCart = SessionExtensions.Get<ShoppingCart>(context.Session, "Cart");

            

            ICollection<Product> products = shoppingCart.Products;

            var product = this.productRepository.All()
                .FirstOrDefault(p => p.Id.Equals(id));
            product.Quantity = quantity;
            product.Unit -= quantity;

            this.productRepository.Update(product);
            this.productRepository.SaveChangesAsync();

            products.Add(product);

            cart = new ShoppingCart
            {
                Id = shoppingCart.Id,
                Products = products
            };

            SessionExtensions.Set(context.Session, "Cart", cart);

            var model = new ShoppingCartViewModel
            {
                Id = shoppingCart.Id,
                Products = products,
            };

            return model;
        }
    }
}
