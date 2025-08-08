using Microsoft.AspNetCore.Mvc;

namespace VidEngine.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoController : ControllerBase
    {
        // GET: api/video
        [HttpGet]
        public IActionResult GetAll()
        {
            // Placeholder: return a sample list of videos
            var videos = new[]
            {
                new { Id = 1, Title = "Sample Video 1" },
                new { Id = 2, Title = "Sample Video 2" }
            };
            return Ok(videos);
        }

        // GET: api/video/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Placeholder: return a sample video
            var video = new { Id = id, Title = $"Sample Video {id}" };
            return Ok(video);
        }
    }
}