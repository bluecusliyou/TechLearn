namespace Net5WebApplication.AutoMapper
{
    public class UserRepository : IUserRepository
    {
        public User GetUser()
        {
            return new User() { Name = "zhangsan", Age = 18, Sex = "male", Password = "SDF" };
        }
    }
}
