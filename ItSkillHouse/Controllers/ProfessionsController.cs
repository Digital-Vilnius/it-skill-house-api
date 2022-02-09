using System.Threading.Tasks;
using ItSkillHouse.Contracts.Profession;
using ItSkillHouse.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItSkillHouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessionsController : ControllerBase
    {
        private readonly IProfessionService _professionService;

        public ProfessionsController(IProfessionService professionService)
        {
            _professionService = professionService;
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] AddProfessionRequest request)
        {
            var response = await _professionService.AddAsync<ProfessionDto>(request);
            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List()
        {
            var response = await _professionService.GetAsync<ProfessionDto>();
            return Ok(response);
        }
    }
}