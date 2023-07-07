using Client.Models;
using Newtonsoft.Json;
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
    public partial class RoomPassword : Form
    {
        private Conversation Conversation;
        private ConversationPassword conversationPassword;
        private string conversationID;
        private ChatRoomList thePreviousRoom;
        public RoomPassword(Conversation conversation, ChatRoomList previousRoom)
        {
            InitializeComponent();
            this.thePreviousRoom = previousRoom;
            lblRoomTitle.Text = conversation.Title;
            errorLabel.Visible = false;
            this.conversationID = conversation.Id;
            this.Conversation = conversation;
            getRoom();

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string input = txtPassword.Text.Trim();
            if (input.Equals(conversationPassword.password))
            {
                //MessageBox.Show("match");
                errorLabel.Visible = false;
                Conversation conversationMatch = new Conversation { Id = conversationPassword.Id, Title = conversationPassword.Title };
                ChatRoom chatRoom = new ChatRoom(this.Conversation);
                this.Close();
                chatRoom.Show();
            }
            else
            {
                errorLabel.Text = "pwd unmatch";
                errorLabel.Visible = true;
                //MessageBox.Show("pwd unmatch");
            }
        }
        private async void getRoom()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:7276/api/Conversations/{conversationID}");
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
                            MessageBox.Show("conversation is null");
                        }


                        // Process the retrieved users as needed

                    }
                    else
                    {
                        MessageBox.Show("Error");

                        errorLabel.Text = "Error" + response.StatusCode.ToString();
                    }
                    if (conversationPassword.password is null)
                    {
                        ChatRoom chatRoom = new ChatRoom(this.Conversation);
                        this.Close();
                        chatRoom.Show();
                    }

                }
                catch (HttpRequestException ex)
                {
                    errorLabel.Text = "Error" + ex.Message;
                }
            }
        }

        private void errorLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            thePreviousRoom.Show();
        }

        private void RoomPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
