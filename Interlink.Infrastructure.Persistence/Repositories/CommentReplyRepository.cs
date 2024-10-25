using AutoMapper;
using Interlink.Core.Application.Interfaces.Repositories;
using Interlink.Core.Domain.Entities;
using Interlink.Core.Application.ViewModels.CommentReply;
using Microsoft.EntityFrameworkCore;
using Interlink.Infrastructure.Persistence.Contexts;


namespace Interlink.Infrastructure.Persistence.Repositories
{
    public class CommentReplyRepository: GenericRepository<CommentReply>, ICommentReplyRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IMapper _mapper;

        public CommentReplyRepository(ApplicationDbContext dbcontext, IMapper mapper) : base(dbcontext)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }
        public async Task<List<CommentReply>> GetRepliesByCommentIdAsync(int commentId)
        {
            return await _dbcontext.CommentReplies
                .Where(cr => cr.CommentId == commentId && !cr.IsDeleted)
                .ToListAsync();
        }
    }
}
