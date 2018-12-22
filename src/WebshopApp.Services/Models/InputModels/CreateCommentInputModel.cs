using System.ComponentModel.DataAnnotations;
using WebshopApp.Models;
using WebshopApp.Services.MappingServices;
using WebshopApp.Services.Models.ViewModels;

namespace WebshopApp.Services.Models.InputModels
{
    public class CreateCommentInputModel: IMapFrom<Comment>, IMapTo<CommentViewModel>
    {
        [Required]
        [MinLength(10)]
        [MaxLength(500)]
        public string Content { get; set; }
        
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
