using MassTransit;
using Watchflix.Api.Movies.EntityFramework;
using Watchflix.Api.Movies.Models.Entities;
using Watchflix.Shared.Events;

namespace Watchflix.Api.Movies.Consumers
{
    public class PhotoStockedEventConsumer:IConsumer<PhotoStockedEvent>
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PhotoStockedEventConsumer> _logger;

        public PhotoStockedEventConsumer(AppDbContext context, ILogger<PhotoStockedEventConsumer> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<PhotoStockedEvent> context)
        {
            try
            {
                Movie movie = await _context.Movies.FindAsync(context.Message.MediaId);

                movie.PictureUrl = context.Message.PhotoUrl;
                _context.Update(movie);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"PhotoUrl güncellendi.{movie.PictureUrl}");
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
    }
}
