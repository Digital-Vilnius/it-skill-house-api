using System.Threading.Tasks;
using ItSkillHouse.Contracts.Email;
using ItSkillHouse.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItSkillHouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailsController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IAuthenticationService _authenticationService;

        public EmailsController(IEmailService emailService, IAuthenticationService authenticationService)
        {
            _emailService = emailService;
            _authenticationService = authenticationService;
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] AddEmailRequest request)
        {
            var loggedUser = await _authenticationService.GetLoggedUserAsync();
            var response = await _emailService.AddAsync<EmailDto>(request, loggedUser);
            return Ok(response);
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> List([FromQuery] ListEmailsRequest request)
        {
            var response = await _emailService.GetAsync<EmailDto>(request);
            return Ok(response);
        }
    }
}