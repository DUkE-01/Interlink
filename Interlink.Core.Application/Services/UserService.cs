using Interlink.Core.Application.Interfaces.Services;
using Interlink.Core.Application.Interfaces.Repositories;
using Interlink.Core.Application.ViewModels.User;
using Interlink.Core.Application.Dtos.Email;
using Interlink.Core.Domain.Entities;
using AutoMapper;
using Interlink.Core.Domain.Settings;

namespace Interlink.Core.Application.Services
{
    public class UserService : GenericService<SaveUserViewModel, UserViewModel, User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IEmailService emailService, IMapper mapper) : base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task<UserViewModel> Login(LoginViewModel vm)
        {
            User user = await _userRepository.LoginAsync(vm);

            if (user == null)
            {
                return null;
            }

            UserViewModel userVm = _mapper.Map<UserViewModel>(user);
            return userVm;
        }

        public async Task<SaveUserViewModel> Add(SaveUserViewModel vm)
        {
            SaveUserViewModel userVm = await base.Add(vm);

            await _emailService.SendAsync(new EmailRequest
            {
                To = userVm.Email,
                From = _emailService.MailSettings.EmailFrom,
                Body = $"Se ha creado el usuario: {userVm.Username}",
                Subject = "Creacion de usuario"
            });

            return userVm;
        }

        public async Task<List<UserViewModel>> GetAllViewModelWithInclude()
        {
            var userList = await _userRepository.GetAllWithIncludeAsync(new List<string> { "Products" });

            return userList.Select(user => new UserViewModel
            {
                Username = user.Username,
                Id = user.Id,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
            }).ToList();
        }

    }
}
