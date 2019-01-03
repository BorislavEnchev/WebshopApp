using System.Collections.Generic;
using System.Linq;
using WebshopApp.Models.Base;

namespace WebshopApp.Models
{
    public class ShoppingCart : BaseModel<string>
    {
        public ShoppingCart()
        {
            Products = new List<Product>();
        }

        public virtual ICollection<Product> Products { get; set; }

        public decimal Total => Products.Sum(p => p.Price * p.Quantity);
    }
}
