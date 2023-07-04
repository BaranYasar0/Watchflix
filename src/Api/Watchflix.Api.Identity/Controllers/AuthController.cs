using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Watchflix.Api.Identity.Application.Features.Commands;
using Watchflix.Api.Identity.Application.Helpers.JWT;
using Watchflix.Api.Identity.Application.Models.Dtos;
using Watchflix.Api.Identity.Application.Models.Entities;

namespace Watchflix.Api.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new()
            {
                UserForRegisterDto = userForRegisterDto,
                IpAddress = GetIpAddress()
            };

            RegisterResponseDto result = await _mediator.Send(registerCommand);
            SetAccessTokenToCookie(result.AccessToken);
            return Created("", result.AccessToken);


        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginCommand command)
        {
            var result= await _mediator.Send(command);
            SetAccessTokenToCookie(result.AccessToken);
            CookieOptions cookieOptions = new()
            {
                Expires = DateTime.Now
                    .AddDays(7),
                Secure = true,
            };
            Response.Cookies.Append("accessToken", result.AccessToken.Token, cookieOptions);
            return Ok(result);
        }






        private void SetAccessTokenToCookie(AccessToken accessToken)
        {
            CookieOptions cookieOptions = new()
            {
                Expires =DateTime.Now
                    .AddDays(7),
                SameSite = SameSiteMode.None
            };
            Response.Cookies.Append("accessToken", accessToken.Token, cookieOptions);
        }

        protected string? GetIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For")) return Request.Headers["X-Forwarded-For"];
            return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        }
    }
}
