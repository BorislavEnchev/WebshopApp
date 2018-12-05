using System.Collections.Generic;
using WebshopApp.Models.Base;

namespace WebshopApp.Models
{
    public class Category : BaseModel<int>
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
