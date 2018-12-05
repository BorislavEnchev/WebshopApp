using System.Linq;
using AutoMapper;
using WebshopApp.Models;
using WebshopApp.Services.MappingServices;

namespace WebshopApp.Services.Models
{
    public class CategoryIdAndNameViewModel : IMapFrom<Category>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountOfAllProducts { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Category, CategoryIdAndNameViewModel>()
                .ForMember(c => c.CountOfAllProducts,
                    m => m.MapFrom(p => p.Products.Count()));
        }
    }
}
