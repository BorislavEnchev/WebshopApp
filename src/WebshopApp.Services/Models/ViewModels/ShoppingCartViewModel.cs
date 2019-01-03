using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebshopApp.Models;

namespace WebshopApp.Services.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel()
        {
            Products = new List<Product>();
        }

        public string Id { get; set; }

        public ICollection<Product> Products { get; set; }

        public decimal Total => Products.Sum(p => p.Price * p.Quantity);
    }
}
