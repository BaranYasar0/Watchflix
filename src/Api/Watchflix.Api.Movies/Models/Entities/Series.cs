using Watchflix.Shared.Models;

namespace Watchflix.Api.Movies.Models.Entities
{
    public class Series:BaseEntity
    {
        

        public string Name { get; set; } = "Test";
        public int? SeasonCount { get; set; } = 0;
        public int? EpisodeCount { get; set; } = 0;
        public decimal Duration { get; set; } = 120;
        public string? Description { get; set; } = "Deneme Açıklama";
        public double Rating { get; set; } = 9.0;
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public SeriesFavourite? SeriesFavourite { get; set; }

        public Series()
        {
            
        }

        public Series(string name, Category category, int? seasonCount=2, int? episodeCount=10, decimal duration=120 )
        {
            Id= Guid.NewGuid();
            Name = name;
            SeasonCount = seasonCount;
            EpisodeCount = episodeCount;
            Category = category;
        }
    }
}
