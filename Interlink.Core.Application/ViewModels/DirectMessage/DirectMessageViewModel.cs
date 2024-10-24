using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interlink.Core.Application.ViewModels.User;

namespace Interlink.Core.Application.ViewModels.DirectMessage
{
    public class DirectMessageViewModel
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public UserViewModel Sender { get; set; }
        public int ReceiverId { get; set; }
        public UserViewModel Receiver { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
    }
}
