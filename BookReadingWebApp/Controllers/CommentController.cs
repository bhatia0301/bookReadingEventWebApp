using BookReadingApp.Application.Interfaces;
using BookReadingApp.Core.Modals;
using FacadePattern.FacadeInterface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookReadingApp.Web.Controllers
{
    public class CommentController : Controller
    {
        //private readonly ICommentRepository _commentPageService;
        //public CommentController(ICommentRepository commentPageService)
        //{
        //    _commentPageService = commentPageService;
        //}
        private readonly ICommentFacade _commentPageService;
        public CommentController(ICommentFacade commentPageService)
        {
            _commentPageService = commentPageService;
        }
        public async Task<IActionResult> GetComments()
        {
            var commentList = await _commentPageService.GetComments();
            return View(commentList);
        }
        public async Task<IActionResult> ViewComment(int id)
        {
            var comment = await _commentPageService.ViewComment(id);
            if (comment == null)
            {
                return RedirectToAction("GetComments");
            }
            return View(comment);
        }

        //POST :- CommentController/Create
        [HttpPost]
        public async Task<IActionResult> PostComment(Comment commentViewModel)
        {
            var result = await _commentPageService.PostComment(commentViewModel);
            return RedirectToAction("ViewDetails", "Event", new { id = commentViewModel.EventId });
        }
    }
}
