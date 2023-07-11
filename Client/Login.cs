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
using System.Diagnostics;
namespace Client
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            this.Hide();
            register.Show();
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            loginBtn.Enabled = false;
            using (HttpClient client = new HttpClient())
            {
                // Set the base URL of your API server
                client.BaseAddress = new Uri("https://localhost:7276/api/login");

                // Set the content type of the request body
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Create a new User object with the registration data
                JsonObject loginUser = new JsonObject();
                loginUser["Name"] = usernameTxb.Text.ToString();
                loginUser["Password"] = passwordTxb.Text.ToString();
                Debug.WriteLine(loginUser);
                try
                {
                    // Send a POST request to the API endpoint
                    HttpResponseMessage response = await client.PostAsJsonAsync("", loginUser);

                    // Check the response status code
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Login successful!");
                        string json = await response.Content.ReadAsStringAsync();
                        User user = JsonConvert.DeserializeObject<User>(json);
                        SessionManager.loggedInUser = user;
                        ChatRoomList roomList = new ChatRoomList();
                        roomList.Show();
                        this.Hide();
                    }
                    else
                    {
                        errorLabel.Text = "Login failed. Error: " + response.StatusCode.ToString();
                        loginBtn.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occurred during the API request
                    errorLabel.Text = "Login failed. Error: " + ex.Message;
                    loginBtn.Enabled = true;

                }
            }
        }

        private void passwordTxb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginBtn_Click(sender, e);
            }
        }
    }
}
