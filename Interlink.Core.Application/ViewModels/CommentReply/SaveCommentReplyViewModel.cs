using System.ComponentModel.DataAnnotations;

namespace Interlink.Core.Application.ViewModels.CommentReply
{
    public class SaveCommentReplyViewModel
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
    }
}
