using System.Collections.Generic;
using WebshopApp.Services.Models;

namespace WebshopApp.Services.DataServices.Contracts
{
    public interface IBlogsService
    {
        IEnumerable<BlogViewModel> GetAll();

        //bool IsCategoryIdValid(int categoryId);

        //int GetCategoryId(string name);

        //IEnumerable<BlogViewModel> GetAllPostsFromCategory(int categoryId);
    }
}
