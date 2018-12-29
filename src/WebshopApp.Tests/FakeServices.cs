using System;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebshopApp.Data;
using WebshopApp.Models;
using WebshopApp.Services.DataServices.Contracts;
using WebshopApp.Services.MappingServices;
using WebshopApp.Services.Models.ViewModels;

namespace WebshopApp.Services.DataServices.Tests
{
    public class FakeServices
    {
        protected IServiceProvider Provider { get; set; }

        protected WebshopAppContext Context { get; set; }

        public void SetUp()
        {
            Mapper.Reset();
            Mapper.Initialize(x => { x.AddProfile<MapperConfiguration>(); });
            var services = SetServices();
            this.Provider = services.BuildServiceProvider();
            this.Context = this.Provider.GetRequiredService<WebshopAppContext>();
        }

        private ServiceCollection SetServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<WebshopAppContext>(
                opt => opt.UseInMemoryDatabase(Guid.NewGuid()
                    .ToString()));

            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<ICommentsService, CommentsService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<IImagesService, ImagesService>();
            services.AddScoped<IBlogsService, BlogsService>();

            services.AddIdentity<WebshopAppUser, IdentityRole>()
                .AddEntityFrameworkStores<WebshopAppContext>()
                .AddDefaultTokenProviders();

            services.AddAutoMapper();

            return services;
        }
    }
}
