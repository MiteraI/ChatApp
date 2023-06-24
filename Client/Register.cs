using Microsoft.VisualBasic.ApplicationServices;
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
        }

        private async void registerBtn_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                // Set the base URL of your API server
                client.BaseAddress = new Uri("https://localhost:7276/api/register");

                // Set the content type of the request body
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Create a new User object with the registration data
                JsonObject newUser = new JsonObject();
                newUser["Name"] = usernameTxb.Text.ToString();
                newUser["Password"] = passwordTxb.Text.ToString();
                newUser["Groups"] = new JsonArray();
                newUser["Messages"] = new JsonArray();
                try
                {
                    // Send a POST request to the API endpoint
                    HttpResponseMessage response = await client.PostAsJsonAsync("", newUser);

                    // Check the response status code
                    if (response.IsSuccessStatusCode)
                    {
                        // User registration successful
                        MessageBox.Show("Registration successful!");
                        Login login = new Login();
                        this.Hide();
                        login.Show();
                    }
                    else
                    {
                        // Error occurred during registration
                        MessageBox.Show("Registration failed. Error: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occurred during the API request
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
