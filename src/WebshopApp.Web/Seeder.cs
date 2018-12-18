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

            for (int i = 0; i < 20; i++)
            {
                var blog = new Blog
                {
                    Title = $"BlogTitle{i}",
                    Content = $"{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}{i} nqma takyv blog tova e voenno obuchenie. Vnimanie: Voenno Obuchenie. ALARM, Trevoga, Zaboga. Voenno obuchenie sssssssssssssssssssssss"
                };

                context.Blogs.Add(blog);
            }

            context.SaveChanges();
        }
    }
}
