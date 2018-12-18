using System;
using WebshopApp.Models;
using WebshopApp.Services.MappingServices;

namespace WebshopApp.Services.Models
{
    public class BlogViewModel : IMapFrom<Blog>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        //TODO: Image integration
    }
}
