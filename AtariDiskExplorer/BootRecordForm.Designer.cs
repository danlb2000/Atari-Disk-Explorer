
partial class BootRecordForm : System.Windows.Forms.Form
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
        this.Label1 = new System.Windows.Forms.Label();
        this.UIDosCode = new System.Windows.Forms.Label();
        this.UISectorsToBoot = new System.Windows.Forms.Label();
        this.Label3 = new System.Windows.Forms.Label();
        this.UILoadAddress = new System.Windows.Forms.Label();
        this.Label5 = new System.Windows.Forms.Label();
        this.UIInitAddress = new System.Windows.Forms.Label();
        this.Label4 = new System.Windows.Forms.Label();
        this.UIBootContinue = new System.Windows.Forms.Label();
        this.Label6 = new System.Windows.Forms.Label();
        this.UIMaxOpenFiles = new System.Windows.Forms.Label();
        this.Label8 = new System.Windows.Forms.Label();
        this.UIDriveBits = new System.Windows.Forms.Label();
        this.Label7 = new System.Windows.Forms.Label();
        this.UIDisassembly = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(5, 9);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(58, 13);
        this.Label1.TabIndex = 0;
        this.Label1.Text = "DOS Code";
        // 
        // UIDosCode
        // 
        this.UIDosCode.BackColor = System.Drawing.Color.White;
        this.UIDosCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.UIDosCode.Location = new System.Drawing.Point(8, 22);
        this.UIDosCode.Name = "UIDosCode";
        this.UIDosCode.Size = new System.Drawing.Size(55, 19);
        this.UIDosCode.TabIndex = 1;
        this.UIDosCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // UISectorsToBoot
        // 
        this.UISectorsToBoot.BackColor = System.Drawing.Color.White;
        this.UISectorsToBoot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.UISectorsToBoot.Location = new System.Drawing.Point(87, 22);
        this.UISectorsToBoot.Name = "UISectorsToBoot";
        this.UISectorsToBoot.Size = new System.Drawing.Size(77, 19);
        this.UISectorsToBoot.TabIndex = 3;
        this.UISectorsToBoot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label3
        // 
        this.Label3.AutoSize = true;
        this.Label3.Location = new System.Drawing.Point(84, 9);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(80, 13);
        this.Label3.TabIndex = 2;
        this.Label3.Text = "Sectors to Boot";
        // 
        // UILoadAddress
        // 
        this.UILoadAddress.BackColor = System.Drawing.Color.White;
        this.UILoadAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.UILoadAddress.Location = new System.Drawing.Point(187, 22);
        this.UILoadAddress.Name = "UILoadAddress";
        this.UILoadAddress.Size = new System.Drawing.Size(77, 19);
        this.UILoadAddress.TabIndex = 5;
        this.UILoadAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label5
        // 
        this.Label5.AutoSize = true;
        this.Label5.Location = new System.Drawing.Point(184, 9);
        this.Label5.Name = "Label5";
        this.Label5.Size = new System.Drawing.Size(72, 13);
        this.Label5.TabIndex = 4;
        this.Label5.Text = "Load Address";
        // 
        // UIInitAddress
        // 
        this.UIInitAddress.BackColor = System.Drawing.Color.White;
        this.UIInitAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.UIInitAddress.Location = new System.Drawing.Point(287, 22);
        this.UIInitAddress.Name = "UIInitAddress";
        this.UIInitAddress.Size = new System.Drawing.Size(77, 19);
        this.UIInitAddress.TabIndex = 7;
        this.UIInitAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label4
        // 
        this.Label4.AutoSize = true;
        this.Label4.Location = new System.Drawing.Point(284, 9);
        this.Label4.Name = "Label4";
        this.Label4.Size = new System.Drawing.Size(62, 13);
        this.Label4.TabIndex = 6;
        this.Label4.Text = "Init Address";
        // 
        // UIBootContinue
        // 
        this.UIBootContinue.BackColor = System.Drawing.Color.White;
        this.UIBootContinue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.UIBootContinue.Location = new System.Drawing.Point(8, 64);
        this.UIBootContinue.Name = "UIBootContinue";
        this.UIBootContinue.Size = new System.Drawing.Size(156, 19);
        this.UIBootContinue.TabIndex = 9;
        this.UIBootContinue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label6
        // 
        this.Label6.AutoSize = true;
        this.Label6.Location = new System.Drawing.Point(5, 51);
        this.Label6.Name = "Label6";
        this.Label6.Size = new System.Drawing.Size(132, 13);
        this.Label6.TabIndex = 8;
        this.Label6.Text = "Boot Continuation Address";
        // 
        // UIMaxOpenFiles
        // 
        this.UIMaxOpenFiles.BackColor = System.Drawing.Color.White;
        this.UIMaxOpenFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.UIMaxOpenFiles.Location = new System.Drawing.Point(187, 64);
        this.UIMaxOpenFiles.Name = "UIMaxOpenFiles";
        this.UIMaxOpenFiles.Size = new System.Drawing.Size(77, 19);
        this.UIMaxOpenFiles.TabIndex = 11;
        this.UIMaxOpenFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label8
        // 
        this.Label8.AutoSize = true;
        this.Label8.Location = new System.Drawing.Point(184, 51);
        this.Label8.Name = "Label8";
        this.Label8.Size = new System.Drawing.Size(80, 13);
        this.Label8.TabIndex = 10;
        this.Label8.Text = "Max Open Files";
        // 
        // UIDriveBits
        // 
        this.UIDriveBits.BackColor = System.Drawing.Color.White;
        this.UIDriveBits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.UIDriveBits.Location = new System.Drawing.Point(287, 64);
        this.UIDriveBits.Name = "UIDriveBits";
        this.UIDriveBits.Size = new System.Drawing.Size(55, 19);
        this.UIDriveBits.TabIndex = 13;
        this.UIDriveBits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label7
        // 
        this.Label7.AutoSize = true;
        this.Label7.Location = new System.Drawing.Point(284, 51);
        this.Label7.Name = "Label7";
        this.Label7.Size = new System.Drawing.Size(52, 13);
        this.Label7.TabIndex = 12;
        this.Label7.Text = "Drive Bits";
        // 
        // UIDisassembly
        // 
        this.UIDisassembly.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.UIDisassembly.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.UIDisassembly.Location = new System.Drawing.Point(8, 92);
        this.UIDisassembly.Multiline = true;
        this.UIDisassembly.Name = "UIDisassembly";
        this.UIDisassembly.ReadOnly = true;
        this.UIDisassembly.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.UIDisassembly.Size = new System.Drawing.Size(427, 250);
        this.UIDisassembly.TabIndex = 14;
        // 
        // BootRecordForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(447, 354);
        this.Controls.Add(this.UIDisassembly);
        this.Controls.Add(this.UIDriveBits);
        this.Controls.Add(this.Label7);
        this.Controls.Add(this.UIMaxOpenFiles);
        this.Controls.Add(this.Label8);
        this.Controls.Add(this.UIBootContinue);
        this.Controls.Add(this.Label6);
        this.Controls.Add(this.UIInitAddress);
        this.Controls.Add(this.Label4);
        this.Controls.Add(this.UILoadAddress);
        this.Controls.Add(this.Label5);
        this.Controls.Add(this.UISectorsToBoot);
        this.Controls.Add(this.Label3);
        this.Controls.Add(this.UIDosCode);
        this.Controls.Add(this.Label1);
        this.Name = "BootRecordForm";
        this.Text = "Boot Record ";
        this.Load += new System.EventHandler(this.BootRecordForm_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

	}
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label UIDosCode;
	internal System.Windows.Forms.Label UISectorsToBoot;
	internal System.Windows.Forms.Label Label3;
	internal System.Windows.Forms.Label UILoadAddress;
	internal System.Windows.Forms.Label Label5;
	internal System.Windows.Forms.Label UIInitAddress;
	internal System.Windows.Forms.Label Label4;
	internal System.Windows.Forms.Label UIBootContinue;
	internal System.Windows.Forms.Label Label6;
	internal System.Windows.Forms.Label UIMaxOpenFiles;
	internal System.Windows.Forms.Label Label8;
	internal System.Windows.Forms.Label UIDriveBits;
	internal System.Windows.Forms.Label Label7;
	internal System.Windows.Forms.TextBox UIDisassembly;
}


