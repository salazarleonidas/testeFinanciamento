using CreditoApplication.Shared.Users.Repository;
using Domain.Users;

namespace DataServices.Users.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>
        { 
            new User
                {
                    Id = Guid.NewGuid(),
                    Username = "leonidas",
                    Password = "1234"
                }
        };

        public User Get(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;
            return _users.FirstOrDefault(q => q.Username.ToLower() == username.ToLower() &&
                                              q.Password.ToLower() == password.ToLower());
        }
    }
}
