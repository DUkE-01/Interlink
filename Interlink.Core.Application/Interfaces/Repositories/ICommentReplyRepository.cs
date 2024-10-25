using Interlink.Core.Domain.Entities;

namespace Interlink.Core.Application.Interfaces.Repositories
{
    public interface ICommentReplyRepository : IGenericRepository<CommentReply>
    {
        Task<List<CommentReply>> GetRepliesByCommentIdAsync(int commentId);
    }
}
