using Interlink.Core.Application.ViewModels.Comment;
using Interlink.Core.Application.ViewModels.CommentReply;
using Interlink.Core.Application.ViewModels.DirectMessage;
using Interlink.Core.Application.ViewModels.Post;


namespace Interlink.Core.Application.ViewModels.User
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ProfilePicture { get; set; }

        // Navegación
        public ICollection<PostViewModel> Posts { get; set; }
        public ICollection<CommentViewModel> Comments { get; set; }
        public ICollection<CommentReplyViewModel> CommentReplies { get; set; }
        public ICollection<DirectMessageViewModel> SentMessages { get; set; }
        public ICollection<DirectMessageViewModel> ReceivedMessages { get; set; }
    }
}
