using Interlink.Core.Domain.Entities;
using Interlink.Core.Application.ViewModels.DirectMessage;

namespace Interlink.Core.Application.Interfaces.Repositories
{
    public interface IDirectMessageRepository : IGenericRepository<DirectMessage>
    {
        Task<List<DirectMessage>> GetMessagesBetweenUsersAsync(int senderId, int receiverId);
    }
}
