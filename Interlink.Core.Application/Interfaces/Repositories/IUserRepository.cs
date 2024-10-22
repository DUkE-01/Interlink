using Interlink.Core.Application.ViewModels.User;
using Interlink.Core.Domain.Entities;


namespace Interlink.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> LoginAsync(LoginViewModel loginVm);
    }
}
