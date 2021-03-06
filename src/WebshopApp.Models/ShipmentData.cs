﻿using WebshopApp.Models.Base;

namespace WebshopApp.Models
{
    public class ShipmentData : BaseModel<string>
    {
        public string Email { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }
    }
}
