using Client.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class UpdateProfile : Form
    {
        private User getUser;
        private Profile getProfile;
        public UpdateProfile()
        {
            InitializeComponent();
            this.getUser = SessionManager.loggedInUser;
            bool result = GetProfileByUserId(int.Parse(getUser.UserId));
        }
        public UpdateProfile(User user)
        {
            InitializeComponent();
            bool result = GetProfileByUserId(int.Parse(user.UserId));

        }

        private void rtxtIntroduction_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string getIntroduction = rtxtIntroduction.Text.ToString();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:7276/api/Profile/Save/{getUser.UserId}/{getIntroduction}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = await client.GetAsync("");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("update profile success");
                        string json = await response.Content.ReadAsStringAsync();
                        ChatRoomList roomList = new ChatRoomList();
                        roomList.Show();
                        this.Hide();
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        MessageBox.Show("not found profile for this account, new one will be created");
                        getIntroduction = "";
                        CreateProfileIfNotFound(getUser.UserId, getIntroduction);
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
        private bool GetProfileByUserId(int userId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:7276/api/Profile/get/{getUser.UserId}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = client.GetAsync("").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string json = response.Content.ReadAsStringAsync().Result;
                        JObject jsonObject = JObject.Parse(json);
                        string introduction = (string)jsonObject["introduction"];
                        rtxtIntroduction.Text = introduction.Trim();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("cant get profile for this user");
                        rtxtIntroduction.Text = "not found profiles";
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error parsing json");
                    rtxtIntroduction.Text = "ERROR";
                    return false;
                }
            }
        }

        private async void btnBack_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtxtIntroduction.Text.Trim()))
            {
                MessageBox.Show("introduction must not be empty ");
                return;
            }
            ChatRoomList page = new ChatRoomList();
            this.Close();
            page.Show();
        }
        private void CreateProfileIfNotFound(string userId, string introduction)
        {
            string getIntroduction = rtxtIntroduction.Text.ToString();
            Dictionary<string, string> fields = new Dictionary<string, string>
                        {
                            { "userId", userId },
                            { "introduction", introduction },
                        };

            string requestBody = Newtonsoft.Json.JsonConvert.SerializeObject(fields);
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:7276/api/Profile/create");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = client.PostAsync("", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("create profile success");
                        string json = response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        MessageBox.Show("cant create");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("exception in client");
                }
            }
        }



    }


}
