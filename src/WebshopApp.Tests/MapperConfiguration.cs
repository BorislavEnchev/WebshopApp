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
            CreateMap<Product, Product>().ReverseMap();
            CreateMap<CategoryViewModel, Category>().ReverseMap();
            CreateMap<Category, Category>().ReverseMap();
            CreateMap<CommentViewModel, Comment>().ReverseMap();
            CreateMap<Comment, Comment>().ReverseMap();
        }
    }
}
