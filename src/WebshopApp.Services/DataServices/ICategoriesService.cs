using System.Collections.Generic;
using WebshopApp.Services.Models;

namespace WebshopApp.Services.DataServices
{
    public interface ICategoriesService
    {
        IEnumerable<CategoryIdAndNameViewModel> GetAll();

        bool IsCategoryIdValid(int categoryId);

        int? GetCategoryId(string name);
    }
}
