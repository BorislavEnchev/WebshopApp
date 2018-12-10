using System.Collections.Generic;
using System.Threading.Tasks;
using WebshopApp.Services.Models;

namespace WebshopApp.Services.DataServices.Contracts
{
    public interface IProductsService
    {
        IEnumerable<ProductViewModel> GetAll();

        Task<int> Create(int categoryId, string name, string description, decimal price/*, byte[] image*/);

        Task<int> Edit(int id, int categoryId, string name, string description, decimal price/*, byte[] image*/);

        void Delete(int id);

        TViewModel GetProductById<TViewModel>(int id);

        IEnumerable<ProductViewModel> GetAllByCategory(int categoryId);

        bool AddRatingToProduct(int productId, int rating);
    }
}
