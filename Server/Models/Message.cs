using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public DateTime DateTime { get; set; }
        public string MessageContent { get; set; }
        public int ConversationId { get; set; }
        public int UserId { get; set; }
        public Conversation? Conversation { get; set; }
        public User? User { get; set; }
    }
}
