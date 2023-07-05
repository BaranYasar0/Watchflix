using Microsoft.AspNetCore.Mvc;
using Watchflix.Client.MVC.Services.Interfaces;

namespace Watchflix.Client.MVC.ViewComponents.Movies
{
    public class RelatedCategoryMoviesListViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public RelatedCategoryMoviesListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid categoryId,Guid movieId)
        {
            return View(await _categoryService.GetMoviesForCategoryAsync(categoryId,movieId)
                );
        }
    }
}
