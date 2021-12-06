using System;
using System.Threading.Tasks;
using ItSkillHouse.Contracts.ClientProject;
using ItSkillHouse.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItSkillHouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientProjectsController : ControllerBase
    {
        private readonly IClientProjectService _clientProjectService;

        public ClientProjectsController(IClientProjectService clientProjectService)
        {
            _clientProjectService = clientProjectService;
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] AddClientProjectRequest request)
        {
            var response = await _clientProjectService.AddAsync<ClientProjectDto>(request);
            return Ok(response);
        }
        
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] EditClientProjectRequest request)
        {
            var response = await _clientProjectService.EditAsync<ClientProjectDto>(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _clientProjectService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List()
        {
            var response = await _clientProjectService.GetAsync<ClientProjectsListItemDto>();
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _clientProjectService.GetAsync<ClientProjectDto>(id);
            return Ok(response);
        }
    }
}