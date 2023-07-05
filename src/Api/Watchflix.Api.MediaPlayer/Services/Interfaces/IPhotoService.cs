namespace Watchflix.Api.MediaPlayer.Services.Interfaces
{
    public interface IPhotoService
    {
        public Task<string> AddPhoto(IFormFile photo, Guid mediaId, CancellationToken cancellationToken);
    }
}
