namespace AtariDiskExplorer
{
    partial class ListViewer
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
            this.UIList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // UIList
            // 
            this.UIList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UIList.FormattingEnabled = true;
            this.UIList.Location = new System.Drawing.Point(3, 4);
            this.UIList.Name = "UIList";
            this.UIList.Size = new System.Drawing.Size(258, 407);
            this.UIList.TabIndex = 0;
            // 
            // ListViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 414);
            this.Controls.Add(this.UIList);
            this.Name = "ListViewer";
            this.Text = "ListViewer";
            this.Load += new System.EventHandler(this.ListViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox UIList;
    }
}