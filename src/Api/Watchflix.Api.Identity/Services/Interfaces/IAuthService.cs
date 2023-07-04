using Watchflix.Api.Identity.Application.Helpers.JWT;
using Watchflix.Api.Identity.Application.Models.Entities;
using Watchflix.Client.MVC.Models.Inputs;

namespace Watchflix.Api.Identity.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<AccessToken> CreateAccessToken(User user);
        public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);
        public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
    }
}
