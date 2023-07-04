using Watchflix.Client.MVC.Models.Inputs;

namespace Watchflix.Client.MVC.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<bool> LoginAndAddTokenToCookie(LoginInputModel input);
        public Task DeleteCookies();
    }
}
