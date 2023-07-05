using MassTransit;
using Watchflix.Api.MediaPlayer.Services.Interfaces;
using Watchflix.Shared;
using Watchflix.Shared.Events;

namespace Watchflix.Api.MediaPlayer.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly ISendEndpointProvider _sendEndpoint;

        public PhotoService(ISendEndpointProvider sendEndpoint)
        {
            _sendEndpoint = sendEndpoint;
        }

        public async Task<string> AddPhoto(IFormFile photo,Guid mediaId, CancellationToken cancellationToken)
        {
            if (photo != null || photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos",mediaId.ToString()+photo.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                    await photo.CopyToAsync(stream, cancellationToken);
                
                var sender = await _sendEndpoint.GetSendEndpoint(new Uri($"queue:{RabbitMQConstants.PhotoStockedQueueName}"));

                var localPath = Path.Combine("https://localhost:5033/", "photos", mediaId.ToString());

                await sender.Send(new PhotoStockedEvent { PhotoUrl = localPath,MediaId = mediaId});

                return localPath;
            }

            return String.Empty;

        }


    }
}
