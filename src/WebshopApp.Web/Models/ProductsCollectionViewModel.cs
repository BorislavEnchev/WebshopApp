using System.Collections.Generic;
using WebshopApp.Services.Models;

namespace WebshopApp.Web.Models
{
    public class ProductsCollectionViewModel
    {
        public virtual ICollection<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
    }
}
