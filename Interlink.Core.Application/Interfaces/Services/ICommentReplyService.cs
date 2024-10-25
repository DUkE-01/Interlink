using Interlink.Core.Application.ViewModels.CommentReply;
using Interlink.Core.Domain.Entities;

namespace Interlink.Core.Application.Interfaces.Services
{
    public interface ICommentReplyService : IGenericService<SaveCommentReplyViewModel, CommentReplyViewModel, CommentReply>
    {
        Task<List<CommentReplyViewModel>> GetRepliesByCommentIdAsync(int commentId);
        Task DeleteReplyAsync(int id);
    }
}
