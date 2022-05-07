using System.Threading.Tasks;
using ItSkillHouse.Contracts.Note;
using ItSkillHouse.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItSkillHouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SaveNoteRequest request)
        {
            var response = await _noteService.AddAsync<NoteDto>(request);
            return Ok(response);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] SaveNoteRequest request)
        {
            var response = await _noteService.EditAsync<NoteDto>(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _noteService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] ListNotesRequest request)
        {
            var response = await _noteService.GetAsync<NoteDto>(request);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var response = await _noteService.GetAsync<NoteDto>(id);
            return Ok(response);
        }
    }
}