using System.Threading.Tasks;
using ItSkillHouse.Contracts.Technology;
using ItSkillHouse.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItSkillHouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TechnologiesController : ControllerBase
    {
        private readonly ITechnologyService _technologyService;

        public TechnologiesController(ITechnologyService technologyService)
        {
            _technologyService = technologyService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SaveTechnologyRequest request)
        {
            var response = await _technologyService.AddAsync<TechnologyDto>(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var response = await _technologyService.GetAsync<TechnologyDto>();
            return Ok(response);
        }
    }
}