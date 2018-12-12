﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using WebshopApp.Data.Common;
using WebshopApp.Models;
using WebshopApp.Services.DataServices.Contracts;

namespace WebshopApp.Services.DataServices
{
    public class ImagesService : IImagesService
    {
        private readonly IProductsService productsService;
        private readonly IHostingEnvironment host;
        private readonly IRepository<Image> imagesRepository;

        public ImagesService(IProductsService productsService, IHostingEnvironment host, IRepository<Image> imagesRepository)
        {
            this.productsService = productsService;
            this.host = host;
            this.imagesRepository = imagesRepository;
        }

        public async void UploadImagesToProduct(int productId, List<IFormFile> files)
        {
            var product = this.productsService.GetProductById<Product>(productId);

            if (product == null)
            {
                throw new KeyNotFoundException();
            }

            var uploadFolderPath = Path.Combine(host.WebRootPath, "images/products");

            if (!Directory.Exists(uploadFolderPath))
            {
                Directory.CreateDirectory(uploadFolderPath);
            }

            foreach (var file in files)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

                var filePath = Path.Combine(uploadFolderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var photo = new Image
                {
                    FileName = fileName,
                    ProductId = product.Id
                };

                product.Images.Add(photo);

                await this.imagesRepository.SaveChangesAsync();
            }
        }

        public IEnumerable<Image> GetImagesOfProduct(int productId)
        {
            var images = this.imagesRepository.All().Where(x => x.ProductId == productId).ToList();

            if (!images.Any())
            {
                throw new ArgumentNullException();
            }

            return images;
        }
    }
}
