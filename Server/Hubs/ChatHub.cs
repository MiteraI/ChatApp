using Microsoft.AspNetCore.SignalR;
using Server.Models;

namespace Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string chatRoomId, string message)
        {
            // Handle the received message and perform any necessary actions
            // For example, store the message in the database, associate it with the chat room, etc.

            // Send the message to all clients in the chat room, excluding the sender
            await Clients.OthersInGroup(chatRoomId).SendAsync("ReceiveMessage", message);
        }
        public async Task ReceiveMessage(string message)
        {
            // Handle the received message
            // For example, you can save the message to the database and broadcast it to other clients

            // Save the message to the database
            // ...

            // Broadcast the message to other clients in the chat room
            await Clients.Others.SendAsync("ReceiveMessage", message);
        }
        public async Task JoinChatRoom(string chatRoomId)
        {
            // Add the user to the specified chat room group
            await Groups.AddToGroupAsync(Context.ConnectionId, chatRoomId);
        }

        public async Task LeaveChatRoom(string chatRoomId)
        {
            // Remove the user from the specified chat room group
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatRoomId);
        }

        public override async Task OnConnectedAsync()
        {
            // Perform any necessary actions when a client connects
            // For example, associate the client's connection ID with their user ID in a dictionary
            var clientConnectionId = Context.ConnectionId;
            var roomName = Context.GetHttpContext().Request.Headers["room"].ToString();
            // Add the client to the appropriate group based on the room
            await Groups.AddToGroupAsync(clientConnectionId, roomName);

            // Store the username and other relevant information if needed

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Perform any necessary actions when a client disconnects
            // For example, remove the client's connection ID from the dictionary



            await base.OnDisconnectedAsync(exception);
        }
    }
}