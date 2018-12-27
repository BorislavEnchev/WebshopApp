using System.Collections.Generic;
using WebshopApp.Models.Base;

namespace WebshopApp.Models
{
    // Not used in the code yet.
    public class ShoppingCart : BaseModel<string>
    {
        public ShoppingCart()
        {
            this.ShoppingCartItems = new List<ShoppingCartItem>();
        }
        
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
