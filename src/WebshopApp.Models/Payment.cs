using System;
using WebshopApp.Models.Base;
using WebshopApp.Models.Enums;

namespace WebshopApp.Models
{
    public class Payment : BaseModel<string>
    {
        public decimal Cost { get; set; }

        public string OrderId { get; set; }
        public virtual Order Order { get; set; }

        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Active;

        public PaymentMethod PaymentMethod { get; set; }

        public DateTime PaidOn { get; set; }
    }
}
