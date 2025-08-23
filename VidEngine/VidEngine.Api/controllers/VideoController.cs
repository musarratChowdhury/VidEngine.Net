using Microsoft.AspNetCore.Mvc;
using VidEngine.Api.Services;
using VidEngine.Domain.Entity;

namespace VidEngine.Api.Controllers
{
    // GET: api/video
    [ApiController]
    [Route("api/[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly VideoService _videoService;

        public VideoController(VideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Video>> Get(Guid id)
        {
            var video = await _videoService.GetVideoAsync(id);
            if (video == null) return NotFound();
            return Ok(video);
        }

        [HttpGet]
        public async Task<ActionResult<List<Video>>> GetAll()
            => Ok(await _videoService.GetAllVideosAsync());

        [HttpPost]
        public async Task<ActionResult<Video>> Create([FromBody] Video video)
        {
            var created = await _videoService.AddVideoAsync(video);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Video video)
        {
            if (id != video.Id) return BadRequest("Id mismatch.");
            await _videoService.UpdateVideoAsync(video);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _videoService.DeleteVideoAsync(id);
            return NoContent();
        }
    }
}