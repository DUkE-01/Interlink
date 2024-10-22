using Interlink.Application.ViewModels.Entities;
using Interlink.Core.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interlink.Core.Application.ViewModels
{
    public class CommentReplyViewModel
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public CommentViewModel Comment { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
