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
            captionLabel.Location = new Point(41, 23);
            captionLabel.Name = "captionLabel";
            captionLabel.Size = new Size(162, 31);
            captionLabel.TabIndex = 0;
            captionLabel.Text = "Room's name: ";
            // 
            // roomnameLabel
            // 
            roomnameLabel.AutoSize = true;
            roomnameLabel.BackColor = SystemColors.ActiveCaption;
            roomnameLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            roomnameLabel.Location = new Point(209, 23);
            roomnameLabel.Name = "roomnameLabel";
            roomnameLabel.Size = new Size(76, 31);
            roomnameLabel.TabIndex = 1;
            roomnameLabel.Text = "label2";
            // 
            // chatListView
            // 
            chatListView.Location = new Point(40, 96);
            chatListView.Name = "chatListView";
            chatListView.Size = new Size(494, 220);
            chatListView.TabIndex = 2;
            chatListView.UseCompatibleStateImageBehavior = false;
            chatListView.View = View.Details;
            chatListView.Columns.Add("Username", 100);
            chatListView.Columns.Add("Content", 300);
            chatListView.Columns.Add("Sent time", 100);
            // 
            // msgTxb
            // 
            msgTxb.Location = new Point(38, 356);
            msgTxb.Name = "msgTxb";
            msgTxb.Size = new Size(402, 27);
            msgTxb.TabIndex = 3;
            // 
            // sendBtn
            // 
            sendBtn.Location = new Point(575, 352);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(93, 31);
            sendBtn.TabIndex = 4;
            sendBtn.Text = "Send";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += sendBtn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(493, 23);
            button1.Name = "button1";
            button1.Size = new Size(175, 33);
            button1.TabIndex = 5;
            button1.Text = "Return to Room List";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // msgStatusLabel
            // 
            msgStatusLabel.AutoSize = true;
            msgStatusLabel.ForeColor = Color.Aqua;
            msgStatusLabel.Location = new Point(261, 406);
            msgStatusLabel.Name = "msgStatusLabel";
            msgStatusLabel.Size = new Size(77, 20);
            msgStatusLabel.TabIndex = 6;
            msgStatusLabel.Text = "MsgStatus";
            // 
            // ChatRoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 450);
            Controls.Add(msgStatusLabel);
            Controls.Add(button1);
            Controls.Add(sendBtn);
            Controls.Add(msgTxb);
            Controls.Add(chatListView);
            Controls.Add(roomnameLabel);
            Controls.Add(captionLabel);
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