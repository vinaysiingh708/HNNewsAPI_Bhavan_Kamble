using HNNewsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HNNewsAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        IStoryService _storyService;
        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStory()
        {
            var stories = await _storyService.GetStories();
            return Ok(stories);
        }
    }
}
