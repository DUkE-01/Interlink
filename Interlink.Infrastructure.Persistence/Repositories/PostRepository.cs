using AutoMapper;
using Interlink.Core.Application.Interfaces.Repositories;
using Interlink.Core.Domain.Entities;
using Interlink.Core.Application.ViewModels.Post;
using Microsoft.EntityFrameworkCore;
using Interlink.Infrastructure.Persistence.Contexts;

namespace Interlink.Infrastructure.Persistence.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IMapper _mapper;

        public PostRepository(ApplicationDbContext dbcontext, IMapper mapper) : base(dbcontext)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public async Task<List<PostViewModel>> GetAllViewModelWithInclude()
        {
            var posts = await _dbcontext.Posts
                .Include(p => p.User)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.User)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.Replies)
                        .ThenInclude(r => r.User)
                .ToListAsync();

            return _mapper.Map<List<PostViewModel>>(posts);
        }
    }
}
