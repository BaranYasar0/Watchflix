using Microsoft.AspNetCore.Mvc;

namespace Watchflix.Client.MVC.ViewComponents.Home
{
    public class FooterComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
