using Domain.Users;

namespace CreditoApplication.Shared.Users.Repository
{
    public interface IUserRepository
    {
        User Get(string username, string password);
    }
}
