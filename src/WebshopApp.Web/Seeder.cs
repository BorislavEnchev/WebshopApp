using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        public static async void SeedRoles(WebshopAppContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);

            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "admin", NormalizedName = "admin" });
            }

            if (!context.Roles.Any(r => r.Name == "user"))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "user", NormalizedName = "user" });
            }

            var adminUser = context.Users.FirstOrDefault(x => x.UserName == "robko@admin.com") ?? new WebshopAppUser
            {
                UserName = "robko@admin.com",
                NormalizedUserName = "ROBKO@ADMIN.COM",
                Email = "asd@asd.com",
                NormalizedEmail = "ASD@ASD.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            if (!context.Users.Any(u => u.UserName == adminUser.UserName))
            {
                var password = new PasswordHasher<WebshopAppUser>();
                var hashed = password.HashPassword(adminUser, "kamenica");
                adminUser.PasswordHash = hashed;
                var userStore = new UserStore<WebshopAppUser>(context);
                await userStore.CreateAsync(adminUser);
                await userStore.AddToRoleAsync(adminUser, "admin");
            }

            await context.SaveChangesAsync();
        }
    }
}
