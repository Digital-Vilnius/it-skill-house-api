using System.Threading.Tasks;
using ItSkillHouse.Contracts.Tag;
using ItSkillHouse.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItSkillHouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SaveTagRequest request)
        {
            var response = await _tagService.AddAsync<TagDto>(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var response = await _tagService.GetAsync<TagDto>();
            return Ok(response);
        }
    }
}