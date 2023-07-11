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
            label2 = new Label();
            lblError = new Label();
            SuspendLayout();
            // 
            // captionLabel
            // 
            captionLabel.AutoSize = true;
            captionLabel.BackColor = SystemColors.ActiveCaption;
            captionLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            captionLabel.Location = new Point(336, 52);
            captionLabel.Margin = new Padding(4, 0, 4, 0);
            captionLabel.Name = "captionLabel";
            captionLabel.Size = new Size(334, 54);
            captionLabel.TabIndex = 0;
            captionLabel.Text = "ChatApp Register";
            // 
            // usernameTxb
            // 
            usernameTxb.Location = new Point(346, 191);
            usernameTxb.Margin = new Padding(4);
            usernameTxb.Name = "usernameTxb";
            usernameTxb.Size = new Size(365, 31);
            usernameTxb.TabIndex = 1;
            usernameTxb.TextChanged += usernameTxb_TextChanged;
            // 
            // passwordTxb
            // 
            passwordTxb.Location = new Point(346, 278);
            passwordTxb.Margin = new Padding(4);
            passwordTxb.Name = "passwordTxb";
            passwordTxb.Size = new Size(363, 31);
            passwordTxb.TabIndex = 2;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(198, 195);
            usernameLabel.Margin = new Padding(4, 0, 4, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(91, 25);
            usernameLabel.TabIndex = 3;
            usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(204, 281);
            passwordLabel.Margin = new Padding(4, 0, 4, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(87, 25);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "Password";
            // 
            // registerBtn
            // 
            registerBtn.Location = new Point(561, 375);
            registerBtn.Margin = new Padding(4);
            registerBtn.Name = "registerBtn";
            registerBtn.Size = new Size(222, 48);
            registerBtn.TabIndex = 5;
            registerBtn.Text = "Register";
            registerBtn.UseVisualStyleBackColor = true;
            registerBtn.Click += registerBtn_Click;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(346, 336);
            errorLabel.Margin = new Padding(4, 0, 4, 0);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 25);
            errorLabel.TabIndex = 6;
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(258, 375);
            loginBtn.Margin = new Padding(4);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(222, 48);
            loginBtn.TabIndex = 16;
            loginBtn.Text = "Go to Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Red;
            label1.Location = new Point(328, 335);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(346, 470);
            label2.Name = "label2";
            label2.Size = new Size(324, 25);
            label2.TabIndex = 17;
            label2.Text = "you can update your profile when login";
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(472, 143);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 25);
            lblError.TabIndex = 18;
            lblError.Click += lblError_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(lblError);
            Controls.Add(label2);
            Controls.Add(loginBtn);
            Controls.Add(label1);
            Controls.Add(errorLabel);
            Controls.Add(registerBtn);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(passwordTxb);
            Controls.Add(usernameTxb);
            Controls.Add(captionLabel);
            Margin = new Padding(4);
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
        private Label label2;
        private Label lblError;
    }
}