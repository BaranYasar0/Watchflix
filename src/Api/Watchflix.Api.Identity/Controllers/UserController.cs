using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Watchflix.Api.Identity.Application.Features.Commands.Update;
using Watchflix.Api.Identity.Application.Features.Queries.GetAll;

namespace Watchflix.Api.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            GetAllUsersQuery query = new GetAllUsersQuery();

            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        [Route("ConfigureUserClaims")]
        public async Task<IActionResult> ConfigureUserClaims([FromBody] ConfigureUserOperationClaimCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
