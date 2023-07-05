using Watchflix.Client.MVC.Models.ViewModels;
using Watchflix.Client.MVC.Services.Interfaces;

namespace Watchflix.Client.MVC.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(HttpClient httpClient, ILogger<CategoryService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<GetMoviesForCategoryViewModel>> GetMoviesForCategoryAsync(Guid categoryId,Guid? movieId, int index = 0, int size = 10)
        {
            var result =
              await  _httpClient.GetFromJsonAsync<List<GetMoviesForCategoryViewModel>>($"GetMoviesByCategory/{categoryId}");

            if(movieId is not null)
                result?.Remove(result?.FirstOrDefault(x => x?.Id == movieId));

            if (result is not null)
            {
                _logger.LogInformation($"{categoryId} id li kategorinin {result.Count} adet filmi apiden çekildi");
                return result;
            }

            return null;
        }

        public async Task<List<GetCategoryViewModel>> GetAllCategories()
        {
            var result = await _httpClient.GetFromJsonAsync<List<GetCategoryViewModel>>("");
            if (result is not null)
            {
                return result;
            }

            return null;
        }
    }
}
