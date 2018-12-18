using System;
using System.Linq;
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

        public static void SeedPictures(WebshopAppContext context)
        {
            var blogs = context.Blogs.Take(10).ToList();

            for (int i = 1; i < 11; i++)
            {
                Blog blog = blogs.Skip(i - 1).First();

                blog.PictureUri = $"images/products/{i}.jpg";
            }

            context.SaveChanges();
        }
    }
}
