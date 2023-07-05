using Microsoft.AspNetCore.Mvc;
using Watchflix.Client.MVC.Services.Interfaces;

namespace Watchflix.Client.MVC.ViewComponents.Movies
{
    public class TopRatedMoviesList : ViewComponent
    {
        private IMovieService _movieService;

        public TopRatedMoviesList(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _movieService.GetAllMovies(0, 8);
            return View(result.OrderByDescending(x => x.Rating).ToList());
        }
    }
}
