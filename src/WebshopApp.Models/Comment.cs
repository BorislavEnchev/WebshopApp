using System.ComponentModel.DataAnnotations;
using WebshopApp.Models.Base;

namespace WebshopApp.Models
{
    public class Comment : BaseModel<int>
    {
        [Required]
        public string Content { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int UserId { get; set; }

        public virtual WebshopAppUser User { get; set; }
    }
}
