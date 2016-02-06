

partial class DiskImageProperies : System.Windows.Forms.Form
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
        this.UIPropList = new System.Windows.Forms.ListView();
        this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.SuspendLayout();
        // 
        // UIPropList
        // 
        this.UIPropList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.UIPropList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
        this.UIPropList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
        this.UIPropList.Location = new System.Drawing.Point(1, 3);
        this.UIPropList.Name = "UIPropList";
        this.UIPropList.Size = new System.Drawing.Size(288, 260);
        this.UIPropList.TabIndex = 0;
        this.UIPropList.UseCompatibleStateImageBehavior = false;
        this.UIPropList.View = System.Windows.Forms.View.Details;
        // 
        // ColumnHeader1
        // 
        this.ColumnHeader1.Text = "Property";
        this.ColumnHeader1.Width = 101;
        // 
        // ColumnHeader2
        // 
        this.ColumnHeader2.Text = "Value";
        this.ColumnHeader2.Width = 97;
        // 
        // DiskImageProperies
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(292, 266);
        this.Controls.Add(this.UIPropList);
        this.Name = "DiskImageProperies";
        this.Text = "Disk Image Properies";
        this.Load += new System.EventHandler(this.DiskImageProperies_Load);
        this.ResumeLayout(false);

	}
	internal System.Windows.Forms.ListView UIPropList;
	internal System.Windows.Forms.ColumnHeader ColumnHeader1;
	internal System.Windows.Forms.ColumnHeader ColumnHeader2;
}


