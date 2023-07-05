using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly Context _context;
        public ProfileController(Context context)
        {
            this._context = context;
        }
        [HttpPost("Create")]
        public async Task<ActionResult<Profile>> CreateProfile(string profileInfo, User authenticatedUser)
        {
            if (_context.messages == null)
            {
                return Problem("Entity set 'Context.messages'  is null.");
            }
            if (string.IsNullOrEmpty(profileInfo)) 
            {
                return BadRequest("You should introduce yourself");
            }
            Profile profile = new Profile { User = authenticatedUser, Introduction = profileInfo };
            _context.profiles.Add(profile);
            _context.SaveChanges();
            return Ok(profileInfo);
        }
    }
}
