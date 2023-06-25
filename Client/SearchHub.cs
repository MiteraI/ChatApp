﻿using Client.Models;
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

namespace Client
{
    public partial class SearchHub : Form
    {

        public SearchHub()
        {
            InitializeComponent();
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
                            Conversation room = new Conversation
                            {
                                Id = conversation["conversationId"].ToString(),
                                Title = conversation["title"].ToString()
                            };
                            ListViewItem item = new ListViewItem(room.Id);
                            item.SubItems.Add(room.Title);
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
    }
}
