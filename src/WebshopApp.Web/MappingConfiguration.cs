using AutoMapper;
using WebshopApp.Models;
using WebshopApp.Services.Models;
using WebshopApp.Web.Models;

namespace WebshopApp.Web
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            this.CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
