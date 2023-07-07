using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Server.Models;
using System.Text.Json.Nodes;

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
        /*[HttpPost("login")]
        public IActionResult LoginUser(string name, string password)
        {
            //User user = _context.users.FirstOrDefault(u => u.Name == userCredentials.Name);
            User user = _context.users.FirstOrDefault(x =>  x.Name == name);
            if (user == null)
            {
                return NotFound("Could not find user name");
            }
            else
            {
                if (user.Password.Equals(password))
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Invalid password");
                }
            }
        }*/

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
        public async Task<ActionResult<User>> RegisterUser( User user)
        {
            if (_context.users == null)
            {
                return Problem("Entity set 'Context.conversation'  is null.");
            }
            if (user is null) {
                return BadRequest("user null");
            }
            if (_context.users.FirstOrDefault(u => u.Name.Equals(user.Name.Trim())) is not null) {
                return BadRequest("username already taken");
            }
            User newUser = new User { Name = user.Name,Password = user.Password };
            _context.users.Add(newUser);
            await _context.SaveChangesAsync();
            User GetNewUser = _context.users.FirstOrDefault(u => u.Name == newUser.Name.Trim());
            return GetNewUser;
            //return CreatedAtAction("Account registered: ", new { id = GetNewUser.UserId }, GetNewUser);
        }

    }
}
