using Microsoft.AspNetCore.Mvc;

namespace Watchflix.Client.MVC.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
