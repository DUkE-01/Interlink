using Interlink.Core.Domain.Entities;
namespace Interlink.Core.Application.Interfaces.Repositories
{
    public interface ISearchRepository : IGenericRepository<SearchResult>
    {
        Task<List<Post>> SearchPostsAsync(string Searchquery);
    }
}
