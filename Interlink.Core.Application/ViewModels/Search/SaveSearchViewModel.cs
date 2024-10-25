using Interlink.Core.Application.ViewModels.Post;
using System.ComponentModel.DataAnnotations;
namespace Interlink.Core.Application.ViewModels.Search
{
    public class SaveSearchViewModel
    {
        public int UserId { get; set; }
        public string SearchQuery { get; set; }
    }
}
