using System;
using System.Threading.Tasks;
using ItSkillHouse.Contracts.Contractor;
using ItSkillHouse.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItSkillHouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorsController : ControllerBase
    {
        private readonly IContractorService _contractorService;

        public ContractorsController(IContractorService contractorService)
        {
            _contractorService = contractorService;
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] AddContractorRequest request)
        {
            var response = await _contractorService.AddAsync<ContractorDto>(request);
            return Ok(response);
        }
        
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] EditContractorRequest request)
        {
            var response = await _contractorService.EditAsync<ContractorDto>(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _contractorService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List([FromQuery] ListContractorsRequest request)
        {
            var response = await _contractorService.GetAsync<ContractorsListItemDto>(request);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _contractorService.GetAsync<ContractorDto>(id);
            return Ok(response);
        }
    }
}