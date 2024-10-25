using System.ComponentModel.DataAnnotations;

namespace Interlink.Core.Application.ViewModels.DirectMessage
{
    public class SaveDirectMessageViewModel
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; }
    }
}
