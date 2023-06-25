namespace Client
{
    partial class SearchHub
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
            searchTxtBox = new TextBox();
            searchLabel = new Label();
            searchLinkLabel = new Label();
            errorLabel = new Label();
            backToFriendListBtn = new Button();
            listViewRooms = new ListView();
            SuspendLayout();
            // 
            // searchTxtBox
            // 
            searchTxtBox.Location = new Point(313, 44);
            searchTxtBox.Name = "searchTxtBox";
            searchTxtBox.Size = new Size(352, 27);
            searchTxtBox.TabIndex = 0;
            searchTxtBox.TextChanged += searchTxtBox_TextChanged;
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.BackColor = SystemColors.ActiveCaption;
            searchLabel.Location = new Point(112, 47);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(174, 20);
            searchLabel.TabIndex = 1;
            searchLabel.Text = "Type to search for room: ";
            // 
            // searchLinkLabel
            // 
            searchLinkLabel.AutoSize = true;
            searchLinkLabel.ForeColor = Color.Fuchsia;
            searchLinkLabel.Location = new Point(154, 81);
            searchLinkLabel.Name = "searchLinkLabel";
            searchLinkLabel.Size = new Size(0, 20);
            searchLinkLabel.TabIndex = 3;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Firebrick;
            errorLabel.Location = new Point(293, 359);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 20);
            errorLabel.TabIndex = 4;
            // 
            // backToFriendListBtn
            // 
            backToFriendListBtn.Location = new Point(509, 353);
            backToFriendListBtn.Name = "backToFriendListBtn";
            backToFriendListBtn.Size = new Size(152, 33);
            backToFriendListBtn.TabIndex = 5;
            backToFriendListBtn.Text = "Go to friend list";
            backToFriendListBtn.UseVisualStyleBackColor = true;
            backToFriendListBtn.Click += backToFriendListBtn_Click;
            // 
            // listViewRooms
            // 
            listViewRooms.Location = new Point(118, 104);
            listViewRooms.Name = "listViewRooms";
            listViewRooms.Size = new Size(544, 201);
            listViewRooms.TabIndex = 6;
            listViewRooms.UseCompatibleStateImageBehavior = false;
            listViewRooms.View = View.Details;
            listViewRooms.Columns.Add("Id", 50);
            listViewRooms.Columns.Add("Room's title", 150);
            // 
            // SearchHub
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listViewRooms);
            Controls.Add(backToFriendListBtn);
            Controls.Add(errorLabel);
            Controls.Add(searchLinkLabel);
            Controls.Add(searchLabel);
            Controls.Add(searchTxtBox);
            Name = "SearchHub";
            Text = "SearchHub";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox searchTxtBox;
        private Label searchLabel;
        private Label searchLinkLabel;
        private Label errorLabel;
        private Button backToFriendListBtn;
        private ListView listViewRooms;
    }
}