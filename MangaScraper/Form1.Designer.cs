namespace JPGScraper
{
    partial class Form1
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
            this.urlBox = new System.Windows.Forms.RichTextBox();
            this.getJPGButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // urlBox
            // 
            this.urlBox.Location = new System.Drawing.Point(61, 54);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(165, 35);
            this.urlBox.TabIndex = 0;
            this.urlBox.Text = "";
            this.urlBox.TextChanged += new System.EventHandler(this.urlBox_TextChanged);
            // 
            // getJPGButton
            // 
            this.getJPGButton.Location = new System.Drawing.Point(104, 107);
            this.getJPGButton.Name = "getJPGButton";
            this.getJPGButton.Size = new System.Drawing.Size(75, 23);
            this.getJPGButton.TabIndex = 1;
            this.getJPGButton.Text = "Get Manga!";
            this.getJPGButton.UseVisualStyleBackColor = true;
            this.getJPGButton.Click += new System.EventHandler(this.getJPGButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter URL Here!";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(58, 160);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(35, 13);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.getJPGButton);
            this.Controls.Add(this.urlBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox urlBox;
        private System.Windows.Forms.Button getJPGButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label statusLabel;
    }
}

