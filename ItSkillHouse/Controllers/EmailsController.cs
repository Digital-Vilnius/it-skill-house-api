using System.Threading.Tasks;
using ItSkillHouse.Contracts.Email;
using ItSkillHouse.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace ItSkillHouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [RequiredScope("access_as_user")]
    public class EmailsController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailsController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Send([FromBody] SendEmailRequest request)
        {
            await _emailService.SendEmail(request);
            return Ok();
        }
    }
}