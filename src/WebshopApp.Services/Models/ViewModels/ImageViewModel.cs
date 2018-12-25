using Microsoft.AspNetCore.Http;

namespace WebshopApp.Services.Models.ViewModels
{
    public class ImageViewModel
    {
        public int ProductId { get; set; }

        public IFormFile Image { get; set; }
    }
}
