using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FriendList : Form
    {
        public FriendList()
        {
            InitializeComponent();
        }

        private void searchFriendBtn_Click(object sender, EventArgs e)
        {
            SearchHub searchHub = new SearchHub();
            searchHub.Show();
            this.Hide();
        }
    }
}
