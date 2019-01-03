using System;
using System.Threading.Tasks;
using WebshopApp.Data.Common;
using WebshopApp.Models;
using WebshopApp.Services.DataServices.Contracts;
using WebshopApp.Services.Models.ViewModels;

namespace WebshopApp.Services.DataServices
{
    public class OrdersService : IOrdersService
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<Product> productRepository;

        public OrdersService(IRepository<Order> orderRepository, IRepository<Product> productRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }

        public async Task<string> Create(ShoppingCartViewModel model, string userId = null)
        {
            var order = new Order
            {
                Id = Guid.NewGuid().ToString(),
                Products = model.Products,
                ClientId = userId
            };

            await this.orderRepository.AddAsync(order);
            await this.orderRepository.SaveChangesAsync();

            foreach (var product in model.Products)
            {
                product.Unit -= product.Quantity;
            }

            this.productRepository.UpdateRange(model.Products);
            await this.productRepository.SaveChangesAsync();

            return order.Id;
        }
    }
}
