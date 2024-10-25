using Interlink.Core.Application.ViewModels.Post;
using Interlink.Core.Application.ViewModels.User;

namespace Interlink.Core.Application.ViewModels.Search
{
    public class SearchResultViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public string SearchQuery { get; set; }
        public DateTime SearchedAt { get; set; }

        public ICollection<PostViewModel> Posts { get; set; }
    }
}
