using System.Collections.Generic;

namespace WebshopApp.Web.Areas.Product.Models
{
    public class ProductsCollectionViewModel
    {
        public virtual ICollection<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
    }
}
