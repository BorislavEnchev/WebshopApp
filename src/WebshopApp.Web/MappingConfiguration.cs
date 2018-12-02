using AutoMapper;
using WebshopApp.Models;
using WebshopApp.Web.Areas.Product.Models;

namespace WebshopApp.Web
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
