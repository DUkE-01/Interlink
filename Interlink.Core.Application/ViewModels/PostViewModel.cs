using Interlink.Application.ViewModels.Entities;
using Interlink.Core.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Interlink.Core.Application.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        // Navegación
        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
