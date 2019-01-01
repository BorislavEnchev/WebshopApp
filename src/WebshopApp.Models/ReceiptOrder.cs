using WebshopApp.Models.Base;

namespace WebshopApp.Models
{
    public class ReceiptOrder : BaseModel<string>
    {
        public string ReceiptId { get; set; }
        public virtual Receipt Receipt { get; set; }

        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}