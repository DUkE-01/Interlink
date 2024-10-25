using Interlink.Core.Application.Interfaces.Services;
using Interlink.Core.Application.ViewModels.CommentReply;
using Interlink.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Interlink.Controllers
{
    public class CommentReplyController : Controller
    {
        private readonly IGenericService<SaveCommentReplyViewModel, CommentReplyViewModel, CommentReply> _commentReplyService;

        public CommentReplyController(IGenericService<SaveCommentReplyViewModel, CommentReplyViewModel, CommentReply> commentReplyService)
        {
            _commentReplyService = commentReplyService;
        }

        [HttpPost]
        public async Task<IActionResult> AddReply(SaveCommentReplyViewModel replyVm)
        {
            if (!ModelState.IsValid)
            {
                return View(replyVm);
            }

            await _commentReplyService.Add(replyVm);
            return RedirectToAction("Index", "Post");
        }

        [HttpGet]
        public async Task<IActionResult> EditReply(int id)
        {
            var replyVm = await _commentReplyService.GetByIdSaveViewModel(id);
            return View(replyVm);
        }

        [HttpPost]
        public async Task<IActionResult> EditReply(SaveCommentReplyViewModel replyVm, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(replyVm);
            }

            await _commentReplyService.Update(replyVm, id);
            return RedirectToAction("Index", "Post");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReply(int id)
        {
            await _commentReplyService.Delete(id);
            return RedirectToAction("Index", "Post");
        }
    }
}
