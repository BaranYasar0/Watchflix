using Watchflix.Api.Identity.Application.Helpers.JWT;
using Watchflix.Api.Identity.Application.Models.Entities;

namespace Watchflix.Api.Identity.Application.Models.Dtos
{
    public class RegisterResponseDto
    {
        public string Email { get; set; }
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
