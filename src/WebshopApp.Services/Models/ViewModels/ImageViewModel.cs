using Microsoft.AspNetCore.Http;
using WebshopApp.Models;
using WebshopApp.Services.MappingServices;

namespace WebshopApp.Services.Models.ViewModels
{
    public class ImageViewModel : IMapFrom<Image>
    {
        public int ProductId { get; set; }

        public IFormFile Image { get; set; }
    }
}
