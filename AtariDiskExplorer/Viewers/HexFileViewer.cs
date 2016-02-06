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

public class HexFileViewer : System.Windows.Forms.Form
{

#region "Windows Form Designer generated code "

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
	private System.ComponentModel.IContainer components = null;

	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.

	internal HexView viewer;
   
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.viewer = new HexView();
		this.SuspendLayout();
		//
		//viewer
		//
		this.viewer.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
		this.viewer.Location = new System.Drawing.Point(0, 0);
		this.viewer.Name = "viewer";
		this.viewer.Size = new System.Drawing.Size(472, 312);
		this.viewer.TabIndex = 0;
		//
		//HexFileViewer
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(472, 310);
		this.Controls.Add(this.viewer);
		this.Name = "HexFileViewer";
		this.Text = "File Viewer";
		this.ResumeLayout(false);

	}
#endregion

	public HexFileViewer(byte[] data)
	{
		InitializeComponent();
		viewer.Data = data;
	}

	public string Title {
		set { this.Text = value; }
	}

	private void HexViewer_Load(System.Object sender, System.EventArgs e)
	{
		UpdateDisplay();
	}

	private void UpdateDisplay()
	{
		viewer.RefreshDisplay();
	}



}

