using Watchflix.Shared.Models;

namespace Watchflix.Api.Movies.Models.Dtos
{
    public class MovieQueryDto:IDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Rating { get; set; }
        public CategoryResponseDto CategoryResponseDto { get; set; }
    }
}
