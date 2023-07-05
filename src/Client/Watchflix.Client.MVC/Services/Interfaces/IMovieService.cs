using Watchflix.Client.MVC.Models.ViewModels;

namespace Watchflix.Client.MVC.Services.Interfaces
{
    public interface IMovieService
    {
        public Task<List<GetMovieViewModel>> GetAllMovies(int index = 0, int size = 10);
        public Task<GetMovieViewModel> GetMovieById(Guid movieId);
    }
}
