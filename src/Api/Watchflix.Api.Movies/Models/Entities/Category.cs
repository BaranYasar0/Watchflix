using Watchflix.Shared.Models;

namespace Watchflix.Api.Movies.Models.Entities
{
    public class Category:BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Movie>? Movies { get; set; } = new List<Movie>();
        public List<Series>? Serieses { get; set; } = new List<Series>();

        public Category()
        {
            
        }
        public Category(string name, string description)
        {
            Id=Guid.NewGuid();
            Name = name;
            Description = description;
        }

    }
}
