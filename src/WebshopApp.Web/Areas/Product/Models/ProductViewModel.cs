namespace WebshopApp.Web.Areas.Product.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public byte[] Image { get; set; }
    }
}
