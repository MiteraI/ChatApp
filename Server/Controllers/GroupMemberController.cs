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

            List<GroupMember> getGroup = await _context.groups.ToListAsync();
            List<Conversation> rooms = await _context.conversation.ToListAsync();
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
                return Problem("Entity set 'Context.conversation'  is null.");
            }
            //GroupMember group = new GroupMember
            //{
            //    UserId = user.UserId,
            //    ConversationId = conversation.ConversationId
            //};

            _context.groups.Add(group);
            await _context.SaveChangesAsync();

            return group;
        }
    }
}
