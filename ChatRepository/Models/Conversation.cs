using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRepository.Models
{
    public class Conversation
    {
        public int ConversationId { get; set; }
        public string Title { get; set; }
        public ICollection<GroupMember> Groups { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
