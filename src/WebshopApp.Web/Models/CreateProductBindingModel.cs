using System.ComponentModel.DataAnnotations;
using WebshopApp.Services.MappingServices;
using WebshopApp.Services.Models;

namespace WebshopApp.Web.Models
{
    public class CreateProductBindingModel : IMapFrom<ProductViewModel>
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        [MinLength(15)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public byte[] Image { get; set; }
    }
}
