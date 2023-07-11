using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMemberController : ControllerBase
    {
        private readonly Context _context;

        public GroupMemberController(Context context)
        {
            _context = context;
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<Conversation>>> SearchGroupThroughUserId(int userId)
        {

            List<GroupMember> getGroup = await _context.groups.Where(g => g.UserId == userId).ToListAsync();
            if (getGroup.Count == 0) {
                return new List<Conversation>();
            }
            List<Conversation> rooms =  _context.conversation.ToList();
            List<Conversation> matchingRooms = new List<Conversation>();
            foreach (GroupMember group in getGroup)
            {
                int conId = group.ConversationId;
                foreach (Conversation room in rooms) {
                    if (room.ConversationId == conId) { 
                        matchingRooms.Add(room);
                    }
                }
            }
            if (matchingRooms.Count == 0)
            {
                return new List<Conversation>();
            }

            return matchingRooms;
        }

        [HttpPost]
        public async Task<ActionResult<GroupMember>> InsertGroup(GroupMember group)
        {
            if (_context.conversation == null)
            {
                return StatusCode(500, "Entity set 'Context.conversation' is null.");
            }
            Conversation conversation = _context.conversation.
                Where(conversation => conversation.ConversationId == group.ConversationId).FirstOrDefault();
            if (!(conversation.Password == null))
            {
                return StatusCode(202, "Room is private, You will have to insert password");
            }
            _context.groups.Add(group);
            await _context.SaveChangesAsync();

            return group;
        }

        [HttpPost("private")]
        public async Task<ActionResult<GroupMember>> InsertGroupWithPassword(GroupMember group)
        {
            if (_context.conversation == null)
            {
                return StatusCode(500, "Entity set 'Context.conversation' is null.");
            }
            
            _context.groups.Add(group);
            await _context.SaveChangesAsync();

            return group;
        }
    }
}
