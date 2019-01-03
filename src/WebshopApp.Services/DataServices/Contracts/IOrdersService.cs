using System.Threading.Tasks;
using WebshopApp.Services.Models.ViewModels;

namespace WebshopApp.Services.DataServices.Contracts
{
    public interface IOrdersService
    {
        Task<string> Create(ShoppingCartViewModel model, string userId);
    }
}
