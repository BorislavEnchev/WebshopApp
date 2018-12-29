using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopApp.Data.Common;
using WebshopApp.Models;
using WebshopApp.Services.DataServices.Contracts;
using WebshopApp.Services.MappingServices;
using WebshopApp.Services.Models;
using WebshopApp.Services.Models.ViewModels;

namespace WebshopApp.Services.DataServices
{
    public class ProductsService : IProductsService
    {
        private readonly IRepository<Product> productsRepository;

        public ProductsService(IRepository<Product> productsRepository, IImagesService imagesService)
        {
            this.productsRepository = productsRepository;
        }

        //specialy made for testing
        public IEnumerable<Product> GetAllProducts() => this.productsRepository.All();

        public IEnumerable<ProductViewModel> GetAll() => this.productsRepository.All().To<ProductViewModel>();
        
        public async Task<int> Create(int categoryId, string name, string description, decimal price)
        {
            var product = new Product()
            {
                CategoryId = categoryId,
                Name = name,
                Description = description,
                Price = price
            };

            await this.productsRepository.AddAsync(product);
            await this.productsRepository.SaveChangesAsync();

            return product.Id;
        }

        public async Task<int> Edit(int id, int categoryId, string name, string description, decimal price)
        {
            var products = productsRepository.All();

            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new KeyNotFoundException();
            }

            product.Id = id;
            product.CategoryId = categoryId;
            product.Name = name;
            product.Description = description;
            product.Price = price;

            await this.productsRepository.SaveChangesAsync();

            return product.Id;
        }

        public void Delete(int id)
        {
            var product = productsRepository.All().FirstOrDefault(x => x.Id == id);

            this.productsRepository.Delete(product);
            this.productsRepository.SaveChangesAsync();
        }

        public TViewModel GetProductById<TViewModel>(int id)
        {
            var product = this.productsRepository.All().Where(x => x.Id == id)
                .To<TViewModel>().FirstOrDefault();

            return product;
        }

        public IEnumerable<ProductViewModel> GetAllByCategory(int categoryId) 
            => this.productsRepository.All()
                .Where(p => p.CategoryId == categoryId)
                .To<ProductViewModel>();

        public bool AddRatingToProduct(int productId, int rating)
        {
            throw new System.NotImplementedException();
        }
    }
}
