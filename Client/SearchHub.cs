using Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class SearchHub : Form
    {
        private List<Conversation> getConversationsToUser = new List<Conversation>();
        public SearchHub()
        {
            InitializeComponent();
            listViewRooms.Columns.Add("Id", 100);
            listViewRooms.Columns.Add("Room's name", 300);
            listViewRooms.Columns.Add("Visibility", 200);
            listViewRooms.Columns.Add("Join?", 200);
            loadGroups();
            loadRoom();
        }

        private async void searchTxtBox_TextChanged(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7276/api/Conversations/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string searchName = searchTxtBox.Text.Trim();
                string encodedSearchName = Uri.EscapeDataString(searchName); // URL-encode the search query
                searchLinkLabel.Text = client.BaseAddress + encodedSearchName;
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"search?query={encodedSearchName}");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        JsonArray conversations = (JsonArray)JsonNode.Parse(jsonResponse);
                        listViewRooms.Items.Clear();
                        // Process the retrieved users as needed
                        foreach (JsonObject conversation in conversations)
                        {
                            ConversationPassword room = new ConversationPassword
                            {
                                Id = conversation["conversationId"].ToString(),
                                Title = conversation["title"].ToString()
                            };

                            ListViewItem item = new ListViewItem(room.Id);
                            item.SubItems.Add(room.Title);
                            //item.SubItems.Add("Join");
                            if (conversation["password"] is null || string.IsNullOrEmpty((string?)conversation["password"]))
                            {
                                item.SubItems.Add("Public");
                            }
                            else
                            {
                                item.SubItems.Add("Private");
                            }
                            if (this.getConversationsToUser.Contains(this.getConversationsToUser.Where(r => r.Id == room.Id).FirstOrDefault()))
                            {
                                item.SubItems.Add("Added");
                            }
                            else
                            {
                                item.SubItems.Add("Add");
                            }
                            listViewRooms.Items.Add(item);

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

        private void backToFriendListBtn_Click(object sender, EventArgs e)
        {
            ChatRoomList friendList = new ChatRoomList();
            friendList.Show();
            this.Hide();
        }

        private async void listViewRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewRooms.SelectedItems.Count <= 0)
            {
                MessageBox.Show("No row has been selected yet");
                return;
            }
            string getAdded = listViewRooms.SelectedItems[0].SubItems[3].Text;
            string getRoomId = listViewRooms.SelectedItems[0].SubItems[0].Text;
            if (getAdded.Equals("Added".ToLower().Trim()))
            {
                MessageBox.Show("Room has already been added to you list");
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure want to add this room to your collection", "Join room ", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (this.getConversationsToUser.Contains(this.getConversationsToUser.Where(r => r.Id == getRoomId).FirstOrDefault()))
                {
                    MessageBox.Show("Room has already been added to you list");
                    return;
                }
                else
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri($"https://localhost:7276/api/GroupMember");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        JsonObject addGroup = new JsonObject();
                        addGroup["ConversationId"] = getRoomId;
                        addGroup["UserId"] = SessionManager.loggedInUser.UserId;
                        try
                        {
                            HttpResponseMessage response = await client.PostAsJsonAsync("", addGroup);
                            Debug.WriteLine(response.Content);
                            // Check the response status code
                            if ((int)response.StatusCode == 200)
                            {
                                MessageBox.Show("Added room to your group list");
                            }
                            else if ((int)response.StatusCode == 202)
                            {
                                MessageBox.Show("This is a private room, you will have to enter password to join", "Private Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                RoomPassword roomPassword = new RoomPassword(getRoomId, SessionManager.loggedInUser.UserId);
                                roomPassword.Show();
                            }
                            else
                            {
                                MessageBox.Show("Error: " + response.StatusCode);
                            }
                        }
                        catch (HttpRequestException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                return;
            }
            else
            {
                return;
            }
            //MessageBox.Show(getAdded + listViewRooms.SelectedItems[0].SubItems[0].Text);
        }
        private void loadGroups()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:7276/api/GroupMember/{SessionManager.loggedInUser.UserId}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = client.GetAsync("").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;
                        JsonArray conversations = (JsonArray)JsonNode.Parse(jsonResponse);


                        // Process the retrieved users as needed
                        foreach (JsonObject conversation in conversations)
                        {
                            Conversation room = new Conversation
                            {
                                Id = conversation["conversationId"].ToString(),
                                Title = conversation["title"].ToString()
                            };
                            this.getConversationsToUser.Add(room);
                        }
                        //MessageBox.Show(this.getConversationsToUser.Count.ToString());
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
        private void loadRoom()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7276/api/Conversations");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = client.GetAsync("").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;
                        JsonArray conversations = (JsonArray)JsonNode.Parse(jsonResponse);
                        listViewRooms.Items.Clear();
                        foreach (JsonObject conversation in conversations)
                        {

                            ConversationPassword room = new ConversationPassword
                            {
                                Id = conversation["conversationId"].ToString(),
                                Title = conversation["title"].ToString()
                            };

                            ListViewItem item = new ListViewItem(room.Id);
                            item.SubItems.Add(room.Title);
                            //item.SubItems.Add("Join");
                            if (conversation["password"] is null || string.IsNullOrEmpty((string?)conversation["password"]))
                            {
                                item.SubItems.Add("Public");
                            }
                            else
                            {
                                item.SubItems.Add("Private");
                            }
                            List<Conversation> count = this.getConversationsToUser.Where(r => r.Id.Trim().Equals(room.Id.Trim())).ToList();
                            if (count.Count == 0)
                            {
                                item.SubItems.Add("Add");
                            }
                            else
                            {
                                item.SubItems.Add("Added");
                            }
                            listViewRooms.Items.Add(item);

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

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            AddRoom page = new AddRoom();
            this.Hide();
            page.Show();
        }
    }
}
