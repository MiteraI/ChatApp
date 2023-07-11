using Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ChatRoomList : Form
    {
        public ChatRoomList()
        {
            InitializeComponent();
            usernameLabel.Text = SessionManager.loggedInUser.Name;
            getRoomList();
            roomListView.Columns.Add("Id", 100);
            roomListView.Columns.Add("Room's name", 300);
            roomListView.Columns.Add("button", 100);
        }
        private async void getRoomList()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:7276/api/GroupMember/{SessionManager.loggedInUser.UserId}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = await client.GetAsync("");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        JsonArray conversations = (JsonArray)JsonNode.Parse(jsonResponse);
                        roomListView.Items.Clear();

                        // Process the retrieved users as needed
                        foreach (JsonObject conversation in conversations)
                        {
                            Conversation room = new Conversation
                            {
                                Id = conversation["conversationId"].ToString(),
                                Title = conversation["title"].ToString()
                            };
                            ListViewItem item = new ListViewItem(room.Id);
                            item.SubItems.Add(room.Title);
                            item.SubItems.Add("button");
                            roomListView.Items.Add(item);
                        }
                    }
                    else
                    {
                        errorLabel.Text = "Error" + response.StatusCode.ToString();
                    }
                }
                catch (HttpRequestException ex)
                {
                    errorLabel.Text = "Error" + ex.Message;
                }
            }
        }
        private void searchChatRoomBtn_Click(object sender, EventArgs e)
        {
            SearchHub searchHub = new SearchHub();
            searchHub.Show();
            this.Hide();
        }

        private void roomListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (roomListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = roomListView.SelectedItems[0];
                Conversation conversation = new Conversation
                {
                    Id = selectedItem.SubItems[0].Text,
                    Title = selectedItem.SubItems[1].Text
                };
                ChatRoom chatRoom = new ChatRoom(conversation);
                chatRoom.Show();
                this.Hide();
            }
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            UpdateProfile page = new UpdateProfile();
            this.Hide();
            page.Show();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            SessionManager.loggedInUser = null;
            Login page = new Login();
            this.Close();
            page.Show();
        }
    }
}
