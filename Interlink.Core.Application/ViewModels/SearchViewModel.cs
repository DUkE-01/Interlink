using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interlink.Core.Application.ViewModels.User;

namespace Interlink.Core.Application.ViewModels
{
    public class SearchViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public string SearchQuery { get; set; }
        public DateTime SearchedAt { get; set; }
    }
}
