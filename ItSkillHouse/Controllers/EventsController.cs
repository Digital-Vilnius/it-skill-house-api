using System.Threading.Tasks;
using ItSkillHouse.Contracts.Event;
using ItSkillHouse.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItSkillHouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] AddEventRequest request)
        {
            var response = await _eventService.AddAsync<EventDto>(request);
            return Ok(response);
        }
        
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] EditEventRequest request)
        {
            var response = await _eventService.EditAsync<EventDto>(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _eventService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List([FromQuery] ListEventsRequest request)
        {
            var response = await _eventService.GetAsync<EventDto>(request);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var response = await _eventService.GetAsync<EventDto>(id);
            return Ok(response);
        }
    }
}