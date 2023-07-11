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
            label2 = new Label();
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
            label1.Location = new Point(124, 140);
            label1.Name = "label1";
            label1.Size = new Size(138, 25);
            label1.TabIndex = 1;
            label1.Text = "Enter password:";
            // 
            // lblRoomTitle
            // 
            lblRoomTitle.AutoSize = true;
            lblRoomTitle.BackColor = SystemColors.ActiveCaption;
            lblRoomTitle.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblRoomTitle.Location = new Point(338, 36);
            lblRoomTitle.Name = "lblRoomTitle";
            lblRoomTitle.Size = new Size(89, 38);
            lblRoomTitle.TabIndex = 2;
            lblRoomTitle.Text = "Room";
            // 
            // btnSend
            // 
            btnSend.Location = new Point(506, 275);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(112, 34);
            btnSend.TabIndex = 3;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(124, 205);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 25);
            errorLabel.TabIndex = 4;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(183, 275);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(112, 34);
            btnBack.TabIndex = 5;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveCaption;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(124, 36);
            label2.Name = "label2";
            label2.Size = new Size(190, 38);
            label2.TabIndex = 6;
            label2.Text = "Room's name:";
            // 
            // RoomPassword
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(btnBack);
            Controls.Add(errorLabel);
            Controls.Add(btnSend);
            Controls.Add(lblRoomTitle);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Name = "RoomPassword";
            Text = "RoomPassword";
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
        private Label label2;
    }
}