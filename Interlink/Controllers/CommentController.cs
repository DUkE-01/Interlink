using Interlink.Core.Application.Interfaces.Services;
using Interlink.Core.Application.ViewModels.Comment;
using Microsoft.AspNetCore.Mvc;
using Interlink.Core.Domain.Entities;

namespace Interlink.Controllers
{
    public class CommentController : Controller
    {
        private readonly IGenericService<SaveCommentViewModel, CommentViewModel, Comment> _commentService;

        public CommentController(IGenericService<SaveCommentViewModel, CommentViewModel, Comment> commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(SaveCommentViewModel commentVm, string userId)
        {
            if (!ModelState.IsValid)
            {
                return View(commentVm);
            }

            await _commentService.Add(commentVm, userId);
            return RedirectToAction("Index", "Post");
        }

        [HttpPost]
        public async Task<IActionResult> ReplyToComment(SaveCommentViewModel replyVm, string userId)
        {
            if (!ModelState.IsValid)
            {
                return View(replyVm);
            }

            await _commentService.Add(replyVm, userId);
            return RedirectToAction("Index", "Post");
        }
    }
}
