using System.Collections.Generic;
using System.Threading.Tasks;
using WebshopApp.Services.Models.ViewModels;

namespace WebshopApp.Services.DataServices.Contracts
{
    public interface ICommentsService
    {
        IEnumerable<CommentViewModel> GetAll();

        Task<int> Add(int userId, int productId, string content);

        Task<int> Edit(int id, int userId, int productId, string content);

        void Delete(int id);
    }
}
