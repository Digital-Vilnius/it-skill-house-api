using System.Threading.Tasks;
using ItSkillHouse.Contracts.Technology;
using ItSkillHouse.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItSkillHouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechnologiesController : ControllerBase
    {
        private readonly ITechnologyService _technologyService;

        public TechnologiesController(ITechnologyService technologyService)
        {
            _technologyService = technologyService;
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] AddTechnologyRequest request)
        {
            var response = await _technologyService.AddAsync<TechnologyDto>(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _technologyService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List()
        {
            var response = await _technologyService.GetAsync<TechnologyDto>();
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var response = await _technologyService.GetAsync<TechnologyDto>(id);
            return Ok(response);
        }
    }
}