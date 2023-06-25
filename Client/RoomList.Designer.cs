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
            SuspendLayout();
            // 
            // captionLabel
            // 
            captionLabel.AutoSize = true;
            captionLabel.BackColor = SystemColors.ActiveCaption;
            captionLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            captionLabel.Location = new Point(30, 9);
            captionLabel.Name = "captionLabel";
            captionLabel.Size = new Size(174, 31);
            captionLabel.TabIndex = 1;
            captionLabel.Text = "Your chat room:";
            // 
            // searchChatRoomBtn
            // 
            searchChatRoomBtn.Location = new Point(584, 147);
            searchChatRoomBtn.Name = "searchChatRoomBtn";
            searchChatRoomBtn.Size = new Size(166, 49);
            searchChatRoomBtn.TabIndex = 2;
            searchChatRoomBtn.Text = "Seach for chat room";
            searchChatRoomBtn.UseVisualStyleBackColor = true;
            searchChatRoomBtn.Click += searchChatRoomBtn_Click;
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(584, 59);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(122, 42);
            logoutBtn.TabIndex = 3;
            logoutBtn.Text = "Logout";
            logoutBtn.UseVisualStyleBackColor = true;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.BackColor = SystemColors.ActiveCaption;
            usernameLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            usernameLabel.Location = new Point(223, 9);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(76, 31);
            usernameLabel.TabIndex = 4;
            usernameLabel.Text = "label1";
            // 
            // roomListView
            // 
            roomListView.Location = new Point(30, 59);
            roomListView.Name = "roomListView";
            roomListView.Size = new Size(500, 217);
            roomListView.TabIndex = 5;
            roomListView.UseCompatibleStateImageBehavior = false;
            roomListView.View = View.Details;
            roomListView.Columns.Add("Id", 100);
            roomListView.Columns.Add("Room's name", 300);
            roomListView.SelectedIndexChanged += roomListView_SelectedIndexChanged;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.Location = new Point(68, 298);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(50, 20);
            errorLabel.TabIndex = 6;
            errorLabel.Text = "label1";
            // 
            // ChatRoomList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 352);
            Controls.Add(errorLabel);
            Controls.Add(roomListView);
            Controls.Add(usernameLabel);
            Controls.Add(logoutBtn);
            Controls.Add(searchChatRoomBtn);
            Controls.Add(captionLabel);
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
    }
}