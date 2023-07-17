using Client.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json.Linq;
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
using System.Diagnostics;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            chatListView.Columns.Add("Message", 600);
            chatListView.Columns.Add("Time", 250);
            loadMessageFromDb();
            openChatHub();
            //MessageBox.Show(hubConnection.ConnectionId);
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
                        chatListView.TopItem = chatListView.Items[chatListView.Items.Count - 1];
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
                            ListViewItem item = new ListViewItem(itemMessage.Username + ": " + itemMessage.messageContent);
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
                hubConnection.On<string, string, string>("ReceiveMessage", (messageContent, username, datetime) =>
                {
                    ListViewItem item = new ListViewItem(username + ": " + messageContent);
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

        private void chatListView_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (chatListView.SelectedItems.Count <= 0)
            {
                //MessageBox.Show("chatListEmpty");
                return;
            }
            else
            {
                ListViewItem selectedItem = chatListView.SelectedItems[0];
                string getUsername = selectedItem.SubItems[0].Text.Trim().Split(":")[0];
                Debug.WriteLine("pass getUserId");
                ShowProfile page = new ShowProfile(getUsername);
                page.ShowDialog();
                //page.Show();
            }
        }
        private string GetUserId(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            using (HttpClient client = new HttpClient())
            {
                // Set the base URL of your API server
                client.BaseAddress = new Uri($"https://localhost:7276/api/Users/search/{username.Trim()}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = client.GetAsync("").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        User user = JsonConvert.DeserializeObject<User>(responseBody);
                        //JObject json = JObject.Parse(responseBody);
                        //string getUserId = (string)json["userId"];
                        //return getUserId;
                        return user.UserId;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occurred during the API request
                    return null;
                }
            }
        }

        private void msgTxb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendBtn_Click(sender, e);
            }
        }
    }
}
