/*   This file is part of Atari Disk Explorer.
     Copyright (C) 2014  Dan Boris (danlb_2000@yahoo.com)

    Atari Disk Explorer is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Atari Disk Explorer is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Atari Disk Explorer.  If not, see <http://www.gnu.org/licenses/>.
*/
public class AtasciiFileViewer : System.Windows.Forms.Form
{

#region " Windows Form Designer generated code "

	public AtasciiFileViewer()
	{
		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
	}

	//Form overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing)
	{
		if (disposing) {
			if (!(components == null)) {
				components.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	//Required by the Windows Form Designer
	private System.ComponentModel.IContainer components;
	internal System.Windows.Forms.MainMenu MainMenu1;
	internal System.Windows.Forms.MenuItem MenuItem1;
	internal System.Windows.Forms.MenuItem itmSaveAs;
    internal AtasciiView viewer;

	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.
  
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            this.MainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.MenuItem1 = new System.Windows.Forms.MenuItem();
            this.itmSaveAs = new System.Windows.Forms.MenuItem();
            this.viewer = new AtasciiView();
            this.SuspendLayout();
            // 
            // MainMenu1
            // 
            this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem1});
            // 
            // MenuItem1
            // 
            this.MenuItem1.Index = 0;
            this.MenuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.itmSaveAs});
            this.MenuItem1.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
            this.MenuItem1.Text = "&File";
            // 
            // itmSaveAs
            // 
            this.itmSaveAs.Index = 0;
            this.itmSaveAs.MergeOrder = 3;
            this.itmSaveAs.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
            this.itmSaveAs.Text = "Save ATASCII As...";
            this.itmSaveAs.Click += new System.EventHandler(this.itmSaveAs_Click);
            // 
            // viewer
            // 
            this.viewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewer.Location = new System.Drawing.Point(0, 0);
            this.viewer.Name = "viewer";
            this.viewer.Size = new System.Drawing.Size(304, 230);
            this.viewer.TabIndex = 0;
            // 
            // AtasciiFileViewer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(304, 242);
            this.Controls.Add(this.viewer);
            this.Menu = this.MainMenu1;
            this.Name = "AtasciiFileViewer";
            this.Text = "AtasciiFileViewer";
            this.Load += new System.EventHandler(this.AtasciiFileViewer_Load);
            this.ResumeLayout(false);

	}
#endregion

	private byte[] atasciiData;

	public AtasciiFileViewer(byte[] data)
	{
		InitializeComponent();
		atasciiData = data;
		viewer.Data = data;
	}

	public string Title {
		set { this.Text = value; }
	}

	private void AtasciiFileViewer_Load(System.Object sender, System.EventArgs e)
	{
		UpdateDisplay();
	}

	private void UpdateDisplay()
	{
		viewer.RefreshDisplay();
	}

	private void itmSaveAs_Click(System.Object sender, System.EventArgs e)
	{
		AtariBasic.AtasciiString text = new AtariBasic.AtasciiString(atasciiData);

		AtasciiFileSaveForm dialog = new AtasciiFileSaveForm(text);
		dialog.ShowDialog();
	}
}

