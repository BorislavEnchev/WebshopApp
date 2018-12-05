﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebshopApp.Services.Models;

namespace WebshopApp.Services.DataServices
{
    public interface IProductsService
    {
        IEnumerable<ProductViewModel> GetAll();

        Task<int> Create(int categoryId, string name, string description, decimal price/*, byte[] image*/);

        TViewModel GetProductById<TViewModel>(int id);

        IEnumerable<ProductViewModel> GetAllByCategory(int categoryId);

        bool AddRatingToProduct(int productId, int rating);
    }
}
