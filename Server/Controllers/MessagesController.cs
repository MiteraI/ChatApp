using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Server;
using Server.Hubs;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly Context _context;
        private readonly IHubContext<ChatHub> _hubcontext;

        public MessagesController(Context context, IHubContext<ChatHub> hubContext)
        {
            _context = context;
            _hubcontext = hubContext;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> Getmessages()
        {
          if (_context.messages == null)
          {
              return NotFound();
          }
            return await _context.messages.ToListAsync();
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(int id)
        {
          if (_context.messages == null)
          {
              return NotFound();
          }
            var message = await _context.messages.FindAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        //GET messages from a particular conversation
        [HttpGet("conversation/{conversationId}")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessageFromConversation(int conversationId)
        {
            if (_context.messages == null)
            {
                return NotFound();
            }
            var conversationMessages = await _context.messages.Where(m => m.ConversationId == conversationId)
                    .Include(m => m.User).ToListAsync();
            
            return conversationMessages;
        }

        // PUT: api/Messages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(int id, Message message)
        {
            if (id != message.MessageId)
            {
                return BadRequest();
            }

            _context.Entry(message).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(Message message)
        {
          if (_context.messages == null)
          {
              return Problem("Entity set 'Context.messages'  is null.");
          }
            _context.messages.Add(message);
            await _context.SaveChangesAsync();
            User user = _context.users.Where(u => u.UserId == message.UserId).FirstOrDefault();
            //Adding SignalR to handle real-time
            //Message will send to all client, message is saved to database are 2 different action
            await _hubcontext.Clients.Group(message.ConversationId.ToString()).SendAsync("ReceiveMessage", message.MessageContent, user.Name, message.DateTime.ToString());
            return CreatedAtAction("GetMessage", new { id = message.MessageId }, message);
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            if (_context.messages == null)
            {
                return NotFound();
            }
            var message = await _context.messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            _context.messages.Remove(message);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageExists(int id)
        {
            return (_context.messages?.Any(e => e.MessageId == id)).GetValueOrDefault();
        }
    }
}
