using Microsoft.AspNetCore.SignalR;
using Server.Models;

namespace Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task NewMessageReceived(Message message)
        {
            await Clients.All.SendAsync("NewMessageReceived", message);
        }
    }
}
