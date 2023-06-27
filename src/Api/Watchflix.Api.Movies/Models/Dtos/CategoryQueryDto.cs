using Watchflix.Shared.Models;

namespace Watchflix.Api.Movies.Models.Dtos
{
    public class CategoryQueryDto:IDto
    {
        public string Name { get; set; }
        public List<CategoryWithMovieDto> CategoryWithMovieDtos { get; set; }
        public string Description { get; set; }
    }
}
