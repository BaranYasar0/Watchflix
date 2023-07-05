using Watchflix.Shared.Models;

namespace Watchflix.Api.Movies.Models.Dtos
{
    public class MovieQueryDto:IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Duration { get; set; }
        public string PictureUrl { get; set; }
        public double Rating { get; set; }
        public CategoryResponseDto CategoryResponseDto { get; set; }
    }
}
