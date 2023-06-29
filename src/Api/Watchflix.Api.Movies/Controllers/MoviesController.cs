using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Watchflix.Api.Movies.EntityFramework;
using Watchflix.Api.Movies.Features.Commands.Create;
using Watchflix.Api.Movies.Features.Commands.Update;
using Watchflix.Api.Movies.Features.Queries.GetAll;
using Watchflix.Api.Movies.Features.Queries.GetById;
using Watchflix.Api.Movies.Models.Dtos;

namespace Watchflix.Api.Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : BaseController
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(CreateMovieCommand command)
        {
            var addedMovie = await Mediator.Send(command);
            return Ok(addedMovie);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies([FromQuery] PageRequestDto request)
        {
            GetAllMoviesQuery query = new GetAllMoviesQuery();
            query.PageRequestDto = request;
            
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetMovieById([FromRoute] Guid id)
        {
            var query = new GetMovieByIdQuery();
            query.Id = id;
            return Ok(await Mediator.Send(query));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> AddOrUpdateMovieCategory(UpdateMovieCategoryCommand command, [FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
