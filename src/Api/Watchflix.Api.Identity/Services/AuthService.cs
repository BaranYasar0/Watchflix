using Microsoft.EntityFrameworkCore;
using Watchflix.Api.Identity.Application.Helpers.JWT;
using Watchflix.Api.Identity.Application.Models.Entities;
using Watchflix.Api.Identity.EntityFramework;
using Watchflix.Api.Identity.Services.Interfaces;

namespace Watchflix.Api.Identity.Services
{
    public class AuthService:IAuthService
    {

        private readonly ITokenHelper _tokenHelper;
        private readonly AppDbContext _context;
        public AuthService(ITokenHelper tokenHelper, AppDbContext context)
        {
            _tokenHelper = tokenHelper;
            _context = context;
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
