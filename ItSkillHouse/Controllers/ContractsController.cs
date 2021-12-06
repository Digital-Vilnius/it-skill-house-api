using System;
using System.Threading.Tasks;
using ItSkillHouse.Contracts.Contract;
using ItSkillHouse.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItSkillHouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractsController(IContractService contractService)
        {
            _contractService = contractService;
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] AddContractRequest request)
        {
            var response = await _contractService.AddAsync<ContractDto>(request);
            return Ok(response);
        }
        
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] EditContractRequest request)
        {
            var response = await _contractService.EditAsync<ContractDto>(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _contractService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List()
        {
            var response = await _contractService.GetAsync<ContractsListItemDto>();
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _contractService.GetAsync<ContractDto>(id);
            return Ok(response);
        }
    }
}