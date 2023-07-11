namespace Client
{
    partial class ChatRoomList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            captionLabel = new Label();
            searchChatRoomBtn = new Button();
            logoutBtn = new Button();
            usernameLabel = new Label();
            roomListView = new ListView();
            errorLabel = new Label();
            btnUpdateProfile = new Button();
            SuspendLayout();
            // 
            // captionLabel
            // 
            captionLabel.AutoSize = true;
            captionLabel.BackColor = SystemColors.ActiveCaption;
            captionLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            captionLabel.Location = new Point(38, 11);
            captionLabel.Margin = new Padding(4, 0, 4, 0);
            captionLabel.Name = "captionLabel";
            captionLabel.Size = new Size(212, 38);
            captionLabel.TabIndex = 1;
            captionLabel.Text = "Your chat room:";
            // 
            // searchChatRoomBtn
            // 
            searchChatRoomBtn.Location = new Point(730, 184);
            searchChatRoomBtn.Margin = new Padding(4);
            searchChatRoomBtn.Name = "searchChatRoomBtn";
            searchChatRoomBtn.Size = new Size(208, 61);
            searchChatRoomBtn.TabIndex = 2;
            searchChatRoomBtn.Text = "Seach for chat room";
            searchChatRoomBtn.UseVisualStyleBackColor = true;
            searchChatRoomBtn.Click += searchChatRoomBtn_Click;
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(730, 88);
            logoutBtn.Margin = new Padding(4);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(208, 61);
            logoutBtn.TabIndex = 3;
            logoutBtn.Text = "Logout";
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.BackColor = SystemColors.ActiveCaption;
            usernameLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            usernameLabel.Location = new Point(279, 11);
            usernameLabel.Margin = new Padding(4, 0, 4, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(91, 38);
            usernameLabel.TabIndex = 4;
            usernameLabel.Text = "label1";
            // 
            // roomListView
            // 
            roomListView.FullRowSelect = true;
            roomListView.Location = new Point(38, 74);
            roomListView.Margin = new Padding(4);
            roomListView.Name = "roomListView";
            roomListView.Size = new Size(624, 270);
            roomListView.TabIndex = 5;
            roomListView.UseCompatibleStateImageBehavior = false;
            roomListView.View = View.Details;
            roomListView.SelectedIndexChanged += roomListView_SelectedIndexChanged;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Firebrick;
            errorLabel.Location = new Point(47, 377);
            errorLabel.Margin = new Padding(4, 0, 4, 0);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 25);
            errorLabel.TabIndex = 6;
            // 
            // btnUpdateProfile
            // 
            btnUpdateProfile.Location = new Point(730, 293);
            btnUpdateProfile.Name = "btnUpdateProfile";
            btnUpdateProfile.Size = new Size(208, 61);
            btnUpdateProfile.TabIndex = 7;
            btnUpdateProfile.Text = "Update profile";
            btnUpdateProfile.UseVisualStyleBackColor = true;
            btnUpdateProfile.Click += btnUpdateProfile_Click;
            // 
            // ChatRoomList
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 440);
            Controls.Add(btnUpdateProfile);
            Controls.Add(errorLabel);
            Controls.Add(roomListView);
            Controls.Add(usernameLabel);
            Controls.Add(logoutBtn);
            Controls.Add(searchChatRoomBtn);
            Controls.Add(captionLabel);
            Margin = new Padding(4);
            Name = "ChatRoomList";
            Text = "Chat Room List";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label captionLabel;
        private Button searchChatRoomBtn;
        private Button logoutBtn;
        private Label usernameLabel;
        private ListView roomListView;
        private Label errorLabel;
        private Button btnUpdateProfile;
    }
}