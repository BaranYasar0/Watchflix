using Microsoft.AspNetCore.Mvc;
using Watchflix.Client.MVC.Services.Interfaces;

namespace Watchflix.Client.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> GetAllCategories()
        {
            return View(await _categoryService.GetAllCategories());
        }
    }
}
