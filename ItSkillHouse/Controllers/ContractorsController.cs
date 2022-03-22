using System.Threading.Tasks;
using ItSkillHouse.Contracts.Contractor;
using ItSkillHouse.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItSkillHouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ContractorsController : ControllerBase
    {
        private readonly IContractorService _contractorService;

        public ContractorsController(IContractorService contractorService)
        {
            _contractorService = contractorService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SaveContractorRequest request)
        {
            var response = await _contractorService.AddAsync<ContractorDto>(request);
            return Ok(response);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] SaveContractorRequest request)
        {
            var response = await _contractorService.EditAsync<ContractorDto>(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _contractorService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] ListContractorsRequest request)
        {
            var response = await _contractorService.GetAsync<ContractorDto>(request);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var response = await _contractorService.GetAsync<ContractorDto>(id);
            return Ok(response);
        }
    }
}