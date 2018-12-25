using System.Collections.Generic;
using WebshopApp.Models.Base;

namespace WebshopApp.Models
{
    public class ShoppingCart : BaseModel<string>
    {
        public ShoppingCart()
        {
            this.ShoppingCartItems = new List<ShoppingCartItem>();
        }
        
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
