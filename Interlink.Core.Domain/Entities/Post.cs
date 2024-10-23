using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Interlink.Core.Domain.Entities
{
    public class Post
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        
        public ICollection<Comment> Comments { get; set; }
    }
}
