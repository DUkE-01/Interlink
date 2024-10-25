using Interlink.Core.Application.ViewModels.Comment;
using Interlink.Core.Domain.Entities;

namespace Interlink.Core.Application.Interfaces.Services
{
    public interface ICommentService : IGenericService<SaveCommentViewModel, CommentViewModel, Comment>
    {
        Task<List<CommentViewModel>> GetCommentsByPostIdAsync(int postId);
        Task DeleteCommentAsync(int id);
    }
}
