using AutoMapper;
using Interlink.Core.Application.Interfaces.Repositories;
using Interlink.Core.Domain.Entities;
using Interlink.Core.Application.ViewModels.Search;
using Microsoft.EntityFrameworkCore;
using Interlink.Infrastructure.Persistence.Contexts;


namespace Interlink.Infrastructure.Persistence.Repositories
{
    public class SearchRepository : GenericRepository<SearchResult>, ISearchRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IMapper _mapper;

        public SearchRepository(ApplicationDbContext dbcontext, IMapper mapper) : base(dbcontext)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }
        public async Task<List<Post>> SearchPostsAsync(string searchQuery)
        {
            return await _dbcontext.Posts
                .Where(p => p.Content.Contains(searchQuery))
                .ToListAsync();
        }
    }
}
