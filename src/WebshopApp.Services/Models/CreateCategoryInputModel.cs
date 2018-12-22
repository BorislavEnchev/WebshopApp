using System.ComponentModel.DataAnnotations;

namespace WebshopApp.Services.Models
{
    public class CreateCategoryInputModel
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }
    }
}
