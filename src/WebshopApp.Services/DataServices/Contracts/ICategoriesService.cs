using System.Collections.Generic;
using WebshopApp.Services.Models;

namespace WebshopApp.Services.DataServices.Contracts
{
    public interface ICategoriesService
    {
        IEnumerable<CategoryViewModel> GetAll();

        bool IsCategoryIdValid(int categoryId);

        int? GetCategoryId(string name);
    }
}
