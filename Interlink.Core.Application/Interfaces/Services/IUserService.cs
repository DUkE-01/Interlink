using Interlink.Core.Application.ViewModels.User;
using Interlink.Core.Domain.Entities;

namespace Interlink.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<SaveUserViewModel, UserViewModel, User>
    {
        Task<UserViewModel> Login(LoginViewModel vm);
        Task<List<UserViewModel>> GetAllViewModelWithInclude();
    }
}
