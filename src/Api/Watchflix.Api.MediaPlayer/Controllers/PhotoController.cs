using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Watchflix.Api.MediaPlayer.Services.Interfaces;

namespace Watchflix.Api.MediaPlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPhoto(IFormFile photo, Guid mediaId, CancellationToken cancellationToken)
        {
            var photoPath = await _photoService.AddPhoto(photo, mediaId, cancellationToken);


            return Ok(photoPath);
        }
    }
}
