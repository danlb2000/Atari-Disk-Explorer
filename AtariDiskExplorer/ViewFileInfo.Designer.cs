namespace AtariDiskExplorer
{
    partial class ViewFileInfo
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.UIFileName = new System.Windows.Forms.TextBox();
            this.UIFileNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UIStartSector = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UINumberOfSectors = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UIFileSectors = new System.Windows.Forms.DataGridView();
            this.sectorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nextSectorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileHandleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ByteCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inUseInMapDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileSectorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UIErrorList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.UIIsValid = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.UIFileSectors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSectorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filename";
            // 
            // UIFileName
            // 
            this.UIFileName.Location = new System.Drawing.Point(15, 26);
            this.UIFileName.Name = "UIFileName";
            this.UIFileName.ReadOnly = true;
            this.UIFileName.Size = new System.Drawing.Size(180, 20);
            this.UIFileName.TabIndex = 1;
            // 
            // UIFileNumber
            // 
            this.UIFileNumber.Location = new System.Drawing.Point(201, 26);
            this.UIFileNumber.Name = "UIFileNumber";
            this.UIFileNumber.ReadOnly = true;
            this.UIFileNumber.Size = new System.Drawing.Size(66, 20);
            this.UIFileNumber.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "File Number";
            // 
            // UIStartSector
            // 
            this.UIStartSector.Location = new System.Drawing.Point(116, 75);
            this.UIStartSector.Name = "UIStartSector";
            this.UIStartSector.ReadOnly = true;
            this.UIStartSector.Size = new System.Drawing.Size(79, 20);
            this.UIStartSector.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Start Sector";
            // 
            // UINumberOfSectors
            // 
            this.UINumberOfSectors.Location = new System.Drawing.Point(15, 76);
            this.UINumberOfSectors.Name = "UINumberOfSectors";
            this.UINumberOfSectors.ReadOnly = true;
            this.UINumberOfSectors.Size = new System.Drawing.Size(92, 20);
            this.UINumberOfSectors.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Number of Sectors";
            // 
            // UIFileSectors
            // 
            this.UIFileSectors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UIFileSectors.AutoGenerateColumns = false;
            this.UIFileSectors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UIFileSectors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sectorDataGridViewTextBoxColumn,
            this.nextSectorDataGridViewTextBoxColumn,
            this.fileHandleDataGridViewTextBoxColumn,
            this.ByteCount,
            this.inUseInMapDataGridViewTextBoxColumn});
            this.UIFileSectors.DataSource = this.fileSectorBindingSource;
            this.UIFileSectors.Location = new System.Drawing.Point(15, 129);
            this.UIFileSectors.Name = "UIFileSectors";
            this.UIFileSectors.Size = new System.Drawing.Size(361, 167);
            this.UIFileSectors.TabIndex = 8;
            // 
            // sectorDataGridViewTextBoxColumn
            // 
            this.sectorDataGridViewTextBoxColumn.DataPropertyName = "Sector";
            this.sectorDataGridViewTextBoxColumn.HeaderText = "Sector";
            this.sectorDataGridViewTextBoxColumn.Name = "sectorDataGridViewTextBoxColumn";
            this.sectorDataGridViewTextBoxColumn.Width = 75;
            // 
            // nextSectorDataGridViewTextBoxColumn
            // 
            this.nextSectorDataGridViewTextBoxColumn.DataPropertyName = "NextSector";
            this.nextSectorDataGridViewTextBoxColumn.HeaderText = "NextSector";
            this.nextSectorDataGridViewTextBoxColumn.Name = "nextSectorDataGridViewTextBoxColumn";
            this.nextSectorDataGridViewTextBoxColumn.Width = 75;
            // 
            // fileHandleDataGridViewTextBoxColumn
            // 
            this.fileHandleDataGridViewTextBoxColumn.DataPropertyName = "FileHandle";
            this.fileHandleDataGridViewTextBoxColumn.HeaderText = "FileHandle";
            this.fileHandleDataGridViewTextBoxColumn.Name = "fileHandleDataGridViewTextBoxColumn";
            this.fileHandleDataGridViewTextBoxColumn.Width = 75;
            // 
            // ByteCount
            // 
            this.ByteCount.DataPropertyName = "ByteCount";
            this.ByteCount.HeaderText = "ByteCount";
            this.ByteCount.Name = "ByteCount";
            // 
            // inUseInMapDataGridViewTextBoxColumn
            // 
            this.inUseInMapDataGridViewTextBoxColumn.DataPropertyName = "InUseInMap";
            this.inUseInMapDataGridViewTextBoxColumn.HeaderText = "InUseInMap";
            this.inUseInMapDataGridViewTextBoxColumn.Name = "inUseInMapDataGridViewTextBoxColumn";
            this.inUseInMapDataGridViewTextBoxColumn.Width = 75;
            // 
            // fileSectorBindingSource
            // 
            this.fileSectorBindingSource.DataSource = typeof(AtariDisk.FileSystems.FileSector);
            // 
            // UIErrorList
            // 
            this.UIErrorList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UIErrorList.FormattingEnabled = true;
            this.UIErrorList.Location = new System.Drawing.Point(13, 318);
            this.UIErrorList.Name = "UIErrorList";
            this.UIErrorList.Size = new System.Drawing.Size(363, 121);
            this.UIErrorList.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "File Errors";
            // 
            // UIIsValid
            // 
            this.UIIsValid.AutoSize = true;
            this.UIIsValid.Enabled = false;
            this.UIIsValid.Location = new System.Drawing.Point(216, 78);
            this.UIIsValid.Name = "UIIsValid";
            this.UIIsValid.Size = new System.Drawing.Size(60, 17);
            this.UIIsValid.TabIndex = 11;
            this.UIIsValid.Text = "Is Valid";
            this.UIIsValid.UseVisualStyleBackColor = true;
            // 
            // ViewFileInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 454);
            this.Controls.Add(this.UIIsValid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.UIErrorList);
            this.Controls.Add(this.UIFileSectors);
            this.Controls.Add(this.UINumberOfSectors);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UIStartSector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UIFileNumber);
            this.Controls.Add(this.UIFileName);
            this.Controls.Add(this.label1);
            this.Name = "ViewFileInfo";
            this.Text = "ViewFileInfo";
            this.Load += new System.EventHandler(this.ViewFileInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UIFileSectors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSectorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UIFileName;
        private System.Windows.Forms.TextBox UIFileNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UIStartSector;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UINumberOfSectors;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView UIFileSectors;
        private System.Windows.Forms.BindingSource fileSectorBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn sectorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nextSectorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileHandleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ByteCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn inUseInMapDataGridViewTextBoxColumn;
        private System.Windows.Forms.ListBox UIErrorList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox UIIsValid;
    }
}