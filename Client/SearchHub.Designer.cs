namespace Client
{
    partial class SearchHub
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
            searchTxtBox = new TextBox();
            searchLabel = new Label();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // searchTxtBox
            // 
            searchTxtBox.Location = new Point(313, 44);
            searchTxtBox.Name = "searchTxtBox";
            searchTxtBox.Size = new Size(352, 27);
            searchTxtBox.TabIndex = 0;
            searchTxtBox.TextChanged += searchTxtBox_TextChanged;
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.BackColor = SystemColors.ActiveCaption;
            searchLabel.Location = new Point(112, 47);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(177, 20);
            searchLabel.TabIndex = 1;
            searchLabel.Text = "Type to search for friend: ";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(120, 112);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(541, 224);
            listBox1.TabIndex = 2;
            // 
            // SearchHub
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBox1);
            Controls.Add(searchLabel);
            Controls.Add(searchTxtBox);
            Name = "SearchHub";
            Text = "SearchHub";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox searchTxtBox;
        private Label searchLabel;
        private ListBox listBox1;
    }
}