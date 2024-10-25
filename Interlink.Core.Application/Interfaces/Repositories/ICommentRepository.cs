using Interlink.Core.Domain.Entities;

namespace Interlink.Core.Application.Interfaces.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<List<Comment>> GetCommentsByPostIdAsync(int postId);
    }
}
