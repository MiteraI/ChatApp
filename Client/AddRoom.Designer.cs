namespace Client
{
    partial class AddRoom
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
            txtTitle = new TextBox();
            txtPassword = new TextBox();
            groupBoxStat = new GroupBox();
            radioPrivate = new RadioButton();
            radioPublic = new RadioButton();
            label1 = new Label();
            btnSave = new Button();
            btnBack = new Button();
            groupBoxStat.SuspendLayout();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(240, 55);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(494, 31);
            txtTitle.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(188, 112);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(494, 31);
            txtPassword.TabIndex = 1;
            // 
            // groupBoxStat
            // 
            groupBoxStat.Controls.Add(radioPrivate);
            groupBoxStat.Controls.Add(radioPublic);
            groupBoxStat.Controls.Add(txtPassword);
            groupBoxStat.Location = new Point(52, 145);
            groupBoxStat.Name = "groupBoxStat";
            groupBoxStat.Size = new Size(696, 150);
            groupBoxStat.TabIndex = 2;
            groupBoxStat.TabStop = false;
            groupBoxStat.Text = "Visibility";
            // 
            // radioPrivate
            // 
            radioPrivate.AutoSize = true;
            radioPrivate.Location = new Point(0, 112);
            radioPrivate.Name = "radioPrivate";
            radioPrivate.Size = new Size(90, 29);
            radioPrivate.TabIndex = 1;
            radioPrivate.TabStop = true;
            radioPrivate.Text = "Private";
            radioPrivate.UseVisualStyleBackColor = true;
            // 
            // radioPublic
            // 
            radioPublic.AutoSize = true;
            radioPublic.Location = new Point(0, 67);
            radioPublic.Name = "radioPublic";
            radioPublic.Size = new Size(84, 29);
            radioPublic.TabIndex = 0;
            radioPublic.TabStop = true;
            radioPublic.Text = "Public";
            radioPublic.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(75, 58);
            label1.Name = "label1";
            label1.Size = new Size(125, 25);
            label1.TabIndex = 3;
            label1.Text = "Room's name:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(583, 367);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 4;
            btnSave.Text = "Create";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(104, 367);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(112, 34);
            btnBack.TabIndex = 5;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // AddRoom
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(btnSave);
            Controls.Add(label1);
            Controls.Add(groupBoxStat);
            Controls.Add(txtTitle);
            Name = "AddRoom";
            Text = "Create Room";
            groupBoxStat.ResumeLayout(false);
            groupBoxStat.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private TextBox txtPassword;
        private GroupBox groupBoxStat;
        private RadioButton radioPrivate;
        private RadioButton radioPublic;
        private Label label1;
        private Button btnSave;
        private Button btnBack;
    }
}