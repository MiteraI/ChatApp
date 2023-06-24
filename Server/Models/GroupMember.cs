    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class GroupMember
    {
        public int UserId { get; set; }
        public int ConversationId { get; set; }
        public User User { get; set; }
        public Conversation Conversation { get; set; }
    }
}
