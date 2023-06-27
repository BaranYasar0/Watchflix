using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Watchflix.Api.Movies.Features.Commands.Create;
using Watchflix.Api.Movies.Features.Queries.GetAll;
using Watchflix.Api.Movies.Features.Queries.GetById;
using Watchflix.Api.Movies.Models.Dtos;

namespace Watchflix.Api.Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery] PageRequestDto pageRequestDto)
        {
            var query = new GetAllCategoriesQuery();
            query.PageRequestDto=pageRequestDto;
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute]Guid id)
        {
            var query = new GetCategoryByIdQuery();
            query.Id = id;
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
