using System;
using WebshopApp.Data;
using WebshopApp.Models;

namespace WebshopApp.Web
{
    public static class Seeder
    {
        public static void Seed(WebshopAppContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                var product = new Product
                {
                    Name = $"Product {i}",
                    Description = $"Description of product {i}",
                    Price = (decimal)(new Random().NextDouble() * (new Random()).Next(10000)),
                    CategoryId = new Random().Next(1,6)
                };

                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}
