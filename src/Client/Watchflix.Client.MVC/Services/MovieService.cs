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

        public async Task<List<GetMovieViewModel>> GetAllMovies()
        {

            var response = await _httpClient.GetFromJsonAsync<List<GetMovieViewModel>>("https://localhost:5032/api/Movies/?PageNumber=0&PageSize=10");
            if (response is not null)
            {
                _logger.LogInformation($"Filmler apiden çekildi.");
                return response;
            }

            return new List<GetMovieViewModel>();
        }
    }
}
