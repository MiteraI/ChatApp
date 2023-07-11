namespace Client
{
    partial class ChatRoom
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
            roomnameLabel = new Label();
            chatListView = new ListView();
            msgTxb = new TextBox();
            sendBtn = new Button();
            button1 = new Button();
            msgStatusLabel = new Label();
            SuspendLayout();
            // 
            // captionLabel
            // 
            captionLabel.AutoSize = true;
            captionLabel.BackColor = SystemColors.ActiveCaption;
            captionLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            captionLabel.Location = new Point(51, 29);
            captionLabel.Margin = new Padding(4, 0, 4, 0);
            captionLabel.Name = "captionLabel";
            captionLabel.Size = new Size(198, 38);
            captionLabel.TabIndex = 0;
            captionLabel.Text = "Room's name: ";
            // 
            // roomnameLabel
            // 
            roomnameLabel.AutoSize = true;
            roomnameLabel.BackColor = SystemColors.ActiveCaption;
            roomnameLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            roomnameLabel.Location = new Point(261, 29);
            roomnameLabel.Margin = new Padding(4, 0, 4, 0);
            roomnameLabel.Name = "roomnameLabel";
            roomnameLabel.Size = new Size(91, 38);
            roomnameLabel.TabIndex = 1;
            roomnameLabel.Text = "label2";
            // 
            // chatListView
            // 
            chatListView.FullRowSelect = true;
            chatListView.Location = new Point(50, 93);
            chatListView.Margin = new Padding(4);
            chatListView.Name = "chatListView";
            chatListView.Size = new Size(828, 365);
            chatListView.TabIndex = 2;
            chatListView.UseCompatibleStateImageBehavior = false;
            chatListView.View = View.Details;
            chatListView.SelectedIndexChanged += chatListView_SelectedIndexChanged;
            // 
            // msgTxb
            // 
            msgTxb.Location = new Point(51, 481);
            msgTxb.Margin = new Padding(4);
            msgTxb.Name = "msgTxb";
            msgTxb.Size = new Size(631, 31);
            msgTxb.TabIndex = 3;
            msgTxb.KeyDown += msgTxb_KeyDown;
            // 
            // sendBtn
            // 
            sendBtn.Location = new Point(762, 477);
            sendBtn.Margin = new Padding(4);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(116, 39);
            sendBtn.TabIndex = 4;
            sendBtn.Text = "Send";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += sendBtn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(659, 29);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(219, 41);
            button1.TabIndex = 5;
            button1.Text = "Return to Room List";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // msgStatusLabel
            // 
            msgStatusLabel.AutoSize = true;
            msgStatusLabel.ForeColor = Color.Aqua;
            msgStatusLabel.Location = new Point(50, 531);
            msgStatusLabel.Margin = new Padding(4, 0, 4, 0);
            msgStatusLabel.Name = "msgStatusLabel";
            msgStatusLabel.Size = new Size(95, 25);
            msgStatusLabel.TabIndex = 6;
            msgStatusLabel.Text = "MsgStatus";
            // 
            // ChatRoom
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(924, 588);
            Controls.Add(msgStatusLabel);
            Controls.Add(button1);
            Controls.Add(sendBtn);
            Controls.Add(msgTxb);
            Controls.Add(chatListView);
            Controls.Add(roomnameLabel);
            Controls.Add(captionLabel);
            Margin = new Padding(4);
            Name = "ChatRoom";
            Text = "ChatRoom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label captionLabel;
        private Label roomnameLabel;
        private ListView chatListView;
        private TextBox msgTxb;
        private Button sendBtn;
        private Button button1;
        private Label msgStatusLabel;
    }
}