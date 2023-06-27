using Watchflix.Shared.Models;

namespace Watchflix.Api.Movies.Models.Dtos
{
    public class CreateMovieResponseDto:IDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Rating { get; set; }
        public List<CategoryResponseDto> CategoryResponseDtos { get; set; }
    }
}
