namespace Client
{
    partial class FriendList
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
            friendListBox = new ListBox();
            captionLabel = new Label();
            searchFriendBtn = new Button();
            logoutBtn = new Button();
            SuspendLayout();
            // 
            // friendListBox
            // 
            friendListBox.FormattingEnabled = true;
            friendListBox.ItemHeight = 20;
            friendListBox.Location = new Point(30, 59);
            friendListBox.Name = "friendListBox";
            friendListBox.Size = new Size(496, 224);
            friendListBox.TabIndex = 0;
            // 
            // captionLabel
            // 
            captionLabel.AutoSize = true;
            captionLabel.BackColor = SystemColors.ActiveCaption;
            captionLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            captionLabel.Location = new Point(30, 9);
            captionLabel.Name = "captionLabel";
            captionLabel.Size = new Size(140, 31);
            captionLabel.TabIndex = 1;
            captionLabel.Text = "Your friends:";
            // 
            // searchFriendBtn
            // 
            searchFriendBtn.Location = new Point(584, 147);
            searchFriendBtn.Name = "searchFriendBtn";
            searchFriendBtn.Size = new Size(133, 42);
            searchFriendBtn.TabIndex = 2;
            searchFriendBtn.Text = "Seach for friend";
            searchFriendBtn.UseVisualStyleBackColor = true;
            searchFriendBtn.Click += searchFriendBtn_Click;
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
            // FriendList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 352);
            Controls.Add(logoutBtn);
            Controls.Add(searchFriendBtn);
            Controls.Add(captionLabel);
            Controls.Add(friendListBox);
            Name = "FriendList";
            Text = "FriendList";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox friendListBox;
        private Label captionLabel;
        private Button searchFriendBtn;
        private Button logoutBtn;
    }
}