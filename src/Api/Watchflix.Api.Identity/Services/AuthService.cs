using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Watchflix.Api.Identity.Application.Helpers.JWT;
using Watchflix.Api.Identity.Application.Models.Entities;
using Watchflix.Api.Identity.EntityFramework;
using Watchflix.Api.Identity.Services.Interfaces;
using Watchflix.Client.MVC.Models.Inputs;

namespace Watchflix.Api.Identity.Services
{
    public class AuthService:IAuthService
    {

        private readonly ITokenHelper _tokenHelper;
        private readonly AppDbContext _context;
        private readonly ILogger<AuthService> _logger;
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthService(ITokenHelper tokenHelper, AppDbContext context, ILogger<AuthService> logger, HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _tokenHelper = tokenHelper;
            _context = context;
            _logger = logger;
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {

            List<UserOperationClaim> userOperationClaims = await _context.UserOperationClaims
                .Where(u => u.UserId == user.Id).Include(i => i.OperationClaim).ToListAsync();

            List<OperationClaim> operationClaims = userOperationClaims.Select(x => new OperationClaim()
                { Id = x.OperationClaim.Id, Name = x.OperationClaim.Name }).ToList();

            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);

            return accessToken;
        }

        public async Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
        {
            RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            return await Task.FromResult(refreshToken);
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            var addedToken=await _context.RefreshTokens.AddAsync(refreshToken);
            
            return addedToken.Entity;
        }

       
    }
}
