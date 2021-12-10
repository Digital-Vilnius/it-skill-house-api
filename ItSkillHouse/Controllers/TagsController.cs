using System.Threading.Tasks;
using ItSkillHouse.Contracts.Tag;
using ItSkillHouse.Models.Services;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> Add([FromBody] AddTagRequest request)
        {
            var response = await _tagService.AddAsync<TagDto>(request);
            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List([FromQuery] ListTagsRequest request)
        {
            var response = await _tagService.GetAsync<TagDto>(request);
            return Ok(response);
        }
        
        
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _tagService.DeleteAsync(id);
            return Ok();
        }
    }
}