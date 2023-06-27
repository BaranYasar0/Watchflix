using Watchflix.Shared.Models;

namespace Watchflix.Api.Movies.Models.Entities
{
    public class Movie:BaseEntity
    {
        public string Name { get; set; } = "Test";
        public decimal Duration { get; set; } = 120;
        public string? Description { get; set; } = "Deneme açıklaması";
        public double Rating { get; set; } = 9.0;
        public string? PictureUrl { get; set; }
        public Guid? CategoryId { get; set; }
        public Category? Category{ get; set; } 
        public MovieFavourite? MovieFavourite { get; set; }

        public Movie()
        {
            
        }
        public Movie(Category? category,string name = "Test", decimal duration = 120, string? description = "Deneme açıklaması", double rating = 9.0)
        {
            Id= Guid.NewGuid();
            Name = name;
            Duration = duration;
            Description = description;
            Rating = rating;
            Category = category;
        }
    }
}
