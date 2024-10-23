using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Interlink.Core.Domain.Common;

namespace Interlink.Core.Domain.Entities
{
    public class User : AuditableBaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ProfilePicture { get; set; }

        
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<CommentReply> CommentReplies { get; set; }
        public ICollection<DirectMessage> SentMessages { get; set; }
        public ICollection<DirectMessage> ReceivedMessages { get; set; }
    }
}
