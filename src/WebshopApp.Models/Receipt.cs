using System;
using System.Collections.Generic;
using WebshopApp.Models.Base;

namespace WebshopApp.Models
{
    public class Receipt : BaseModel<string>
    {
        public Receipt()
        {
            ReceiptOrders = new HashSet<ReceiptOrder>();
        }

        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;

        public decimal Total { get; set; }

        public string PaymentId { get; set; }
        public virtual Payment Payment { get; set; }

        public string ClientId { get; set; }
        public virtual WebshopAppUser Client { get; set; }

        public string CashierId { get; set; }
        public virtual WebshopAppUser Cashier { get; set; }

        public virtual IEnumerable<ReceiptOrder> ReceiptOrders { get; set; }
    }
}
