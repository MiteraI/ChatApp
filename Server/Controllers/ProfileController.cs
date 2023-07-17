using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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
        [HttpGet("Save/{userId}/{profileInfo}")]
        public async Task<ActionResult<Profile>> SaveProfile(string profileInfo,string userId)
        {
            if (_context == null)
            {
                return Problem("Entity set 'Context.messages'  is null.");
            }
            if (string.IsNullOrEmpty(profileInfo)) 
            {
                return BadRequest("You should introduce yourself");
            }
            try {
                //Profile profile = new Profile { UserId = int.Parse(userId.Trim()), Introduction = profileInfo };
                Profile getProfile = _context.profiles.Where(p => p.UserId == int.Parse(userId)).FirstOrDefault();
                if (getProfile is null ) { 
                    return NotFound();
                }
                getProfile.Introduction = profileInfo;
                _context.profiles.Update(getProfile);
                _context.SaveChanges();
                return Ok(profileInfo);
            }
            catch (Exception ex)
            {
                return BadRequest("Exception");
            }
            
            
        }
        [HttpGet("get/{username}")]
        public async Task<ActionResult<Profile>> GetProfileByUser(string username)
        {
            if (_context == null)
            {
                return Problem("Entity set 'Context.messages'  is null.");
            }
            Profile getProfile = await _context.profiles.Where(p => p.User.Name == username).FirstOrDefaultAsync();
            return Ok(getProfile);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Profile>> CreateProfileByUser([FromBody] JObject requestBody)
        {
            if (_context == null)
            {
                return Problem("Entity set 'Context.messages'  is null.");
            }
            if (requestBody is null) {
                return BadRequest("body null");
            }
            string introdution = (string) requestBody["introduction"];
            string userId = (string)requestBody["userId"];
            int parsedId = int.Parse(userId.Trim());
            Profile profile = new Profile { UserId = parsedId, Introduction = introdution };
            _context.profiles.Add(profile);
            _context.SaveChanges();
            return Ok(profile);
        }
    }
}
