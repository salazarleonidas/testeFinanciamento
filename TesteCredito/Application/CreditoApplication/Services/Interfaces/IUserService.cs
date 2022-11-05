using CreditoApplication.Shared.Users.ViewModels;

namespace CreditoApplication.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel Get(string username, string password);
    }
}
