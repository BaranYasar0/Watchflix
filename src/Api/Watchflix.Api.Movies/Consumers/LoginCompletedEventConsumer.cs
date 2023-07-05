using System.Net.Http.Headers;
using MassTransit;
using Watchflix.Shared.Events;
using Watchflix.Shared.Events.Interfaces;

namespace Watchflix.Api.Movies.Consumers
{
    public class LoginCompletedEventConsumer
    {
        private readonly ILogger<LoginCompletedEventConsumer> _logger;


        public LoginCompletedEventConsumer(ILogger<LoginCompletedEventConsumer> logger)
        {
            _logger = logger;
            
        }

        public async Task Consume(ConsumeContext<LoginCompletedEvent> context)
        {
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", context.Message.AccessTokenMessage.Token);
            

            await Task.CompletedTask;
        }
    }
}
