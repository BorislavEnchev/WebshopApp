using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebshopApp.Services.Models;

namespace WebshopApp.Services.DataServices.Contracts
{
    public interface IBlogsService
    {
        IEnumerable<BlogViewModel> GetAll();

        Task<int> Create(string title, string content);

        //bool IsCategoryIdValid(int categoryId);

        //int GetCategoryId(string name);

        //IEnumerable<BlogViewModel> GetAllPostsFromCategory(int categoryId);
    }
}
