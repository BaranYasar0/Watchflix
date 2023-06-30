using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Watchflix.Api.Identity.Application.Helpers.Encryption.Hashing;
using Watchflix.Api.Identity.Application.Helpers.JWT;
using Watchflix.Api.Identity.Application.Models.Dtos;
using Watchflix.Api.Identity.EntityFramework;
using Watchflix.Api.Identity.Services.Interfaces;
using Watchflix.Shared.Events;

namespace Watchflix.Api.Identity.Application.Features.Commands
{
    public class LoginCommand : IRequest<RegisterResponseDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, RegisterResponseDto>
        {
            private readonly AppDbContext _context;
            private readonly IHttpContextAccessor _contextAccessor;
            private readonly IAuthService _authService;
            private readonly IPublishEndpoint _publishEndpoint;
            private readonly ILogger<LoginCommandHandler> _logger;


            public LoginCommandHandler(AppDbContext context, IHttpContextAccessor contextAccessor, ITokenHelper tokenHelper, IAuthService authService, IPublishEndpoint publishEndpoint, ILogger<LoginCommandHandler> logger)
            {
                _context = context;
                _contextAccessor = contextAccessor;
                _authService = authService;
                _publishEndpoint = publishEndpoint;
                _logger = logger;
            }

            public async Task<RegisterResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.UserForLoginDto.Email);
                if (user is null)
                    throw new Exception($"{request.UserForLoginDto.Email}'a ait bir kullanıcı yok.");

                byte[] passwordHash, passwordSalt;

                if (!HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
                    throw new Exception($"{request.UserForLoginDto.Password} yanlıs!");

                AccessToken accessToken = await _authService.CreateAccessToken(user);

                await _publishEndpoint.Publish(new LoginCompletedEvent()
                {
                    AccessTokenMessage = new AccessTokenMessage()
                        { Token = accessToken.Token, Expiration = accessToken.Expiration }
                });

                _logger.LogInformation($"Giriş yapıldı ve token olusturuldu.{accessToken.Token}");

                return new RegisterResponseDto
                {
                    Email = user.Email,
                    AccessToken = accessToken
                };
            }
        }
    }
}
