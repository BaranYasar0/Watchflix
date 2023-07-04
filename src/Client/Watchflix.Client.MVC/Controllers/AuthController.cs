using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NuGet.Common;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Watchflix.Client.MVC.Models.Inputs;
using Watchflix.Client.MVC.Services.Interfaces;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Watchflix.Client.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly Shared.Models.TokenOptions _tokenOptions;

        public AuthController(IAuthService authService, IOptions<Shared.Models.TokenOptions> tokenOptions)
        {
            _authService = authService;
            _tokenOptions = tokenOptions.Value;
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginInputModel input)
        {

            if (await _authService.LoginAndAddTokenToCookie(input))
                return RedirectToAction("Index", "Home");

            return View();

        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _authService.DeleteCookies();
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}