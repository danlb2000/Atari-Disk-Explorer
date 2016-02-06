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

using System;
using System.IO;
using System.Windows.Forms;

public class MainForm : System.Windows.Forms.Form
{

#region " Windows Form Designer generated code "

	public MainForm()
	{
		//This call is required by the Windows Form Designer.
		InitializeComponent();
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

	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.
	internal System.Windows.Forms.MainMenu MainMenu1;
	internal System.Windows.Forms.MenuItem FileMenu;
	internal System.Windows.Forms.MenuItem itmOpenDisk;
	internal System.Windows.Forms.MenuItem MenuItem2;
	internal System.Windows.Forms.MenuItem itmCascade;
	internal System.Windows.Forms.MenuItem itmTileHorizontal;
	internal System.Windows.Forms.MenuItem itmExit;
	internal System.Windows.Forms.MenuItem itmRecentFiles;
    internal System.Windows.Forms.MenuItem itmCreateImage;
    private MenuItem menuItem1;
    private MenuItem itmAbout;
	internal System.Windows.Forms.MenuItem itmTileVertical;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            this.MainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.FileMenu = new System.Windows.Forms.MenuItem();
            this.itmOpenDisk = new System.Windows.Forms.MenuItem();
            this.itmCreateImage = new System.Windows.Forms.MenuItem();
            this.itmRecentFiles = new System.Windows.Forms.MenuItem();
            this.itmExit = new System.Windows.Forms.MenuItem();
            this.MenuItem2 = new System.Windows.Forms.MenuItem();
            this.itmCascade = new System.Windows.Forms.MenuItem();
            this.itmTileHorizontal = new System.Windows.Forms.MenuItem();
            this.itmTileVertical = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.itmAbout = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // MainMenu1
            // 
            this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.FileMenu,
            this.MenuItem2,
            this.menuItem1});
            // 
            // FileMenu
            // 
            this.FileMenu.Index = 0;
            this.FileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.itmOpenDisk,
            this.itmCreateImage,
            this.itmRecentFiles,
            this.itmExit});
            this.FileMenu.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
            this.FileMenu.Text = "&File";
            // 
            // itmOpenDisk
            // 
            this.itmOpenDisk.Index = 0;
            this.itmOpenDisk.Text = "&Open Disk Image...";
            this.itmOpenDisk.Click += new System.EventHandler(this.itmOpenDisk_Click);
            // 
            // itmCreateImage
            // 
            this.itmCreateImage.Index = 1;
            this.itmCreateImage.MergeOrder = 1;
            this.itmCreateImage.Text = "&Create Disk Image...";
            this.itmCreateImage.Click += new System.EventHandler(this.itmCreateImage_Click);
            // 
            // itmRecentFiles
            // 
            this.itmRecentFiles.Index = 2;
            this.itmRecentFiles.MergeOrder = 2;
            this.itmRecentFiles.Text = "&Recent Files";
            // 
            // itmExit
            // 
            this.itmExit.Index = 3;
            this.itmExit.MergeOrder = 10;
            this.itmExit.Text = "&Exit";
            this.itmExit.Click += new System.EventHandler(this.itmExit_Click);
            // 
            // MenuItem2
            // 
            this.MenuItem2.Index = 1;
            this.MenuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.itmCascade,
            this.itmTileHorizontal,
            this.itmTileVertical});
            this.MenuItem2.MergeOrder = 10;
            this.MenuItem2.Text = "&Window";
            // 
            // itmCascade
            // 
            this.itmCascade.Index = 0;
            this.itmCascade.Text = "&Cascade";
            this.itmCascade.Click += new System.EventHandler(this.itmCascade_Click);
            // 
            // itmTileHorizontal
            // 
            this.itmTileHorizontal.Index = 1;
            this.itmTileHorizontal.Text = "Tile &Horizontal";
            this.itmTileHorizontal.Click += new System.EventHandler(this.itmTileHorizontal_Click);
            // 
            // itmTileVertical
            // 
            this.itmTileVertical.Index = 2;
            this.itmTileVertical.Text = "Tile &Vertical";
            this.itmTileVertical.Click += new System.EventHandler(this.itmTileVertical_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.itmAbout});
            this.menuItem1.MergeOrder = 11;
            this.menuItem1.Text = "&Help";
            // 
            // itmAbout
            // 
            this.itmAbout.Index = 0;
            this.itmAbout.Text = "&About";
            this.itmAbout.Click += new System.EventHandler(this.itmAbout_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1140, 687);
            this.IsMdiContainer = true;
            this.Menu = this.MainMenu1;
            this.Name = "MainForm";
            this.Text = "Atari Disk Explorer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

	}
#endregion

	private readonly RecentFilesHandler RecentFiles = new RecentFilesHandler();

	private void MainForm_Load(System.Object sender, System.EventArgs e)
	{
		UpdateRecentFiles();
	}

    #region "Handle menu commands"
    private void itmCascade_Click(System.Object sender, System.EventArgs e)
    {
        this.LayoutMdi(MdiLayout.Cascade);
    }

    private void itmTileHorizontal_Click(System.Object sender, System.EventArgs e)
    {
        this.LayoutMdi(MdiLayout.TileHorizontal);
    }

    private void itmTileVertical_Click(System.Object sender, System.EventArgs e)
    {
        this.LayoutMdi(MdiLayout.TileVertical);
    }

    private void itmExit_Click(System.Object sender, System.EventArgs e)
    {
        System.Environment.Exit(0);
    }

    private void itmCreateImage_Click(System.Object sender, System.EventArgs e)
    {
        NewDiskImageForm form = new NewDiskImageForm();
        form.ShowDialog();
    }

    private void itmAbout_Click_1(object sender, EventArgs e)
    {
        var about = new AtariDiskExplorer.AboutBox();
        about.ShowDialog();
    }


	private void RecentFile_Click(System.Object sender, System.EventArgs e)
	{
		MenuItem mi = (MenuItem)sender;
		OpenDiskImage((string)mi.Tag);
	}

	private void itmOpenDisk_Click(System.Object sender, System.EventArgs e)
	{
		OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filter = "XFD Image (*.xfd)|*.xfd|ATR Image (*.atr)|*.atr|All files (*.*)|*.*";
        dialog.FilterIndex = 2;

		if (dialog.ShowDialog() == DialogResult.OK) {
			RecentFiles.AddFile(dialog.FileName);
            try
            {
                OpenDiskImage(dialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open disk image. " + ex.Message,"Image open error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
		}
	}
#endregion

	private void OpenDiskImage(string filename)
	{
        if (!File.Exists(filename))
        {
            var result = MessageBox.Show("File " + filename + " could not be found. Do you want to remove it from the list?", "File Not Found", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                RecentFiles.Deletefile(filename);
                UpdateRecentFiles();
            }
            return;
        }
		DirExplorer de;
		de = new DirExplorer(filename);

		UpdateRecentFiles();
		de.MdiParent = this;
		de.Show();
	}

    private void UpdateRecentFiles()
    {
        RecentFiles.UpdateMenuItems(itmRecentFiles.MenuItems, RecentFile_Click);
        if (itmRecentFiles.MenuItems.Count == 0)
        {
            itmRecentFiles.Enabled = false;
        }
        else
        {
            itmRecentFiles.Enabled = true;
        }
    }

}

