using Client.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using Message = Client.Models.Message;

namespace Client
{
    public partial class ChatRoom : Form
    {
        Conversation _conversation;
        HubConnection hubConnection;
        public ChatRoom(Conversation conversation)
        {
            InitializeComponent();
            _conversation = conversation;
            roomnameLabel.Text = conversation.Title;
            loadMessageFromDb();
            openChatHub();
        }

        private async void sendBtn_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                // Set the base URL of your API server
                client.BaseAddress = new Uri("https://localhost:7276/api/Messages");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Initialize a message
                JsonObject newMessage = new JsonObject();
                newMessage["datetime"] = DateTime.Now;
                newMessage["messageContent"] = msgTxb.Text.Trim();
                newMessage["conversationId"] = _conversation.Id;
                newMessage["userId"] = SessionManager.loggedInUser.UserId;
                msgTxb.Clear();
                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync("", newMessage);

                    // Check the response status code
                    if (response.IsSuccessStatusCode)
                    {
                        msgStatusLabel.Text = "Message success: " + response.StatusCode;
                    }
                    else
                    {
                        MessageBox.Show("Message failed. Error: " + response.StatusCode);
                        msgStatusLabel.Text = "Message failed. Error: " + response.StatusCode;
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occurred during the API request
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChatRoomList chatRoomList = new ChatRoomList();
            chatRoomList.Show();
            this.Hide();
        }

        private async void loadMessageFromDb()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7276/api/Messages/conversation/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync($"{_conversation.Id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        JsonArray messages = (JsonArray)JsonNode.Parse(jsonResponse);
                        chatListView.Items.Clear();

                        // Process the retrieved users as needed
                        foreach (JsonObject message in messages)
                        {
                            Message itemMessage = new Message
                            {
                                Username = message["user"]["name"].ToString(),
                                messageContent = message["messageContent"].ToString(),
                                datetime = DateTime.Parse(message["dateTime"].ToString()),
                                UserId = message["userId"].ToString(),
                                ConversationId = message["conversationId"].ToString()
                            };
                            ListViewItem item = new ListViewItem(itemMessage.Username);
                            item.SubItems.Add(itemMessage.messageContent);
                            item.SubItems.Add(itemMessage.datetime.ToString());
                            chatListView.Items.Add(item);

                        }
                    }
                    else
                    {
                        msgStatusLabel.Text = "Error" + response.StatusCode.ToString();
                    }
                }
                catch (HttpRequestException ex)
                {
                    msgStatusLabel.Text = "Error" + ex.Message;
                }
            }
        }
        private async void openChatHub()
        {
            try
            {
                //This will call the OnConnectAsync of the ChatHub
                var hubConnection = new HubConnectionBuilder()
                    .WithUrl("https://localhost:7276/chathub", options =>
                    {
                        options.Headers["room"] = _conversation.Id; // room / conversationId
                    })
                    .Build();

                // Handle the "ReceiveMessage" event
                hubConnection.On<string,string,string>("ReceiveMessage", (messageContent, username, datetime) =>
                {  
                    ListViewItem item = new ListViewItem(username);
                    item.SubItems.Add(messageContent);
                    item.SubItems.Add(datetime);
                    chatListView.Items.Add(item);
                });

                // Start the connection
                await hubConnection.StartAsync();

            }
            catch (Exception ex)
            {
                msgStatusLabel.Text += ex.Message;
            }
        }
    }
}
