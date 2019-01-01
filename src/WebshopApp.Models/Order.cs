using System.Collections.Generic;
using WebshopApp.Models.Base;

namespace WebshopApp.Models
{
    public class Order : BaseModel<string>
    {
        public string ClientId { get; set; }
        public virtual WebshopAppUser Client { get; set; }

        public string ShipmentDataId { get; set; }
        public virtual ShipmentData ShipmentData { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
