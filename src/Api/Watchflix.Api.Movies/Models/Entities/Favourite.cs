using Watchflix.Shared.Models;

namespace Watchflix.Api.Movies.Models.Entities
{
    public class Favourite:BaseEntity
    {
        public int Count { get; set; } = 0;

    }
}
