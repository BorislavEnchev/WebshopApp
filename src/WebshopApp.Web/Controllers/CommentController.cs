using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebshopApp.Services.DataServices.Contracts;
using WebshopApp.Services.Models.InputModels;

namespace WebshopApp.Web.Controllers
{
    public class CommentController : BaseController
    {
        private readonly ICommentsService commentsService;

        public CommentController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCommentInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var id = await this.commentsService.Add(model.UserId, model.ProductId, model.Content);

            return this.RedirectToAction("Details", "Product", id);
        }
    }
}
