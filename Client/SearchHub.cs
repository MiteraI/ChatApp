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
            listViewRooms.Columns.Add("id", 100);
            listViewRooms.Columns.Add("title", 300);
            listViewRooms.Columns.Add("stat", 200);
            listViewRooms.Columns.Add("added?", 200);
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
                            /*Conversation room = new Conversation
                            {
                                Id = conversation["conversationId"].ToString(),
                                Title = conversation["title"].ToString()
                            };
                            ListViewItem item = new ListViewItem(room.Id);
                            item.SubItems.Add(room.Title);
                            item.SubItems.Add("Join");
                            listViewRooms.Items.Add(item);*/
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
                                item.SubItems.Add("public");
                            }
                            else
                            {
                                item.SubItems.Add("private");
                            }
                            if (this.getConversationsToUser.Contains(this.getConversationsToUser.Where(r => r.Id == room.Id).FirstOrDefault()))
                            {
                                item.SubItems.Add("added");
                            }
                            else
                            {
                                item.SubItems.Add("add");
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
                MessageBox.Show("no row has been selected yet");
                return;
            }
            string getAdded = listViewRooms.SelectedItems[0].SubItems[3].Text;
            string getRoomId = listViewRooms.SelectedItems[0].SubItems[0].Text;
            if (getAdded.Equals("added".ToLower().Trim()))
            {
                MessageBox.Show("this has been in your groups");
                return;
            }
            DialogResult result = MessageBox.Show("are you sure want to add this room to your collection", "joinroom ", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (this.getConversationsToUser.Contains(this.getConversationsToUser.Where(r => r.Id == getRoomId).FirstOrDefault()))
                {
                    MessageBox.Show("your have added this room");
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
                            if (response.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Add to your group success");
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
                    HttpResponseMessage response =  client.GetAsync("").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse =  response.Content.ReadAsStringAsync().Result;
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
        private  void loadRoom()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7276/api/Conversations");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response =  client.GetAsync("").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse =  response.Content.ReadAsStringAsync().Result;
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
                                item.SubItems.Add("public");
                            }
                            else
                            {
                                item.SubItems.Add("private");
                            }
                            List<Conversation> count = this.getConversationsToUser.Where(r => r.Id.Trim().Equals(room.Id.Trim())).ToList();
                            if (count.Count == 0)
                            {
                                item.SubItems.Add("add");
                                
                            }
                            else
                            {
                                item.SubItems.Add("added");
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
