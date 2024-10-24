using Interlink.Core.Application.ViewModels.Comment;
using Interlink.Core.Application.ViewModels.User;


namespace Interlink.Core.Application.ViewModels.Post
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; } = new UserViewModel();
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        // Navegación
        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
