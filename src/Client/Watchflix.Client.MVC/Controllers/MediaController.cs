using Microsoft.AspNetCore.Mvc;

namespace Watchflix.Client.MVC.Controllers
{
    public class MediaController : Controller
    {
        [HttpGet("Movie/PlayMovie/{movieId:guid}")]
        public IActionResult PlayMovie(Guid movieId)
        {
            return View();
        }
    }
}
