using Watchflix.Client.MVC.Models.ViewModels;

namespace Watchflix.Client.MVC.Services.Interfaces
{
    public interface IMovieService
    {
        public Task<List<GetMovieViewModel>> GetAllMovies();
    }
}
