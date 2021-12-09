using System.Threading.Tasks;
using ItSkillHouse.Contracts.Recruiter;
using ItSkillHouse.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItSkillHouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecruitersController : ControllerBase
    {
        private readonly IRecruiterService _recruiterService;

        public RecruitersController(IRecruiterService recruiterService)
        {
            _recruiterService = recruiterService;
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] AddRecruiterRequest request)
        {
            var response = await _recruiterService.AddAsync<RecruiterDto>(request);
            return Ok(response);
        }
        
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] EditRecruiterRequest request)
        {
            var response = await _recruiterService.EditAsync<RecruiterDto>(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _recruiterService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List([FromQuery] ListRecruitersRequest request)
        {
            var response = await _recruiterService.GetAsync<RecruitersListItemDto>(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var response = await _recruiterService.GetAsync<RecruiterDto>(id);
            return Ok(response);
        }
    }
}