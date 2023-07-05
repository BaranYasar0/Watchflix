using Watchflix.Client.MVC.Models.ViewModels;
using Watchflix.Client.MVC.Services.Interfaces;

namespace Watchflix.Client.MVC.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MovieService> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public MovieService(HttpClient httpClient, ILogger<MovieService> logger, IHttpContextAccessor contextAccessor)
        {
            _httpClient = httpClient;
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

        public async Task<List<GetMovieViewModel>> GetAllMovies(int index = 0,int size=10)
        {

            var response =
                await _httpClient.GetFromJsonAsync<List<GetMovieViewModel>>(
                    $"  ?Index={index}&Size={size}");
            if (response is not null)
            {
                _logger.LogInformation($"{response.Count} adet film apiden çekildi.");
                return response;
            }

            return new List<GetMovieViewModel>();
        }

        
        public async Task<GetMovieViewModel> GetMovieById(Guid movieId)
        {
            var response = await _httpClient.GetFromJsonAsync<GetMovieViewModel>($"{movieId}");
            if (response is not null)
            {
                _logger.LogInformation($"{response.Name} filmi apiden çekildi");
                return response;
            }

            return null;
        }
    }
}
