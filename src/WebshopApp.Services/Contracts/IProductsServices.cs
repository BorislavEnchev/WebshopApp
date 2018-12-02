using System.Linq;
using WebshopApp.Models;

namespace WebshopApp.Services.Contracts
{
    public interface IProductsServices
    {
        IQueryable<Product> All();
    }
}
