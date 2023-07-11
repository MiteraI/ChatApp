namespace Client
{
    partial class UpdateProfile
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
            lblintroduction = new Label();
            rtxtIntroduction = new RichTextBox();
            btnBack = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // lblintroduction
            // 
            lblintroduction.AutoSize = true;
            lblintroduction.Location = new Point(77, 70);
            lblintroduction.Name = "lblintroduction";
            lblintroduction.Size = new Size(110, 25);
            lblintroduction.TabIndex = 0;
            lblintroduction.Text = "Introduction";
            // 
            // rtxtIntroduction
            // 
            rtxtIntroduction.Location = new Point(230, 67);
            rtxtIntroduction.Name = "rtxtIntroduction";
            rtxtIntroduction.Size = new Size(382, 108);
            rtxtIntroduction.TabIndex = 3;
            rtxtIntroduction.Text = "";
            rtxtIntroduction.TextChanged += rtxtIntroduction_TextChanged;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(129, 270);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(112, 34);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(554, 270);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // UpdateProfile
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(btnBack);
            Controls.Add(rtxtIntroduction);
            Controls.Add(lblintroduction);
            Name = "UpdateProfile";
            Text = "Update Profile";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblintroduction;
        private RichTextBox rtxtIntroduction;
        private Button btnBack;
        private Button btnSave;
    }
}