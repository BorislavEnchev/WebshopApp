using System.Collections.Generic;
using System.Linq;
using WebshopApp.Services.DataServices.Contracts;
using WebshopApp.Services.Models.ViewModels;

namespace WebshopApp.Web.Models
{
    public class ProductModel
    {
        private readonly IProductsService productsService;
        private readonly ICollection<ProductViewModel> products;

        public ProductModel(IProductsService productsService)
        {
            this.productsService = productsService;
            this.products = (ICollection<ProductViewModel>)this.productsService.GetAll();
        }

        public ICollection<ProductViewModel> FindAll()
        {
            return this.products;
        }

        public ProductViewModel Find(int id)
        {
            return this.products.Single(p => p.Id.Equals(id));
        }
    }
}
