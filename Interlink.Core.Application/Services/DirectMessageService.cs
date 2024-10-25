using Interlink.Core.Application.Interfaces.Repositories;
using Interlink.Core.Application.Interfaces.Services;
using Interlink.Core.Application.ViewModels.DirectMessage;
using Interlink.Core.Domain.Entities;
using AutoMapper;
using Interlink.Core.Application.Services;

public class DirectMessageService : GenericService<SaveDirectMessageViewModel, DirectMessageViewModel, DirectMessage>, IDirectMessageService
{
    private readonly IDirectMessageRepository _directMessageRepository;
    private readonly IMapper _mapper;

    public DirectMessageService(IDirectMessageRepository directMessageRepository, IMapper mapper) : base(directMessageRepository, mapper)
    {
        _directMessageRepository = directMessageRepository;
        _mapper = mapper;
    }

    public async Task<List<DirectMessageViewModel>> GetMessagesBetweenUsersAsync(int userId1, int userId2)
    {
        var messages = await _directMessageRepository.GetMessagesBetweenUsersAsync(userId1, userId2);
        return messages.Select(m => _mapper.Map<DirectMessageViewModel>(m)).ToList();
    }
}
