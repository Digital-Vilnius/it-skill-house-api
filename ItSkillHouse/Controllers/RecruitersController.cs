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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List()
        {
            var response = await _recruiterService.GetAsync<RecruiterDto>();
            return Ok(response);
        }
    }
}