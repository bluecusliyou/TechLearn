namespace Net5WebApplication
{
    public class UserService : IUserService
    { 
        private IUserRepository UserRepositoryCtor { get; set; }        
        public UserService(IUserRepository userRepository)
        {
            UserRepositoryCtor = userRepository;
        }        
        public string Login(string username, string password)
        {
            return "登录成功";
        }
    }
}
