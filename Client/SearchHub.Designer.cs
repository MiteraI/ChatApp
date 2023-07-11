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
            btnAddRoom = new Button();
            SuspendLayout();
            // 
            // searchTxtBox
            // 
            searchTxtBox.Location = new Point(391, 55);
            searchTxtBox.Margin = new Padding(4);
            searchTxtBox.Name = "searchTxtBox";
            searchTxtBox.Size = new Size(439, 31);
            searchTxtBox.TabIndex = 0;
            searchTxtBox.TextChanged += searchTxtBox_TextChanged;
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.BackColor = SystemColors.ActiveCaption;
            searchLabel.Location = new Point(140, 59);
            searchLabel.Margin = new Padding(4, 0, 4, 0);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(212, 25);
            searchLabel.TabIndex = 1;
            searchLabel.Text = "Type to search for room: ";
            // 
            // searchLinkLabel
            // 
            searchLinkLabel.AutoSize = true;
            searchLinkLabel.ForeColor = Color.Fuchsia;
            searchLinkLabel.Location = new Point(192, 101);
            searchLinkLabel.Margin = new Padding(4, 0, 4, 0);
            searchLinkLabel.Name = "searchLinkLabel";
            searchLinkLabel.Size = new Size(0, 25);
            searchLinkLabel.TabIndex = 3;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Firebrick;
            errorLabel.Location = new Point(366, 449);
            errorLabel.Margin = new Padding(4, 0, 4, 0);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 25);
            errorLabel.TabIndex = 4;
            // 
            // backToFriendListBtn
            // 
            backToFriendListBtn.Location = new Point(636, 441);
            backToFriendListBtn.Margin = new Padding(4);
            backToFriendListBtn.Name = "backToFriendListBtn";
            backToFriendListBtn.Size = new Size(190, 41);
            backToFriendListBtn.TabIndex = 5;
            backToFriendListBtn.Text = "Go to your chat list";
            backToFriendListBtn.UseVisualStyleBackColor = true;
            backToFriendListBtn.Click += backToFriendListBtn_Click;
            // 
            // listViewRooms
            // 
            listViewRooms.FullRowSelect = true;
            listViewRooms.Location = new Point(148, 130);
            listViewRooms.Margin = new Padding(4);
            listViewRooms.Name = "listViewRooms";
            listViewRooms.Size = new Size(679, 282);
            listViewRooms.TabIndex = 6;
            listViewRooms.UseCompatibleStateImageBehavior = false;
            listViewRooms.View = View.Details;
            listViewRooms.SelectedIndexChanged += listViewRooms_SelectedIndexChanged;
            // 
            // btnAddRoom
            // 
            btnAddRoom.Location = new Point(148, 448);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(192, 34);
            btnAddRoom.TabIndex = 7;
            btnAddRoom.Text = "Create room";
            btnAddRoom.UseVisualStyleBackColor = true;
            btnAddRoom.Click += btnAddRoom_Click;
            // 
            // SearchHub
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(btnAddRoom);
            Controls.Add(listViewRooms);
            Controls.Add(backToFriendListBtn);
            Controls.Add(errorLabel);
            Controls.Add(searchLinkLabel);
            Controls.Add(searchLabel);
            Controls.Add(searchTxtBox);
            Margin = new Padding(4);
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
        private Button btnAddRoom;
    }
}