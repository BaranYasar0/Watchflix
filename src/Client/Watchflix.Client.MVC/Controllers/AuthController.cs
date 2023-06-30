using Microsoft.AspNetCore.Mvc;
using Watchflix.Client.MVC.Models.Inputs;

namespace Watchflix.Client.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;

        public AuthController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginInputModel input)
        {
            var result=await _httpClient.PostAsJsonAsync("https://localhost:5001/api/auth/login", input);
            if(result.IsSuccessStatusCode)
                return RedirectToAction("Index", "Home");

            
            return View();
        }

    }
}
