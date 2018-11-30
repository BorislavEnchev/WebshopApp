using System.Collections.Generic;
using WebshopApp.Models.Base;

namespace WebshopApp.Models
{
    public class Product : BaseModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public byte[] Image { get; set; }
    }
}
