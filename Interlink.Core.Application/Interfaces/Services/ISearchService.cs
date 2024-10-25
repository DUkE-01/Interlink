using Interlink.Core.Application.ViewModels.Search;
using Interlink.Core.Domain.Entities;

namespace Interlink.Core.Application.Interfaces.Services
{
    public interface ISearchService : IGenericService<SaveSearchViewModel, SearchResultViewModel, SearchResult>
    {
        Task<List<SearchResultViewModel>> SearchPostsAsync(string query);
    }
}
