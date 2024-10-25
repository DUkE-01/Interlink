using Interlink.Core.Application.ViewModels.DirectMessage;
using Interlink.Core.Domain.Entities;

namespace Interlink.Core.Application.Interfaces.Services
{
    public interface IDirectMessageService : IGenericService<SaveDirectMessageViewModel, DirectMessageViewModel, DirectMessage>
    {
        Task<List<DirectMessageViewModel>> GetMessagesBetweenUsersAsync(int senderId, int receiverId);
    }
}
