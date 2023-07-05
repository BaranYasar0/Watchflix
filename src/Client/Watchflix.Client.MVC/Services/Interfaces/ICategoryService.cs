using Watchflix.Client.MVC.Models.ViewModels;

namespace Watchflix.Client.MVC.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<GetMoviesForCategoryViewModel>> GetMoviesForCategoryAsync(Guid categoryId,Guid? movieId, int index = 0, int size = 10);

        public Task<List<GetCategoryViewModel>> GetAllCategories();
    }
}
