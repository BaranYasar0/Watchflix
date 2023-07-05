namespace Watchflix.Api.Movies.Models.Dtos
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public List<CategoryWithMovieDto> MovieQueryDtos { get; set; }
        public string Description { get; set; }
    }
}
