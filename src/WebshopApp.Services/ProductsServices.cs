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

        public IQueryable<Product> All() => _context.Products;

        public Product GetProductById(int id) => _context.Products.FirstOrDefault(x => x.Id == id);
    }
}
