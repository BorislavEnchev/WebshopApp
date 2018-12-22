using WebshopApp.Models;
using WebshopApp.Services.MappingServices;
using WebshopApp.Services.Models.InputModels;

namespace WebshopApp.Services.Models.ViewModels
{
    public class CommentViewModel : IMapFrom<Comment>, IMapTo<CreateCommentInputModel>
    {
        public string Content { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }
    }
}
