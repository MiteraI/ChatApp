using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly Context _context;

        public CommonController(Context context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult LoginUser(User userCredentials)
        {
            User user = _context.users.FirstOrDefault(u => u.Name == userCredentials.Name);

            if (user == null)
            {
                return NotFound("Could not find user name");
            }
            else
            {
                if (user.Password.Equals(userCredentials.Password))
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Invalid password");
                }
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser(User user)
        {
            if (_context.users == null)
            {
                return Problem("Entity set 'Context.conversation'  is null.");
            }
            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Account registered: ", new { id = user.UserId }, user);
        }

    }
}
