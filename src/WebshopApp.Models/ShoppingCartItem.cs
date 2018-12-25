using WebshopApp.Models.Base;

namespace WebshopApp.Models
{
    public class ShoppingCartItem : BaseModel<int>
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
