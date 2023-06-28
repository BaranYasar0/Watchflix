using Watchflix.Api.Identity.Application.Models.Entities;

namespace Watchflix.Api.Identity.Application.Helpers.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, IList<OperationClaim> operationClaims);

    RefreshToken CreateRefreshToken(User user, string ipAddress);
}