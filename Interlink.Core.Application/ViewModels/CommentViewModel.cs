using Interlink.Core.Application.ViewModels;
using Interlink.Core.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interlink.Application.ViewModels.Entities
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public PostViewModel Post { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        // Navegación
        public ICollection<CommentReplyViewModel> Replies { get; set; }
    }
}
