using Watchflix.Api.Movies.Models.Entities;

namespace Watchflix.Api.Movies.Services.Interfaces
{
    public interface IMovieService
    {
        public Task SyncMovieWithCategoriesAsync(List<Guid> categoryIds,Movie movie);
    }
}
