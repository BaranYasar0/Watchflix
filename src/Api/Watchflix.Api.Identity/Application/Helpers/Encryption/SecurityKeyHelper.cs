using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Watchflix.Api.Identity.Application.Helpers.Encryption;

public class SecurityKeyHelper
{
    public static SecurityKey CreateSecurityKey(string securityKey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
    }
}