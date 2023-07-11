using Client.Models;
using Newtonsoft.Json;
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
    public partial class RoomPassword : Form
    {
        private string conversationId;
        private string userId;
        private ConversationPassword conversationPassword;
        public RoomPassword(string conversationId, string userId)
        {
            InitializeComponent();
            this.conversationId = conversationId;
            this.userId = userId;
            errorLabel.Visible = false;
            getRoom();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
            string input = txtPassword.Text.Trim();
            if (input.Equals(conversationPassword.password))
            {
                errorLabel.Visible = false;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri($"https://localhost:7276/api/GroupMember/private");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    try
                    {
                        JsonObject addGroup = new JsonObject();
                        addGroup["ConversationId"] = conversationId;
                        addGroup["UserId"] = SessionManager.loggedInUser.UserId;
                        HttpResponseMessage response = await client.PostAsJsonAsync("", addGroup);
                        if (response.IsSuccessStatusCode) 
                        {
                            this.Hide();
                            ChatRoomList chatRoomList = new ChatRoomList();
                            chatRoomList.Show();
                        } else
                        {
                            MessageBox.Show("Server problem", "Server problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnSend.Enabled = true;
                        }

                    } catch (Exception ex)
                    {
                        errorLabel.Text = ex.Message;
                        btnSend.Enabled = true;
                    }
                }
            }
            else
            {
                errorLabel.Text = "Incorrect password";
                errorLabel.Visible = true;
                //MessageBox.Show("pwd unmatch");
            }
        }
        private async void getRoom()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:7276/api/Conversations/{conversationId}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = await client.GetAsync("");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        JsonObject conversations = (JsonObject)JsonNode.Parse(jsonResponse);
                        //MessageBox.Show("Login successful!");
                        string json = await response.Content.ReadAsStringAsync();
                        ConversationPassword conversation = JsonConvert.DeserializeObject<ConversationPassword>(json);
                        if (conversation is not null)
                        {
                            this.conversationPassword = conversation;
                        }
                        else
                        {
                            MessageBox.Show("Conversation is null");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error");

                        errorLabel.Text = "Error" + response.StatusCode.ToString();
                    }
                   
                }
                catch (HttpRequestException ex)
                {
                    errorLabel.Text = "Error" + ex.Message;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            ChatRoomList chatRoomList = new ChatRoomList();
            chatRoomList.Show();
        }
    }
}
