using System.Linq;
using WebshopApp.Data;
using WebshopApp.Models;
using WebshopApp.Services.Contracts;

namespace WebshopApp.Services
{
    public class ProductsServices : IProductsServices
    {
        private readonly WebshopAppContext _context;

        public ProductsServices(WebshopAppContext context)
        {
            _context = context;
        }

        public IQueryable<Product> All() => this._context.Products;
    }
}
