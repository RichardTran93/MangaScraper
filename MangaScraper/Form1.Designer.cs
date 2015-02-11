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
            this.seriesLabel = new System.Windows.Forms.Label();
            this.chapterLabel = new System.Windows.Forms.Label();
            this.pageLabel = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // urlBox
            // 
            this.urlBox.Location = new System.Drawing.Point(61, 54);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(165, 35);
            this.urlBox.TabIndex = 0;
            this.urlBox.Text = "";
            // 
            // getJPGButton
            // 
            this.getJPGButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.getJPGButton.Location = new System.Drawing.Point(62, 107);
            this.getJPGButton.Name = "getJPGButton";
            this.getJPGButton.Size = new System.Drawing.Size(83, 38);
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
            this.statusLabel.CausesValidation = false;
            this.statusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.statusLabel.Location = new System.Drawing.Point(58, 160);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(37, 13);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "Status";
            // 
            // seriesLabel
            // 
            this.seriesLabel.AutoSize = true;
            this.seriesLabel.Location = new System.Drawing.Point(59, 187);
            this.seriesLabel.Name = "seriesLabel";
            this.seriesLabel.Size = new System.Drawing.Size(36, 13);
            this.seriesLabel.TabIndex = 4;
            this.seriesLabel.Text = "Series";
            // 
            // chapterLabel
            // 
            this.chapterLabel.AutoSize = true;
            this.chapterLabel.Location = new System.Drawing.Point(59, 217);
            this.chapterLabel.Name = "chapterLabel";
            this.chapterLabel.Size = new System.Drawing.Size(44, 13);
            this.chapterLabel.TabIndex = 5;
            this.chapterLabel.Text = "Chapter";
            // 
            // pageLabel
            // 
            this.pageLabel.AutoSize = true;
            this.pageLabel.Location = new System.Drawing.Point(194, 217);
            this.pageLabel.Name = "pageLabel";
            this.pageLabel.Size = new System.Drawing.Size(32, 13);
            this.pageLabel.TabIndex = 6;
            this.pageLabel.Text = "Page";
            // 
            // stopButton
            // 
            this.stopButton.CausesValidation = false;
            this.stopButton.Location = new System.Drawing.Point(151, 107);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(86, 38);
            this.stopButton.TabIndex = 7;
            this.stopButton.Text = "Double Click to Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.getJPGButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.getJPGButton;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.pageLabel);
            this.Controls.Add(this.chapterLabel);
            this.Controls.Add(this.seriesLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.getJPGButton);
            this.Controls.Add(this.urlBox);
            this.Name = "Form1";
            this.Text = "MangaScraper for Mangahere.co";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox urlBox;
        private System.Windows.Forms.Button getJPGButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label seriesLabel;
        private System.Windows.Forms.Label chapterLabel;
        private System.Windows.Forms.Label pageLabel;
        private System.Windows.Forms.Button stopButton;
    }
}

