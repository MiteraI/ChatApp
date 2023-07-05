using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Server;

namespace Server.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
       
        [JsonIgnore]
        public ICollection<Message>? Messages { get; set; }
        [JsonIgnore]
        public ICollection<GroupMember>? Groups { get; set; }
        [JsonIgnore]
        public Profile? Profile { get; set; }

    }
}
