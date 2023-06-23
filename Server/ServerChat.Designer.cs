namespace Server
{
    partial class ServerChat
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
            listView1 = new ListView();
            listView2 = new ListView();
            textBox1 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(46, 23);
            listView1.Name = "listView1";
            listView1.Size = new Size(488, 233);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            listView2.Location = new Point(567, 24);
            listView2.Name = "listView2";
            listView2.Size = new Size(182, 231);
            listView2.TabIndex = 1;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(69, 311);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(450, 27);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(618, 311);
            button1.Name = "button1";
            button1.Size = new Size(95, 27);
            button1.TabIndex = 3;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            // 
            // ServerChat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 404);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Name = "ServerChat";
            Text = "ServerChat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ListView listView2;
        private TextBox textBox1;
        private Button button1;
    }
}