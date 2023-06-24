namespace Client
{
    partial class Register
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
            usernameTxb = new TextBox();
            passwordTxb = new TextBox();
            usernameLabel = new Label();
            passwordLabel = new Label();
            registerBtn = new Button();
            errorLabel = new Label();
            loginBtn = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // captionLabel
            // 
            captionLabel.AutoSize = true;
            captionLabel.BackColor = SystemColors.ActiveCaption;
            captionLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            captionLabel.Location = new Point(269, 42);
            captionLabel.Name = "captionLabel";
            captionLabel.Size = new Size(281, 46);
            captionLabel.TabIndex = 0;
            captionLabel.Text = "ChatApp Register";
            // 
            // usernameTxb
            // 
            usernameTxb.Location = new Point(277, 153);
            usernameTxb.Name = "usernameTxb";
            usernameTxb.Size = new Size(293, 27);
            usernameTxb.TabIndex = 1;
   
            // 
            // passwordTxb
            // 
            passwordTxb.Location = new Point(277, 222);
            passwordTxb.Name = "passwordTxb";
            passwordTxb.Size = new Size(291, 27);
            passwordTxb.TabIndex = 2;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(158, 156);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(75, 20);
            usernameLabel.TabIndex = 3;
            usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(163, 225);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(70, 20);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "Password";
            // 
            // registerBtn
            // 
            registerBtn.Location = new Point(449, 300);
            registerBtn.Name = "registerBtn";
            registerBtn.Size = new Size(178, 38);
            registerBtn.TabIndex = 5;
            registerBtn.Text = "Register";
            registerBtn.UseVisualStyleBackColor = true;
            registerBtn.Click += registerBtn_Click;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(277, 269);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 20);
            errorLabel.TabIndex = 6;
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(206, 300);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(178, 38);
            loginBtn.TabIndex = 16;
            loginBtn.Text = "Go to Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Red;
            label1.Location = new Point(262, 268);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 15;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(loginBtn);
            Controls.Add(label1);
            Controls.Add(errorLabel);
            Controls.Add(registerBtn);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(passwordTxb);
            Controls.Add(usernameTxb);
            Controls.Add(captionLabel);
            Name = "Register";
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label captionLabel;
        private TextBox usernameTxb;
        private TextBox passwordTxb;
        private Label usernameLabel;
        private Label passwordLabel;
        private Button registerBtn;
        private Label errorLabel;
        private Button loginBtn;
        private Label label1;
    }
}