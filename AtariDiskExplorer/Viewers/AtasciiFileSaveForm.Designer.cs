

partial class AtasciiFileSaveForm : System.Windows.Forms.Form
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
        this.GroupBox1 = new System.Windows.Forms.GroupBox();
        this.UIAtasciiDecimal = new System.Windows.Forms.RadioButton();
        this.UIAtasciiHex = new System.Windows.Forms.RadioButton();
        this.UIAtasciiRaw = new System.Windows.Forms.RadioButton();
        this.GroupBox2 = new System.Windows.Forms.GroupBox();
        this.UIInverseNoDelmit = new System.Windows.Forms.RadioButton();
        this.UIInverseBraces = new System.Windows.Forms.RadioButton();
        this.UIInverseRaw = new System.Windows.Forms.RadioButton();
        this.UIFileName = new System.Windows.Forms.TextBox();
        this.UIBrowse = new System.Windows.Forms.Button();
        this.Label1 = new System.Windows.Forms.Label();
        this.UIOK = new System.Windows.Forms.Button();
        this.UICancel = new System.Windows.Forms.Button();
        this.UIConvertEOL = new System.Windows.Forms.CheckBox();
        this.GroupBox1.SuspendLayout();
        this.GroupBox2.SuspendLayout();
        this.SuspendLayout();
        // 
        // GroupBox1
        // 
        this.GroupBox1.Controls.Add(this.UIAtasciiDecimal);
        this.GroupBox1.Controls.Add(this.UIAtasciiHex);
        this.GroupBox1.Controls.Add(this.UIAtasciiRaw);
        this.GroupBox1.Location = new System.Drawing.Point(12, 13);
        this.GroupBox1.Name = "GroupBox1";
        this.GroupBox1.Size = new System.Drawing.Size(201, 100);
        this.GroupBox1.TabIndex = 0;
        this.GroupBox1.TabStop = false;
        this.GroupBox1.Text = "ATASCII Character Conversion";
        // 
        // UIAtasciiDecimal
        // 
        this.UIAtasciiDecimal.AutoSize = true;
        this.UIAtasciiDecimal.Location = new System.Drawing.Point(7, 68);
        this.UIAtasciiDecimal.Name = "UIAtasciiDecimal";
        this.UIAtasciiDecimal.Size = new System.Drawing.Size(63, 17);
        this.UIAtasciiDecimal.TabIndex = 2;
        this.UIAtasciiDecimal.TabStop = true;
        this.UIAtasciiDecimal.Text = "Decimal";
        this.UIAtasciiDecimal.UseVisualStyleBackColor = true;
        // 
        // UIAtasciiHex
        // 
        this.UIAtasciiHex.AutoSize = true;
        this.UIAtasciiHex.Location = new System.Drawing.Point(7, 44);
        this.UIAtasciiHex.Name = "UIAtasciiHex";
        this.UIAtasciiHex.Size = new System.Drawing.Size(44, 17);
        this.UIAtasciiHex.TabIndex = 1;
        this.UIAtasciiHex.TabStop = true;
        this.UIAtasciiHex.Text = "Hex";
        this.UIAtasciiHex.UseVisualStyleBackColor = true;
        // 
        // UIAtasciiRaw
        // 
        this.UIAtasciiRaw.AutoSize = true;
        this.UIAtasciiRaw.Checked = true;
        this.UIAtasciiRaw.Location = new System.Drawing.Point(7, 20);
        this.UIAtasciiRaw.Name = "UIAtasciiRaw";
        this.UIAtasciiRaw.Size = new System.Drawing.Size(47, 17);
        this.UIAtasciiRaw.TabIndex = 0;
        this.UIAtasciiRaw.TabStop = true;
        this.UIAtasciiRaw.Text = "Raw";
        this.UIAtasciiRaw.UseVisualStyleBackColor = true;
        // 
        // GroupBox2
        // 
        this.GroupBox2.Controls.Add(this.UIInverseNoDelmit);
        this.GroupBox2.Controls.Add(this.UIInverseBraces);
        this.GroupBox2.Controls.Add(this.UIInverseRaw);
        this.GroupBox2.Location = new System.Drawing.Point(219, 13);
        this.GroupBox2.Name = "GroupBox2";
        this.GroupBox2.Size = new System.Drawing.Size(190, 100);
        this.GroupBox2.TabIndex = 1;
        this.GroupBox2.TabStop = false;
        this.GroupBox2.Text = "Inverse Character Conversion";
        // 
        // UIInverseNoDelmit
        // 
        this.UIInverseNoDelmit.AutoSize = true;
        this.UIInverseNoDelmit.Location = new System.Drawing.Point(7, 67);
        this.UIInverseNoDelmit.Name = "UIInverseNoDelmit";
        this.UIInverseNoDelmit.Size = new System.Drawing.Size(73, 17);
        this.UIInverseNoDelmit.TabIndex = 5;
        this.UIInverseNoDelmit.TabStop = true;
        this.UIInverseNoDelmit.Text = "No Delimit";
        this.UIInverseNoDelmit.UseVisualStyleBackColor = true;
        // 
        // UIInverseBraces
        // 
        this.UIInverseBraces.AutoSize = true;
        this.UIInverseBraces.Location = new System.Drawing.Point(7, 43);
        this.UIInverseBraces.Name = "UIInverseBraces";
        this.UIInverseBraces.Size = new System.Drawing.Size(92, 17);
        this.UIInverseBraces.TabIndex = 4;
        this.UIInverseBraces.TabStop = true;
        this.UIInverseBraces.Text = "Delimit Braces";
        this.UIInverseBraces.UseVisualStyleBackColor = true;
        // 
        // UIInverseRaw
        // 
        this.UIInverseRaw.AutoSize = true;
        this.UIInverseRaw.Checked = true;
        this.UIInverseRaw.Location = new System.Drawing.Point(7, 19);
        this.UIInverseRaw.Name = "UIInverseRaw";
        this.UIInverseRaw.Size = new System.Drawing.Size(47, 17);
        this.UIInverseRaw.TabIndex = 3;
        this.UIInverseRaw.TabStop = true;
        this.UIInverseRaw.Text = "Raw";
        this.UIInverseRaw.UseVisualStyleBackColor = true;
        // 
        // UIFileName
        // 
        this.UIFileName.Location = new System.Drawing.Point(12, 162);
        this.UIFileName.Name = "UIFileName";
        this.UIFileName.Size = new System.Drawing.Size(374, 20);
        this.UIFileName.TabIndex = 2;
        // 
        // UIBrowse
        // 
        this.UIBrowse.Location = new System.Drawing.Point(384, 161);
        this.UIBrowse.Name = "UIBrowse";
        this.UIBrowse.Size = new System.Drawing.Size(25, 20);
        this.UIBrowse.TabIndex = 3;
        this.UIBrowse.Text = "...";
        this.UIBrowse.UseVisualStyleBackColor = true;
        this.UIBrowse.Click += new System.EventHandler(this.UIBrowse_Click);
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(12, 144);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(49, 13);
        this.Label1.TabIndex = 4;
        this.Label1.Text = "Filename";
        // 
        // UIOK
        // 
        this.UIOK.Location = new System.Drawing.Point(138, 188);
        this.UIOK.Name = "UIOK";
        this.UIOK.Size = new System.Drawing.Size(75, 23);
        this.UIOK.TabIndex = 5;
        this.UIOK.Text = "OK";
        this.UIOK.UseVisualStyleBackColor = true;
        this.UIOK.Click += new System.EventHandler(this.UIOK_Click);
        // 
        // UICancel
        // 
        this.UICancel.Location = new System.Drawing.Point(219, 188);
        this.UICancel.Name = "UICancel";
        this.UICancel.Size = new System.Drawing.Size(75, 23);
        this.UICancel.TabIndex = 6;
        this.UICancel.Text = "Cancel";
        this.UICancel.UseVisualStyleBackColor = true;
        this.UICancel.Click += new System.EventHandler(this.UICancel_Click);
        // 
        // UIConvertEOL
        // 
        this.UIConvertEOL.AutoSize = true;
        this.UIConvertEOL.Location = new System.Drawing.Point(13, 120);
        this.UIConvertEOL.Name = "UIConvertEOL";
        this.UIConvertEOL.Size = new System.Drawing.Size(122, 17);
        this.UIConvertEOL.TabIndex = 7;
        this.UIConvertEOL.Text = "Convert End Of Line";
        this.UIConvertEOL.UseVisualStyleBackColor = true;
        // 
        // AtasciiFileSaveForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(421, 228);
        this.Controls.Add(this.UIConvertEOL);
        this.Controls.Add(this.UICancel);
        this.Controls.Add(this.UIOK);
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.UIBrowse);
        this.Controls.Add(this.UIFileName);
        this.Controls.Add(this.GroupBox2);
        this.Controls.Add(this.GroupBox1);
        this.Name = "AtasciiFileSaveForm";
        this.Text = "Save ATASCII File";
        this.GroupBox1.ResumeLayout(false);
        this.GroupBox1.PerformLayout();
        this.GroupBox2.ResumeLayout(false);
        this.GroupBox2.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

	}
	internal System.Windows.Forms.GroupBox GroupBox1;
	internal System.Windows.Forms.RadioButton UIAtasciiDecimal;
	internal System.Windows.Forms.RadioButton UIAtasciiHex;
	internal System.Windows.Forms.RadioButton UIAtasciiRaw;
	internal System.Windows.Forms.GroupBox GroupBox2;
	internal System.Windows.Forms.RadioButton UIInverseNoDelmit;
	internal System.Windows.Forms.RadioButton UIInverseBraces;
	internal System.Windows.Forms.RadioButton UIInverseRaw;
	internal System.Windows.Forms.TextBox UIFileName;
	internal System.Windows.Forms.Button UIBrowse;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Button UIOK;
	internal System.Windows.Forms.Button UICancel;
	internal System.Windows.Forms.CheckBox UIConvertEOL;
}
