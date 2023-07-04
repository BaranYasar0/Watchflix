using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using Watchflix.Client.MVC.Services.Interfaces;

namespace Watchflix.Client.MVC.Handlers
{
    public class TokenAuthenticationHandler:DelegatingHandler 
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IAuthService _authService;

        public TokenAuthenticationHandler(IHttpContextAccessor contextAccessor, IAuthService authService)
        {
            _contextAccessor = contextAccessor;
            _authService = authService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _contextAccessor.HttpContext.Request.Cookies["token"];
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //var tokenHandler = new JwtSecurityTokenHandler();
                //var jwtToken = tokenHandler.ReadJwtToken(token);

                //var identity = new ClaimsIdentity(_contextAccessor.HttpContext.User.Identity);
                //identity.AddClaims(jwtToken.Claims);
                
                //var principal = new ClaimsPrincipal(identity);
                //_contextAccessor.HttpContext.User = principal;
                var response = await base.SendAsync(request, cancellationToken);
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception("Yetkin Yok!");
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
