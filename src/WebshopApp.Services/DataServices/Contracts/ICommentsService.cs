using System.Threading.Tasks;

namespace WebshopApp.Services.DataServices.Contracts
{
    public interface ICommentsService
    {
        Task<int> Add(int userId, int productId, string content);

        Task<int> Edit(int id, int userId, int productId, string content);

        void Delete(int id);
    }
}
