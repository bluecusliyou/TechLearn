using AutoMapper;

namespace Net5WebApplication.AutoMapper
{
    public class UserService : IUserService
    {
        private IUserRepository UserRepositoryCtor { get; set; }
        private IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            UserRepositoryCtor = userRepository;
            this._mapper = mapper;
        }
        public string Login(string username, string password)
        {
            UserDto userdto = _mapper.Map<UserDto>(UserRepositoryCtor.GetUser());
            return userdto.Name + "登录成功";
        }
    }
}
