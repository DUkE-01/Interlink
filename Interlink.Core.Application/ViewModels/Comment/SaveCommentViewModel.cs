using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Interlink.Core.Application.ViewModels.Comment
{
    public class SaveCommentViewModel
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
    }
}
