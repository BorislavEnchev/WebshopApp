using WebshopApp.Models.Base;

namespace WebshopApp.Models
{
    public class Category : BaseModel<int>
    {
        public string Name { get; set; }
    }
}
