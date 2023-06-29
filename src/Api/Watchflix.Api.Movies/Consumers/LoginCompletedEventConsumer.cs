using System.Net.Http.Headers;
using MassTransit;
using Watchflix.Shared.Events;
using Watchflix.Shared.Events.Interfaces;

namespace Watchflix.Api.Movies.Consumers
{
    public class LoginCompletedEventConsumer : IConsumer<LoginCompletedEvent>
    {
        private readonly ILogger<LoginCompletedEventConsumer> _logger;
        private readonly HttpClient _httpClient;


        public LoginCompletedEventConsumer(ILogger<LoginCompletedEventConsumer> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task Consume(ConsumeContext<LoginCompletedEvent> context)
        {
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", context.Message.AccessTokenMessage.Token);
            
            _logger.LogInformation($" Buda başka bir deneme {_httpClient.DefaultRequestHeaders.Authorization}");

            await Task.CompletedTask;
        }
    }
}
