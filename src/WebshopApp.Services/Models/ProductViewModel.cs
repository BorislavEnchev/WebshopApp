using WebshopApp.Models;
using WebshopApp.Services.MappingServices;

namespace WebshopApp.Services.Models
{
    public class ProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public int CategoryId { get; set; }

        public byte[] Image { get; set; }
    }
}
