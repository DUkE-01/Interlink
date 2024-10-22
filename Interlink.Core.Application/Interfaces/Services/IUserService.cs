using Interlink.Core.Application.ViewModels.User;
using Interlink.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interlink.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<SaveUserViewModel, UserViewModel, User>
    {
        Task<UserViewModel> Login(LoginViewModel vm);
        Task<List<UserViewModel>> GetAllViewModelWithInclude();
    }
}
