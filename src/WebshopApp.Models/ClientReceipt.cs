using WebshopApp.Models.Base;

namespace WebshopApp.Models
{
    public class ClientReceipt : BaseModel<string>
    {
        public string ClientId { get; set; }
        public virtual WebshopAppUser Client { get; set; }

        public string ReceiptId { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}
