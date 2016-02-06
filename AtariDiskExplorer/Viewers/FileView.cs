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

using System.Drawing;
using System.IO;
using System.Reflection;

public class FileView : System.Windows.Forms.UserControl
{
#region " Windows Form Designer generated code "

	//UserControl overrides dispose to clean up the component list.
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
	internal System.Windows.Forms.PictureBox pbDisplay;
	internal System.Windows.Forms.VScrollBar vsAddr;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
        this.pbDisplay = new System.Windows.Forms.PictureBox();
        this.vsAddr = new System.Windows.Forms.VScrollBar();
        ((System.ComponentModel.ISupportInitialize)(this.pbDisplay)).BeginInit();
        this.SuspendLayout();
        // 
        // pbDisplay
        // 
        this.pbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.pbDisplay.Location = new System.Drawing.Point(0, 0);
        this.pbDisplay.Name = "pbDisplay";
        this.pbDisplay.Size = new System.Drawing.Size(285, 272);
        this.pbDisplay.TabIndex = 0;
        this.pbDisplay.TabStop = false;
        this.pbDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pbDisplay_Paint);
        // 
        // vsAddr
        // 
        this.vsAddr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.vsAddr.Enabled = false;
        this.vsAddr.Location = new System.Drawing.Point(288, 0);
        this.vsAddr.Name = "vsAddr";
        this.vsAddr.Size = new System.Drawing.Size(16, 272);
        this.vsAddr.TabIndex = 1;
        this.vsAddr.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsAddr_Scroll);
        // 
        // FileView
        // 
        this.Controls.Add(this.vsAddr);
        this.Controls.Add(this.pbDisplay);
        this.Name = "FileView";
        this.Size = new System.Drawing.Size(304, 272);
        this.Resize += new System.EventHandler(this.FileView_Resize);
        ((System.ComponentModel.ISupportInitialize)(this.pbDisplay)).EndInit();
        this.ResumeLayout(false);

	}
#endregion

	//Graphics objects
	private Bitmap gr;
	protected Graphics g;
	protected Bitmap[] chrs = new Bitmap[256];

	//Text sizes
	protected int lineHeight;
	protected int numLines;
	protected byte[] dat;

	public byte[] Data {
		set {
			dat = value;
			DataChanged();
			ResizeDisplay();
		}
	}

	public FileView()
	{
		InitializeComponent();

        dat = new byte[256];

		for (int i = 0; i <= 255; i++) {
			dat[i] = (byte)i;
		}
      
		DataChanged();

		//Read character set image
		Assembly myAssembly = this.GetType().Assembly;
		AssemblyName name = myAssembly.GetName();
		Stream picture_stream;
		picture_stream = myAssembly.GetManifestResourceStream(name.Name + ".cset.bmp");

		//Copy characters to individual bitmaps to speed rendering
		if (!(picture_stream == null)) {
			Bitmap grCset;
			Graphics g;
			int cx;
			int cy;

			grCset = new Bitmap(picture_stream);
			for (int i = 0; i <= 255; i++) {
				chrs[i] = new Bitmap(8, 8);
				g = Graphics.FromImage(chrs[i]);

				cy = (int)System.Math.Floor((double)(i / 16));
				cx = i - (cy * 16);

				g.DrawImage(grCset, 0, 0, new Rectangle(cx * 8, cy * 8, 8, 8), GraphicsUnit.Pixel);
			}
		}

		ResizeDisplay();
	}

	public virtual void ResizeDisplay()
	{
		if (pbDisplay.Width == 0 | pbDisplay.Height == 0) return;
 
		// Setup bitmap
		gr = new System.Drawing.Bitmap(pbDisplay.Width, pbDisplay.Height);
		g = Graphics.FromImage(gr);
	}

	// Redraw bitmap
	public virtual void RefreshDisplay()
	{

	}

	private void FileView_Resize(object sender, System.EventArgs e)
	{
		ResizeDisplay();
	}

	private void pbDisplay_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
	{
		if (gr == null) return;
 
		e.Graphics.DrawImage(gr, 0, 0);
	}

	private void  vsAddr_Scroll(System.Object sender, System.Windows.Forms.ScrollEventArgs e)
	{
		RefreshDisplay();
	}

	protected virtual void DataChanged()
	{
	}

}
