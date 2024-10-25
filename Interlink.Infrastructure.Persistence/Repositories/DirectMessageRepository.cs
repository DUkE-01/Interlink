using AutoMapper;
using Interlink.Core.Application.Interfaces.Repositories;
using Interlink.Core.Domain.Entities;
using Interlink.Core.Application.ViewModels.DirectMessage;
using Microsoft.EntityFrameworkCore;
using Interlink.Infrastructure.Persistence.Contexts;



namespace Interlink.Infrastructure.Persistence.Repositories
{
    public class DirectMessageRepository : GenericRepository<DirectMessage>, IDirectMessageRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IMapper _mapper;

        public DirectMessageRepository(ApplicationDbContext dbcontext, IMapper mapper) : base(dbcontext)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }
        public async Task<List<DirectMessage>> GetMessagesBetweenUsersAsync(int senderId, int receiverId)
        {
            return await _dbcontext.DirectMessages
                .Where(dm => (dm.SenderId == senderId && dm.ReceiverId == receiverId) ||
                             (dm.SenderId == receiverId && dm.ReceiverId == senderId))
                .ToListAsync();
        }
    }
}
