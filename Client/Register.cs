using Microsoft.VisualBasic.ApplicationServices;
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

namespace Client
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            lblError.Visible = false;
        }

        private async void registerBtn_Click(object sender, EventArgs e)
        {
            registerBtn.Enabled = false;
            if (string.IsNullOrEmpty(usernameTxb.Text.ToString().Trim()) || string.IsNullOrEmpty(passwordTxb.Text.ToString().Trim()))
            {
                lblError.Text = "Enter all fields";
                lblError.Visible = true;
                registerBtn.Enabled = true;
                return;
            }
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7276/api/register");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JsonObject newUser = new JsonObject();
                newUser["Name"] = usernameTxb.Text.ToString();
                newUser["Password"] = passwordTxb.Text.ToString();
                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync("", newUser);

                    // Check the response status code
                    if (response.IsSuccessStatusCode)
                    {
                        // User registration successful

                        string getResponse = await response.Content.ReadAsStringAsync();
                        JObject getJsonBody = JObject.Parse(getResponse);
                        string userId = (string)getJsonBody["userId"];
                        lblError.Visible = false;
                        MessageBox.Show("Registration successful!");
                        CreateProfile(userId, "");
                        Login login = new Login();
                        this.Hide();
                        login.Show();
                    }
                    else
                    {
                        // Error occurred during registration
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        lblError.Text = errorMessage;
                        lblError.Visible = true;
                        registerBtn.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occurred during the API request
                    lblError.Text = ex.Message;
                    lblError.Visible = true;
                }
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void usernameTxb_TextChanged(object sender, EventArgs e)
        {

        }
        private void CreateProfile(string userId, string introduction)
        {
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

        private void lblError_Click(object sender, EventArgs e)
        {

        }
    }
}
