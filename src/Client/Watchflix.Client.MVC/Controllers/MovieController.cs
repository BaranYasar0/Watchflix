using Microsoft.AspNetCore.Mvc;
using Watchflix.Client.MVC.Services.Interfaces;

namespace Watchflix.Client.MVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICategoryService _categoryService;

        public MovieController(IMovieService movieService, ICategoryService categoryService)
        {
            _movieService = movieService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _movieService.GetAllMovies());
        }

        [HttpGet("/Movie/MovieById/{mediaId:guid}")]
        public async Task<IActionResult> MovieById(Guid mediaId)
        {
            return View(await _movieService.GetMovieById(mediaId));
        }

        [HttpGet("Movie/MoviesByCategory/{categoryId:guid}")]
        public async Task<IActionResult> MoviesByCategory([FromRoute] Guid categoryId)
        {
           return View(await _categoryService.GetMoviesForCategoryAsync(categoryId, null));
        }

    }
}
