namespace AtariDiskExplorer
{
    partial class SectorRangePicker
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UIStartSector = new System.Windows.Forms.TextBox();
            this.UIEndSector = new System.Windows.Forms.TextBox();
            this.UIOk = new System.Windows.Forms.Button();
            this.UICancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Sector";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "End Sector";
            // 
            // UIStartSector
            // 
            this.UIStartSector.Location = new System.Drawing.Point(16, 30);
            this.UIStartSector.Name = "UIStartSector";
            this.UIStartSector.Size = new System.Drawing.Size(100, 20);
            this.UIStartSector.TabIndex = 2;
            // 
            // UIEndSector
            // 
            this.UIEndSector.Location = new System.Drawing.Point(138, 29);
            this.UIEndSector.Name = "UIEndSector";
            this.UIEndSector.Size = new System.Drawing.Size(100, 20);
            this.UIEndSector.TabIndex = 3;
            // 
            // UIOk
            // 
            this.UIOk.Location = new System.Drawing.Point(45, 75);
            this.UIOk.Name = "UIOk";
            this.UIOk.Size = new System.Drawing.Size(75, 23);
            this.UIOk.TabIndex = 4;
            this.UIOk.Text = "OK";
            this.UIOk.UseVisualStyleBackColor = true;
            this.UIOk.Click += new System.EventHandler(this.UIOk_Click);
            // 
            // UICancel
            // 
            this.UICancel.Location = new System.Drawing.Point(138, 75);
            this.UICancel.Name = "UICancel";
            this.UICancel.Size = new System.Drawing.Size(75, 23);
            this.UICancel.TabIndex = 5;
            this.UICancel.Text = "Cancel";
            this.UICancel.UseVisualStyleBackColor = true;
            this.UICancel.Click += new System.EventHandler(this.UICancel_Click);
            // 
            // SectorRangePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 113);
            this.Controls.Add(this.UICancel);
            this.Controls.Add(this.UIOk);
            this.Controls.Add(this.UIEndSector);
            this.Controls.Add(this.UIStartSector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SectorRangePicker";
            this.Text = "SectorRangePicker";
            this.Load += new System.EventHandler(this.SectorRangePicker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UIStartSector;
        private System.Windows.Forms.TextBox UIEndSector;
        private System.Windows.Forms.Button UIOk;
        private System.Windows.Forms.Button UICancel;
    }
}