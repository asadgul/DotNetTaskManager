using TaskManager.IdentityModels;
using TaskManager.ViewModels;

namespace TaskManager.Services
{
    public interface IUserAuthenticate
    {
        public Task<ApplicationUser> AuthenticateUser(LoginViewModel loginViewModel);
    }
}
