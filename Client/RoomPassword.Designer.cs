namespace Client
{
    partial class RoomPassword
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
            txtPassword = new TextBox();
            label1 = new Label();
            lblRoomTitle = new Label();
            btnSend = new Button();
            errorLabel = new Label();
            btnBack = new Button();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(291, 137);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(345, 31);
            txtPassword.TabIndex = 0;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(118, 143);
            label1.Name = "label1";
            label1.Size = new Size(89, 25);
            label1.TabIndex = 1;
            label1.Text = "password";
            // 
            // lblRoomTitle
            // 
            lblRoomTitle.AutoSize = true;
            lblRoomTitle.Location = new Point(362, 49);
            lblRoomTitle.Name = "lblRoomTitle";
            lblRoomTitle.Size = new Size(52, 25);
            lblRoomTitle.TabIndex = 2;
            lblRoomTitle.Text = "none";
            // 
            // btnSend
            // 
            btnSend.Location = new Point(506, 275);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(112, 34);
            btnSend.TabIndex = 3;
            btnSend.Text = "send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(362, 90);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(50, 25);
            errorLabel.TabIndex = 4;
            errorLabel.Text = "error";
            errorLabel.Click += errorLabel_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(183, 275);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(112, 34);
            btnBack.TabIndex = 5;
            btnBack.Text = "back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // RoomPassword
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(errorLabel);
            Controls.Add(btnSend);
            Controls.Add(lblRoomTitle);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Name = "RoomPassword";
            Text = "RoomPassword";
            Load += RoomPassword_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPassword;
        private Label label1;
        private Label lblRoomTitle;
        private Button btnSend;
        private Label errorLabel;
        private Button btnBack;
    }
}