using AutoMapper;
using WebshopApp.Models;
using WebshopApp.Services.Models.ViewModels;

namespace WebshopApp.Services.DataServices.Tests
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<ProductViewModel, Product>().ReverseMap();
        }
    }
}
