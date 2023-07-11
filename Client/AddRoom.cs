using Client.Models;
using Newtonsoft.Json.Linq;
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
    public partial class AddRoom : Form
    {
        private string? selectedStatus;
        private User? getSessionUser;
        public AddRoom()
        {
            InitializeComponent();
            this.getSessionUser = SessionManager.loggedInUser;
            radioPrivate.CheckedChanged += AllCheckBoxes_CheckedChanged;
            radioPublic.CheckedChanged += AllCheckBoxes_CheckedChanged;
            radioPublic.Checked = true;
            this.selectedStatus = radioPublic.Text.ToLower().Trim();
        }



        private async void btnSave_Click(object sender, EventArgs e)
        {
            string getStatus = this.selectedStatus;
            string title = txtTitle.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(getStatus) || string.IsNullOrEmpty(title))
            {
                MessageBox.Show("please enter all field");
                return;
            }
            if (getStatus.Trim().ToLower().Equals("private") && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("private room must have pass");
                return;
            }
            ConversationPassword conversationPassword;
            switch (getStatus.ToLower().Trim())
            {
                case "private":
                    conversationPassword =
                       new ConversationPassword
                       {
                           Title = title,
                           password = password
                       };
                    break;
                case "public":
                    conversationPassword =
                        new ConversationPassword
                        {
                            Title = title
                        };
                    break;
                default:
                    MessageBox.Show("status is invalid");
                    return;
            }
            string getResult = await postConversationRoom(conversationPassword);
            if (string.IsNullOrEmpty(getResult))
            {
                MessageBox.Show("erorr happen in adding rooms");
                return;
            }
            Groups group = new Groups { ConversationId = int.Parse(getResult.Trim()), UserId = int.Parse(this.getSessionUser.UserId.Trim()) };
            Groups getResultGroup = await postGroupMembers(group);
            if (getResultGroup is null)
            {
                MessageBox.Show("Error happen in saving groups");
                return;
            }
            MessageBox.Show("Success all");
            SearchHub searchHub = new SearchHub();
            this.Close();
            searchHub.Show();

        }

        private void AllCheckBoxes_CheckedChanged(Object sender, EventArgs e)
        {
            // Check of the raiser of the event is a checked Checkbox.
            // Of course we also need to to cast it first.
            if (((RadioButton)sender).Checked)
            {
                // This is the correct control.
                RadioButton rb = (RadioButton)sender;
                string getName = rb.Text.ToLower().Trim();
                this.selectedStatus = getName;
                rb.Checked = true;
            }
        }
        private async Task<string> postConversationRoom(ConversationPassword conversationPassword)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:7276/api/Conversations");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonObject addConversationRoom = new JsonObject();
                addConversationRoom["Title"] = conversationPassword.Title;
                addConversationRoom["Password"] = conversationPassword.password;
                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync("", addConversationRoom);
                    Debug.WriteLine(response.Content);
                    // Check the response status code
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        JObject jsonObject = JObject.Parse(responseBody);
                        string conversationId = (string)jsonObject["conversationId"];
                        MessageBox.Show("Add room success");
                        return conversationId;
                    }
                    else
                    {
                        MessageBox.Show("Error: " + response.StatusCode);
                    }
                    return null;
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }

        }
        private async Task<Groups> postGroupMembers(Groups Groups)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:7276/api/GroupMember");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonObject addGroup = new JsonObject();
                //addGroup["ConversationId"] = getRoomId;
                addGroup["UserId"] = Groups.UserId;
                addGroup["ConversationId"] = Groups.ConversationId;
                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync("", addGroup);
                    Debug.WriteLine(response.Content);
                    // Check the response status code
                    if (response.IsSuccessStatusCode)
                    {
                        string getResponse = await response.Content.ReadAsStringAsync();
                        JObject jsonObject = JObject.Parse(getResponse);
                        string conversationId = (string)jsonObject["conversationId"];
                        string userId = (string)jsonObject["userId"];
                        Groups group = new Groups { ConversationId = int.Parse(conversationId), UserId = int.Parse(userId) };
                        MessageBox.Show("Add group success");
                        //int parsedId = int.Parse(conversationId.Trim());
                        return group;
                    }
                    else
                    {
                        MessageBox.Show("Error: " + response.StatusCode);
                    }
                    return null;
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }

        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            SearchHub page = new SearchHub();
            this.Close();
            page.Show();
        }
    }
}
