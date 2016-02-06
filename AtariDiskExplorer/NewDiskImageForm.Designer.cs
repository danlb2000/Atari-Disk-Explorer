

partial class NewDiskImageForm : System.Windows.Forms.Form
{

	//Form overrides dispose to clean up the component list.
	[System.Diagnostics.DebuggerNonUserCode()]
	protected override void Dispose(bool disposing)
	{
		try {
			if (disposing && components != null) {
				components.Dispose();
			}
		}
		finally {
			base.Dispose(disposing);
		}
	}

	//Required by the Windows Form Designer
	private System.ComponentModel.IContainer components = null;

	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
            this.UIFilename = new System.Windows.Forms.TextBox();
            this.UIBrowse = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.UISectors = new System.Windows.Forms.TextBox();
            this.UISectorSize = new System.Windows.Forms.ComboBox();
            this.UIOK = new System.Windows.Forms.Button();
            this.UICancel = new System.Windows.Forms.Button();
            this.UIFileSystem = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UIFilename
            // 
            this.UIFilename.Location = new System.Drawing.Point(12, 12);
            this.UIFilename.Name = "UIFilename";
            this.UIFilename.Size = new System.Drawing.Size(285, 20);
            this.UIFilename.TabIndex = 0;
            // 
            // UIBrowse
            // 
            this.UIBrowse.Location = new System.Drawing.Point(297, 10);
            this.UIBrowse.Name = "UIBrowse";
            this.UIBrowse.Size = new System.Drawing.Size(24, 23);
            this.UIBrowse.TabIndex = 1;
            this.UIBrowse.Text = "...";
            this.UIBrowse.UseVisualStyleBackColor = true;
            this.UIBrowse.Click += new System.EventHandler(this.UIBrowse_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(13, 99);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(61, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Sector Size";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(194, 99);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(43, 13);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Sectors";
            // 
            // UISectors
            // 
            this.UISectors.Location = new System.Drawing.Point(239, 92);
            this.UISectors.Name = "UISectors";
            this.UISectors.Size = new System.Drawing.Size(82, 20);
            this.UISectors.TabIndex = 5;
            // 
            // UISectorSize
            // 
            this.UISectorSize.FormattingEnabled = true;
            this.UISectorSize.Items.AddRange(new object[] {
            "128",
            "256"});
            this.UISectorSize.Location = new System.Drawing.Point(76, 91);
            this.UISectorSize.Name = "UISectorSize";
            this.UISectorSize.Size = new System.Drawing.Size(88, 21);
            this.UISectorSize.TabIndex = 6;
            // 
            // UIOK
            // 
            this.UIOK.Location = new System.Drawing.Point(76, 139);
            this.UIOK.Name = "UIOK";
            this.UIOK.Size = new System.Drawing.Size(75, 23);
            this.UIOK.TabIndex = 7;
            this.UIOK.Text = "OK";
            this.UIOK.UseVisualStyleBackColor = true;
            this.UIOK.Click += new System.EventHandler(this.UIOK_Click);
            // 
            // UICancel
            // 
            this.UICancel.Location = new System.Drawing.Point(188, 139);
            this.UICancel.Name = "UICancel";
            this.UICancel.Size = new System.Drawing.Size(75, 23);
            this.UICancel.TabIndex = 8;
            this.UICancel.Text = "Cancel";
            this.UICancel.UseVisualStyleBackColor = true;
            this.UICancel.Click += new System.EventHandler(this.UICancel_Click);
            // 
            // UIFileSystem
            // 
            this.UIFileSystem.FormattingEnabled = true;
            this.UIFileSystem.Items.AddRange(new object[] {
            "None",
            "DOS2.0",
            "DOS2.5",
            "MegaImage"});
            this.UIFileSystem.Location = new System.Drawing.Point(58, 45);
            this.UIFileSystem.Name = "UIFileSystem";
            this.UIFileSystem.Size = new System.Drawing.Size(181, 21);
            this.UIFileSystem.TabIndex = 9;
            this.UIFileSystem.SelectedIndexChanged += new System.EventHandler(this.UIFileSystem_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Format";
            // 
            // NewDiskImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 183);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UIFileSystem);
            this.Controls.Add(this.UICancel);
            this.Controls.Add(this.UIOK);
            this.Controls.Add(this.UISectorSize);
            this.Controls.Add(this.UISectors);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.UIBrowse);
            this.Controls.Add(this.UIFilename);
            this.Name = "NewDiskImageForm";
            this.Text = "New Disk Image";
            this.ResumeLayout(false);
            this.PerformLayout();

	}
	internal System.Windows.Forms.TextBox UIFilename;
	internal System.Windows.Forms.Button UIBrowse;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.TextBox UISectors;
	internal System.Windows.Forms.ComboBox UISectorSize;
	internal System.Windows.Forms.Button UIOK;
	internal System.Windows.Forms.Button UICancel;
    private System.Windows.Forms.ComboBox UIFileSystem;
    private System.Windows.Forms.Label label3;
}

