using Microsoft.AspNetCore.Mvc;
using Watchflix.Client.MVC.Services.Interfaces;

namespace Watchflix.Client.MVC.Controllers
{
    public class MovieController : Controller
    {
     private readonly IMovieService _movieService;

     public MovieController(IMovieService movieService)
     {
         _movieService = movieService;
     }

     public async Task<IActionResult> Index()
        {
            
            return View(await _movieService.GetAllMovies());
        }
    }
}
