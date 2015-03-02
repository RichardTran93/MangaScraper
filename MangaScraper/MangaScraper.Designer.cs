namespace MangaScraper
{
    partial class MangaScraper
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
            this.seriesLabel = new System.Windows.Forms.Label();
            this.chapterLabel = new System.Windows.Forms.Label();
            this.pageLabel = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.radioGroupBox = new System.Windows.Forms.GroupBox();
            this.radioOrganize1 = new System.Windows.Forms.RadioButton();
            this.radioOrganize0 = new System.Windows.Forms.RadioButton();
            this.githubLabel = new System.Windows.Forms.Label();
            this.downloadLabel = new System.Windows.Forms.Label();
            this.completedLabel = new System.Windows.Forms.Label();
            this.mangaListBox = new System.Windows.Forms.ListBox();
            this.mangaBox = new System.Windows.Forms.GroupBox();
            this.mangaPandaButton = new System.Windows.Forms.RadioButton();
            this.mangaListButton = new System.Windows.Forms.Button();
            this.mangaHereButton = new System.Windows.Forms.RadioButton();
            this.downloadInstructionLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioGroupBox.SuspendLayout();
            this.mangaBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // urlBox
            // 
            this.urlBox.Location = new System.Drawing.Point(33, 137);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(165, 35);
            this.urlBox.TabIndex = 0;
            this.urlBox.Text = "";
            // 
            // getJPGButton
            // 
            this.getJPGButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.getJPGButton.Location = new System.Drawing.Point(33, 190);
            this.getJPGButton.Name = "getJPGButton";
            this.getJPGButton.Size = new System.Drawing.Size(84, 38);
            this.getJPGButton.TabIndex = 1;
            this.getJPGButton.Text = "Get Manga!";
            this.getJPGButton.UseVisualStyleBackColor = true;
            this.getJPGButton.Click += new System.EventHandler(this.getJPGButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter URL Here!";
            // 
            // seriesLabel
            // 
            this.seriesLabel.AutoSize = true;
            this.seriesLabel.Location = new System.Drawing.Point(31, 270);
            this.seriesLabel.Name = "seriesLabel";
            this.seriesLabel.Size = new System.Drawing.Size(36, 13);
            this.seriesLabel.TabIndex = 4;
            this.seriesLabel.Text = "Series";
            // 
            // chapterLabel
            // 
            this.chapterLabel.AutoSize = true;
            this.chapterLabel.Location = new System.Drawing.Point(31, 300);
            this.chapterLabel.Name = "chapterLabel";
            this.chapterLabel.Size = new System.Drawing.Size(44, 13);
            this.chapterLabel.TabIndex = 5;
            this.chapterLabel.Text = "Chapter";
            // 
            // pageLabel
            // 
            this.pageLabel.AutoSize = true;
            this.pageLabel.Location = new System.Drawing.Point(166, 300);
            this.pageLabel.Name = "pageLabel";
            this.pageLabel.Size = new System.Drawing.Size(32, 13);
            this.pageLabel.TabIndex = 6;
            this.pageLabel.Text = "Page";
            // 
            // stopButton
            // 
            this.stopButton.CausesValidation = false;
            this.stopButton.Location = new System.Drawing.Point(123, 190);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 38);
            this.stopButton.TabIndex = 7;
            this.stopButton.Text = "Click to Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // radioGroupBox
            // 
            this.radioGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupBox.Controls.Add(this.radioOrganize1);
            this.radioGroupBox.Controls.Add(this.radioOrganize0);
            this.radioGroupBox.Location = new System.Drawing.Point(55, 12);
            this.radioGroupBox.Name = "radioGroupBox";
            this.radioGroupBox.Size = new System.Drawing.Size(119, 75);
            this.radioGroupBox.TabIndex = 8;
            this.radioGroupBox.TabStop = false;
            // 
            // radioOrganize1
            // 
            this.radioOrganize1.AutoSize = true;
            this.radioOrganize1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radioOrganize1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioOrganize1.Location = new System.Drawing.Point(0, 18);
            this.radioOrganize1.Name = "radioOrganize1";
            this.radioOrganize1.Size = new System.Drawing.Size(121, 17);
            this.radioOrganize1.TabIndex = 9;
            this.radioOrganize1.TabStop = true;
            this.radioOrganize1.Text = "Organize into folders";
            this.radioOrganize1.UseVisualStyleBackColor = true;
            this.radioOrganize1.CheckedChanged += new System.EventHandler(this.radioOrganize1_CheckedChanged);
            // 
            // radioOrganize0
            // 
            this.radioOrganize0.AutoSize = true;
            this.radioOrganize0.Location = new System.Drawing.Point(0, 43);
            this.radioOrganize0.Name = "radioOrganize0";
            this.radioOrganize0.Size = new System.Drawing.Size(97, 17);
            this.radioOrganize0.TabIndex = 10;
            this.radioOrganize0.TabStop = true;
            this.radioOrganize0.Text = "All in one folder";
            this.radioOrganize0.UseVisualStyleBackColor = true;
            this.radioOrganize0.CheckedChanged += new System.EventHandler(this.radioOrganize0_CheckedChanged);
            // 
            // githubLabel
            // 
            this.githubLabel.AutoSize = true;
            this.githubLabel.Location = new System.Drawing.Point(9, 372);
            this.githubLabel.Name = "githubLabel";
            this.githubLabel.Size = new System.Drawing.Size(237, 13);
            this.githubLabel.TabIndex = 9;
            this.githubLabel.Text = "www.github.com/RichardTran93/MangaScraper";
            this.githubLabel.Click += new System.EventHandler(this.githubLabel_Click);
            // 
            // downloadLabel
            // 
            this.downloadLabel.AutoSize = true;
            this.downloadLabel.Location = new System.Drawing.Point(12, 149);
            this.downloadLabel.Name = "downloadLabel";
            this.downloadLabel.Size = new System.Drawing.Size(0, 13);
            this.downloadLabel.TabIndex = 10;
            // 
            // completedLabel
            // 
            this.completedLabel.AutoSize = true;
            this.completedLabel.Location = new System.Drawing.Point(12, 203);
            this.completedLabel.Name = "completedLabel";
            this.completedLabel.Size = new System.Drawing.Size(0, 13);
            this.completedLabel.TabIndex = 11;
            // 
            // mangaListBox
            // 
            this.mangaListBox.FormattingEnabled = true;
            this.mangaListBox.Location = new System.Drawing.Point(504, 48);
            this.mangaListBox.Name = "mangaListBox";
            this.mangaListBox.ScrollAlwaysVisible = true;
            this.mangaListBox.Size = new System.Drawing.Size(251, 316);
            this.mangaListBox.TabIndex = 12;
            this.mangaListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mangaListBox_MouseDoubleClick);
            // 
            // mangaBox
            // 
            this.mangaBox.Controls.Add(this.mangaPandaButton);
            this.mangaBox.Controls.Add(this.mangaListButton);
            this.mangaBox.Controls.Add(this.mangaHereButton);
            this.mangaBox.Location = new System.Drawing.Point(281, 128);
            this.mangaBox.Name = "mangaBox";
            this.mangaBox.Size = new System.Drawing.Size(200, 100);
            this.mangaBox.TabIndex = 13;
            this.mangaBox.TabStop = false;
            // 
            // mangaPandaButton
            // 
            this.mangaPandaButton.AutoSize = true;
            this.mangaPandaButton.Location = new System.Drawing.Point(6, 16);
            this.mangaPandaButton.Name = "mangaPandaButton";
            this.mangaPandaButton.Size = new System.Drawing.Size(89, 17);
            this.mangaPandaButton.TabIndex = 1;
            this.mangaPandaButton.TabStop = true;
            this.mangaPandaButton.Text = "MangaPanda";
            this.mangaPandaButton.UseVisualStyleBackColor = true;
            // 
            // mangaListButton
            // 
            this.mangaListButton.Location = new System.Drawing.Point(38, 71);
            this.mangaListButton.Name = "mangaListButton";
            this.mangaListButton.Size = new System.Drawing.Size(125, 23);
            this.mangaListButton.TabIndex = 14;
            this.mangaListButton.Text = "Get List of Manga";
            this.mangaListButton.UseVisualStyleBackColor = true;
            this.mangaListButton.Click += new System.EventHandler(this.mangaListButton_Click);
            // 
            // mangaHereButton
            // 
            this.mangaHereButton.AutoSize = true;
            this.mangaHereButton.Location = new System.Drawing.Point(6, 39);
            this.mangaHereButton.Name = "mangaHereButton";
            this.mangaHereButton.Size = new System.Drawing.Size(81, 17);
            this.mangaHereButton.TabIndex = 0;
            this.mangaHereButton.TabStop = true;
            this.mangaHereButton.Text = "MangaHere";
            this.mangaHereButton.UseVisualStyleBackColor = true;
            // 
            // downloadInstructionLabel
            // 
            this.downloadInstructionLabel.AutoSize = true;
            this.downloadInstructionLabel.Location = new System.Drawing.Point(551, 23);
            this.downloadInstructionLabel.Name = "downloadInstructionLabel";
            this.downloadInstructionLabel.Size = new System.Drawing.Size(162, 13);
            this.downloadInstructionLabel.TabIndex = 14;
            this.downloadInstructionLabel.Text = "Double click manga to download";
            this.downloadInstructionLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Use this to select from a list instead!";
            // 
            // MangaScraper
            // 
            this.AcceptButton = this.getJPGButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.getJPGButton;
            this.ClientSize = new System.Drawing.Size(809, 394);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.downloadInstructionLabel);
            this.Controls.Add(this.mangaBox);
            this.Controls.Add(this.mangaListBox);
            this.Controls.Add(this.completedLabel);
            this.Controls.Add(this.downloadLabel);
            this.Controls.Add(this.githubLabel);
            this.Controls.Add(this.radioGroupBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.pageLabel);
            this.Controls.Add(this.chapterLabel);
            this.Controls.Add(this.seriesLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.getJPGButton);
            this.Controls.Add(this.urlBox);
            this.Name = "MangaScraper";
            this.Text = "MangaScraper";
            this.radioGroupBox.ResumeLayout(false);
            this.radioGroupBox.PerformLayout();
            this.mangaBox.ResumeLayout(false);
            this.mangaBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox urlBox;
        private System.Windows.Forms.Button getJPGButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label seriesLabel;
        private System.Windows.Forms.Label chapterLabel;
        private System.Windows.Forms.Label pageLabel;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.GroupBox radioGroupBox;
        private System.Windows.Forms.RadioButton radioOrganize1;
        private System.Windows.Forms.RadioButton radioOrganize0;
        private System.Windows.Forms.Label githubLabel;
        private System.Windows.Forms.Label downloadLabel;
        private System.Windows.Forms.Label completedLabel;
        private System.Windows.Forms.ListBox mangaListBox;
        private System.Windows.Forms.GroupBox mangaBox;
        private System.Windows.Forms.RadioButton mangaPandaButton;
        private System.Windows.Forms.RadioButton mangaHereButton;
        private System.Windows.Forms.Button mangaListButton;
        private System.Windows.Forms.Label downloadInstructionLabel;
        private System.Windows.Forms.Label label2;
    }
}

