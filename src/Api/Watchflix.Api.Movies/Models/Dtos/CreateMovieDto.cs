using MediatR;
using Watchflix.Api.Movies.Models.Entities;
using Watchflix.Shared.Models;

namespace Watchflix.Api.Movies.Models.Dtos
{
    public class CreateMovieDto:IDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Rating { get; set; }
        public Guid CategoryId { get; set; }
    }
}
