using System.Collections.Generic;

namespace WebshopApp.Services.Models.ViewModels
{
    public class AllCommentsByProductViewModel
    {
        public AllCommentsByProductViewModel()
        {
            CommentViewModels = new HashSet<CommentViewModel>();
        }

        public IEnumerable<CommentViewModel> CommentViewModels { get; set; }
    }
}
