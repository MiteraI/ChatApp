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
            errorLabel.Location = new Point(354, 335);
            errorLabel.Margin = new Padding(4, 0, 4, 0);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 25);
            errorLabel.TabIndex = 13;
            // 
            // registerBtn
            // 
            registerBtn.Location = new Point(571, 369);
            registerBtn.Margin = new Padding(4);
            registerBtn.Name = "registerBtn";
            registerBtn.Size = new Size(222, 48);
            registerBtn.TabIndex = 12;
            registerBtn.Text = "Go to Register";
            registerBtn.UseVisualStyleBackColor = true;
            registerBtn.Click += registerBtn_Click;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(211, 280);
            passwordLabel.Margin = new Padding(4, 0, 4, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(87, 25);
            passwordLabel.TabIndex = 11;
            passwordLabel.Text = "Password";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(205, 194);
            usernameLabel.Margin = new Padding(4, 0, 4, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(91, 25);
            usernameLabel.TabIndex = 10;
            usernameLabel.Text = "Username";
            // 
            // passwordTxb
            // 
            passwordTxb.Location = new Point(354, 276);
            passwordTxb.Margin = new Padding(4);
            passwordTxb.Name = "passwordTxb";
            passwordTxb.Size = new Size(363, 31);
            passwordTxb.TabIndex = 9;
            passwordTxb.KeyDown += passwordTxb_KeyDown;
            // 
            // usernameTxb
            // 
            usernameTxb.Location = new Point(354, 190);
            usernameTxb.Margin = new Padding(4);
            usernameTxb.Name = "usernameTxb";
            usernameTxb.Size = new Size(365, 31);
            usernameTxb.TabIndex = 8;
            // 
            // captionLabel
            // 
            captionLabel.AutoSize = true;
            captionLabel.BackColor = SystemColors.ActiveCaption;
            captionLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            captionLabel.Location = new Point(396, 64);
            captionLabel.Margin = new Padding(4, 0, 4, 0);
            captionLabel.Name = "captionLabel";
            captionLabel.Size = new Size(289, 54);
            captionLabel.TabIndex = 7;
            captionLabel.Text = "ChatApp Login";
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(240, 369);
            loginBtn.Margin = new Padding(4);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(222, 48);
            loginBtn.TabIndex = 14;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(loginBtn);
            Controls.Add(errorLabel);
            Controls.Add(registerBtn);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(passwordTxb);
            Controls.Add(usernameTxb);
            Controls.Add(captionLabel);
            Margin = new Padding(4);
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