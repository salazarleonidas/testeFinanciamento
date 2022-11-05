using AutoMapper;
using CreditoApplication.Services.Interfaces;
using CreditoApplication.Shared.Users.Repository;
using CreditoApplication.Shared.Users.ViewModels;

namespace CreditoApplication.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public UserViewModel Get(string username, string password)
        {
            var user = _userRepository.Get(username: username, password: password);

            return _mapper.Map<UserViewModel>(user);
        }
    }
}
