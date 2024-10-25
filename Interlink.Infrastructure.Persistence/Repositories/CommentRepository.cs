using AutoMapper;
using Interlink.Core.Application.Interfaces.Repositories;
using Interlink.Core.Domain.Entities;
using Interlink.Core.Application.ViewModels.Comment;
using Microsoft.EntityFrameworkCore;
using Interlink.Infrastructure.Persistence.Contexts;


namespace Interlink.Infrastructure.Persistence.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IMapper _mapper;

        public CommentRepository(ApplicationDbContext dbcontext, IMapper mapper) : base(dbcontext)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }
        public async Task<List<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            return await _dbcontext.Comments
                .Where(c => c.PostId == postId && !c.IsDeleted)
                .ToListAsync();
        }
    }
}
