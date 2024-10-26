using Interlink.Core.Application.ViewModels.Comment;
using Interlink.Core.Application.ViewModels.Post;
using Interlink.Core.Application.ViewModels.CommentReply;
using Interlink.Core.Application.ViewModels.User;

namespace Interlink.Core.Application.ViewModels.Home
{
    public class HomeViewModel
    {
        public List<PostViewModel> Posts { get; set; } = new List<PostViewModel>();
        public SavePostViewModel NewPost { get; set; }
        public List<UserViewModel> Username { get; set; }
        public List<CommentViewModel> Comments { get; set; }
        public List<CommentViewModel> Content { get; set; }
        public List<CommentViewModel> Replies { get; set; }
        public List<CommentReplyViewModel> CommentsReplies { get; set; }
    }
}
