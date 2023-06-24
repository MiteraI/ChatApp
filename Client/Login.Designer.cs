namespace Client
{
    partial class Login
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
            errorLabel = new Label();
            registerBtn = new Button();
            passwordLabel = new Label();
            usernameLabel = new Label();
            passwordTxb = new TextBox();
            usernameTxb = new TextBox();
            captionLabel = new Label();
            loginBtn = new Button();
            SuspendLayout();
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(283, 268);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 20);
            errorLabel.TabIndex = 13;
            // 
            // registerBtn
            // 
            registerBtn.Location = new Point(473, 300);
            registerBtn.Name = "registerBtn";
            registerBtn.Size = new Size(178, 38);
            registerBtn.TabIndex = 12;
            registerBtn.Text = "Go to Register";
            registerBtn.UseVisualStyleBackColor = true;
            registerBtn.Click += registerBtn_Click;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(169, 224);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(70, 20);
            passwordLabel.TabIndex = 11;
            passwordLabel.Text = "Password";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(164, 155);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(75, 20);
            usernameLabel.TabIndex = 10;
            usernameLabel.Text = "Username";
            // 
            // passwordTxb
            // 
            passwordTxb.Location = new Point(283, 221);
            passwordTxb.Name = "passwordTxb";
            passwordTxb.Size = new Size(291, 27);
            passwordTxb.TabIndex = 9;
            // 
            // usernameTxb
            // 
            usernameTxb.Location = new Point(283, 152);
            usernameTxb.Name = "usernameTxb";
            usernameTxb.Size = new Size(293, 27);
            usernameTxb.TabIndex = 8;
            // 
            // captionLabel
            // 
            captionLabel.AutoSize = true;
            captionLabel.BackColor = SystemColors.ActiveCaption;
            captionLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            captionLabel.Location = new Point(302, 46);
            captionLabel.Name = "captionLabel";
            captionLabel.Size = new Size(243, 46);
            captionLabel.TabIndex = 7;
            captionLabel.Text = "ChatApp Login";
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(227, 300);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(178, 38);
            loginBtn.TabIndex = 14;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(loginBtn);
            Controls.Add(errorLabel);
            Controls.Add(registerBtn);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(passwordTxb);
            Controls.Add(usernameTxb);
            Controls.Add(captionLabel);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label errorLabel;
        private Button registerBtn;
        private Label passwordLabel;
        private Label usernameLabel;
        private TextBox passwordTxb;
        private TextBox usernameTxb;
        private Label captionLabel;
        private Button loginBtn;
    }
}