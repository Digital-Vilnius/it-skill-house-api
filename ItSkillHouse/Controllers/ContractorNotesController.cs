using System;
using System.Threading.Tasks;
using ItSkillHouse.Contracts.ContractorNote;
using ItSkillHouse.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItSkillHouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorNotesController : ControllerBase
    {
        private readonly IContractorNoteService _contractorNoteService;

        public ContractorNotesController(IContractorNoteService contractorNoteService)
        {
            _contractorNoteService = contractorNoteService;
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] AddContractorNoteRequest request)
        {
            var response = await _contractorNoteService.AddAsync<ContractorNoteDto>(request);
            return Ok(response);
        }
        
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] EditContractorNoteRequest request)
        {
            var response = await _contractorNoteService.EditAsync<ContractorNoteDto>(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _contractorNoteService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List()
        {
            var response = await _contractorNoteService.GetAsync<ContractorNotesListItemDto>();
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _contractorNoteService.GetAsync<ContractorNoteDto>(id);
            return Ok(response);
        }
    }
}