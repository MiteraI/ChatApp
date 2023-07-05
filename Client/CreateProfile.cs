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
    public partial class CreateProfile : Form
    {
        private User getUser;
        private Profile getProfile;
        public CreateProfile()
        {
            InitializeComponent();
            this.getUser = SessionManager.loggedInUser;
        }
        public CreateProfile(User user)
        {
            InitializeComponent();

        }

        private void rtxtIntroduction_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                // Set the base URL of your API server
                client.BaseAddress = new Uri("https://localhost:7276/api/Profile/Create");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                JsonObject profileUpdate = new JsonObject();
                profileUpdate["Introduction"] = rtxtIntroduction.Text.ToString();
                try
                {
                    // Send a POST request to the API endpoint
                    HttpResponseMessage response = await client.PostAsJsonAsync("", profileUpdate);

                    // Check the response status code
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("update profile success");
                        string json = await response.Content.ReadAsStringAsync();
                        //User user = JsonConvert.DeserializeObject<User>(json);
                        //SessionManager.loggedInUser = user;
                        ChatRoomList roomList = new ChatRoomList();
                        roomList.Show();
                        this.Hide();
                    }
                    else
                    {
                        //errorLabel.Text = "Login failed. Error: " + response.StatusCode.ToString();
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occurred during the API request
                    //errorLabel.Text = "Login failed. Error: " + ex.Message;
                    // return Task.CompletedTask.Wait();
                }
            }
        }

        private async void btnBack_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtxtIntroduction.Text.Trim())) {
                MessageBox.Show("introduction must not be empty ");
                return;
            }
            ChatRoomList page = new ChatRoomList();
            this.Hide();
            page.Show();
        }
    }
}
