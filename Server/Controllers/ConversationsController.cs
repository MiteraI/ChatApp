using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationsController : ControllerBase
    {
        private readonly Context _context;

        public ConversationsController(Context context)
        {
            _context = context;
        }

        // GET: api/Conversations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conversation>>> Getconversation()
        {
          if (_context.conversation == null)
          {
              return NotFound();
          }
            return await _context.conversation.ToListAsync();
        }

        // GET: api/Conversations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conversation>> GetConversation(int id)
        {
          if (_context.conversation == null)
          {
              return NotFound();
          }
            var conversation = await _context.conversation.FindAsync(id);

            if (conversation == null)
            {
                return NotFound();
            }

            return conversation;
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<Conversation>>> SearchUsers(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return new List<Conversation>();
            }

            // Perform the search operation based on the provided query
            // Here, you can implement your own logic to search for users

            // For demonstration purposes, let's assume you have a list of users
            List<Conversation> rooms = await _context.conversation.ToListAsync();
            // Filter the users based on the search query
            List<Conversation> matchingRooms = rooms.Where(u => u.Title.Contains(query)).ToList();

            if (matchingRooms.Count == 0)
            {
                return new List<Conversation>();
            }

            return matchingRooms;
        }

        // PUT: api/Conversations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConversation(int id, Conversation conversation)
        {
            if (id != conversation.ConversationId)
            {
                return BadRequest();
            }

            _context.Entry(conversation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConversationExists(id))
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

        // POST: api/Conversations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Conversation>> PostConversation(Conversation conversation)
        {
          if (_context.conversation == null)
          {
              return Problem("Entity set 'Context.conversation'  is null.");
          }
            _context.conversation.Add(conversation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConversation", new { id = conversation.ConversationId }, conversation);
        }

        // DELETE: api/Conversations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConversation(int id)
        {
            if (_context.conversation == null)
            {
                return NotFound();
            }
            var conversation = await _context.conversation.FindAsync(id);
            if (conversation == null)
            {
                return NotFound();
            }

            _context.conversation.Remove(conversation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConversationExists(int id)
        {
            return (_context.conversation?.Any(e => e.ConversationId == id)).GetValueOrDefault();
        }
    }
}
