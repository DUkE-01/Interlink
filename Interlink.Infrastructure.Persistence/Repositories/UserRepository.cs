using Interlink.Core.Application.Interfaces.Repositories;
using Interlink.Core.Application.ViewModels.User;
using Interlink.Core.Domain.Entities;
using Interlink.Core.Application.Helpers;
using Microsoft.EntityFrameworkCore;
using Interlink.Infrastructure.Persistence.Contexts;


namespace Interlink.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<User> AddAsync(User entity)
        {
            entity.PasswordHash = PasswordEncryptation.ComputeSha256Hash(entity.PasswordHash);
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<User> LoginAsync(LoginViewModel loginVm)
        {
            string passwordEncrypt = PasswordEncryptation.ComputeSha256Hash(loginVm.Password);
            User user = await _dbContext.Set<User>().FirstOrDefaultAsync(user => user.Username == loginVm.Email && user.PasswordHash == passwordEncrypt);
            return user;
        }
    }
}
