using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    internal class Message
    {
        public string Username { get; set; }
        public DateTime datetime { get; set; }
        public string messageContent { get; set; }
        public string ConversationId { get; set; }
        public string UserId { get; set; }
    }
}
