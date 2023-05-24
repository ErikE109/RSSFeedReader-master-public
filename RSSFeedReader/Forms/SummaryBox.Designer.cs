namespace RSSFeedReader.Forms
{
    partial class SummaryBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.textBoxSummary = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPublishDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.imgLink = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblTitle.Location = new System.Drawing.Point(27, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(408, 119);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxSummary
            // 
            this.textBoxSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.textBoxSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSummary.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSummary.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.textBoxSummary.Location = new System.Drawing.Point(14, 3);
            this.textBoxSummary.MaximumSize = new System.Drawing.Size(390, 1500);
            this.textBoxSummary.MinimumSize = new System.Drawing.Size(390, 160);
            this.textBoxSummary.Name = "textBoxSummary";
            this.textBoxSummary.ReadOnly = true;
            this.textBoxSummary.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textBoxSummary.Size = new System.Drawing.Size(390, 164);
            this.textBoxSummary.TabIndex = 0;
            this.textBoxSummary.Text = "";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.panel1.Controls.Add(this.textBoxSummary);
            this.panel1.Location = new System.Drawing.Point(27, 149);
            this.panel1.MinimumSize = new System.Drawing.Size(423, 174);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 174);
            this.panel1.TabIndex = 7;
            // 
            // lblPublishDate
            // 
            this.lblPublishDate.AutoSize = true;
            this.lblPublishDate.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblPublishDate.Location = new System.Drawing.Point(29, 116);
            this.lblPublishDate.Name = "lblPublishDate";
            this.lblPublishDate.Size = new System.Drawing.Size(0, 20);
            this.lblPublishDate.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(27, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 10;
            // 
            // imgLink
            // 
            this.imgLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgLink.Image = global::RSSFeedReader.Properties.Resources.browser_icon;
            this.imgLink.Location = new System.Drawing.Point(434, 9);
            this.imgLink.Name = "imgLink";
            this.imgLink.Size = new System.Drawing.Size(49, 51);
            this.imgLink.TabIndex = 11;
            this.imgLink.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imgLink_MouseClick);
            // 
            // SummaryBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Controls.Add(this.imgLink);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPublishDate);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel1);
            this.Name = "SummaryBox";
            this.Size = new System.Drawing.Size(486, 333);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblTitle;
        private RichTextBox textBoxSummary;
        private Panel panel1;
        private Label lblPublishDate;
        private Label label1;
        private LinkLabel imgLink;
    }
}
