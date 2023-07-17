namespace Client
{
    partial class ShowProfile
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
            lblUsername = new Label();
            lblIntroduction = new Label();
            richTextBox1 = new RichTextBox();
            txtUsername = new TextBox();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(54, 31);
            lblUsername.Margin = new Padding(2, 0, 2, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(60, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            // 
            // lblIntroduction
            // 
            lblIntroduction.AutoSize = true;
            lblIntroduction.Location = new Point(54, 85);
            lblIntroduction.Margin = new Padding(2, 0, 2, 0);
            lblIntroduction.Name = "lblIntroduction";
            lblIntroduction.Size = new Size(73, 15);
            lblIntroduction.TabIndex = 1;
            lblIntroduction.Text = "Introduction";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(146, 83);
            richTextBox1.Margin = new Padding(2, 2, 2, 2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(383, 88);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(149, 33);
            txtUsername.Margin = new Padding(2, 2, 2, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(379, 23);
            txtUsername.TabIndex = 3;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(247, 202);
            btnClose.Margin = new Padding(2, 2, 2, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(78, 20);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // ShowProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(btnClose);
            Controls.Add(txtUsername);
            Controls.Add(richTextBox1);
            Controls.Add(lblIntroduction);
            Controls.Add(lblUsername);
            Margin = new Padding(2, 2, 2, 2);
            Name = "ShowProfile";
            Text = "User Profile";
            Load += ShowProfile_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private Label lblIntroduction;
        private RichTextBox richTextBox1;
        private TextBox txtUsername;
        private Button btnClose;
    }
}