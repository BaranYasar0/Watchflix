using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using Watchflix.Client.MVC.Models.Inputs;
using Watchflix.Client.MVC.Services.Interfaces;

namespace Watchflix.Client.MVC.Services
{
    public class AuthService : IAuthService

    {
        private readonly ILogger<AuthService> _logger;
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthService(ILogger<AuthService> logger, HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
        }

        public async Task<bool> LoginAndAddTokenToCookie(LoginInputModel input)
        {
            var result = await _httpClient.PostAsJsonAsync("Auth/Login", input);
            if (result.IsSuccessStatusCode)
            {
                if (result.Headers.TryGetValues("Set-Cookie", out var cookieValues))
                {
                    var accessTokenValue = cookieValues.FirstOrDefault(x => x.StartsWith("accessToken="));
                    if (!string.IsNullOrEmpty(accessTokenValue))
                    {
                        _logger.LogInformation(accessTokenValue);
                        var accessToken = accessTokenValue.Split(";").Select(x => x.Trim()).FirstOrDefault(y => y.StartsWith("accessToken="));
                        _logger.LogInformation(accessToken);
                        if (!string.IsNullOrEmpty(accessToken))
                        {
                            accessToken = accessToken.Replace("accessToken=", string.Empty);
                            _logger.LogInformation(accessToken);

                            var tokenHandler = new JwtSecurityTokenHandler();
                            var validationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                ValidIssuer = "watchflix@watchflix.com",
                                ValidAudience = "watchflix@watchflix.com",
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("strongandsecretkeystrongandsecretkey"))
                            };

                            var principal = tokenHandler.ValidateToken(accessToken, validationParameters, out var _);

                            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                            _contextAccessor.HttpContext.Response.Cookies.Append("token", accessToken, new CookieOptions()
                            {
                                Expires = DateTime.Now.AddHours(1),
                                Secure = true
                            });

                            _logger.LogCritical(_contextAccessor.HttpContext.User.Identity.IsAuthenticated.ToString());
                        }

                    }
                }

                return true;
            }
            return false;
        }

        public Task DeleteCookies()
        {
            _contextAccessor.HttpContext.Response.Cookies.Delete("token");
            _contextAccessor.HttpContext.Response.Cookies.Delete("webcookie");
            return Task.CompletedTask;

        }

        private List<Claim> GetClaimsFromStringToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            if (handler.CanReadToken(token))
            {
                var jwtToken = handler.ReadJwtToken(token);
                return jwtToken.Claims.ToList();
            }

            return null;
        }
    }
}
