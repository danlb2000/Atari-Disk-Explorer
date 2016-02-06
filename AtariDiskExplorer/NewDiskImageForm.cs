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
*/

using AtariDisk.DiskImage;
using AtariDisk.FileSystems;
using System;
using System.Windows.Forms;

public partial class NewDiskImageForm
{

    private string _filename;

    public string FileName
    {
        get { return _filename; }
    }

    public NewDiskImageForm()
    {
        InitializeComponent();
    }

    private void NewDiskImageForm_Load(System.Object sender, System.EventArgs e)
    {
        UISectorSize.SelectedText = "128";
    }

    private void UIBrowse_Click(System.Object sender, System.EventArgs e)
    {
        SaveFileDialog dialog = new SaveFileDialog();
        dialog.Filter = ".ATR|*.ATR|.XFD|*.XFD";
        if (dialog.ShowDialog() != DialogResult.OK) return;

        UIFilename.Text = dialog.FileName;
    }

    private void UIOK_Click(System.Object sender, System.EventArgs e)
    {
        int sectors;
        _filename = UIFilename.Text.Trim();

        if (_filename == "") return;


        if (!int.TryParse(UISectors.Text, out sectors))
        {

            MessageBox.Show("Number of sectors must be numeric", "Create Disk", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        sectors = Math.Abs(sectors);

        AbstractDiskImage diskImage;
        try
        {
            diskImage = DiskImageFactory.NewDiskImage(UIFilename.Text);
        }
        catch
        {
            MessageBox.Show("Unknown disk image format", "Create Disk", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        int sectorSize = int.Parse(UISectorSize.Text);
        diskImage.CreateImage(UIFilename.Text, sectors, sectorSize);

   
         var fileSystem = FileSystemFactory.MakeFileSystem((string)UIFileSystem.SelectedItem, diskImage);
          fileSystem.Format(false);            
  

        this.Close();
    }

    private void UIFileSystem_SelectedIndexChanged(object sender, EventArgs e)
    {
        var fileSystem = FileSystemFactory.MakeFileSystem((string)UIFileSystem.SelectedItem, null);
        UISectors.Text = (fileSystem.TotalSectors).ToString();
        UISectorSize.Items.Clear();
        foreach (int size in fileSystem.AllowedSectorSizes)
        {
            UISectorSize.Items.Add(size.ToString());
        }

        UISectorSize.SelectedIndex = 0;
        UISectorSize.Enabled = true;
        if (UISectorSize.Items.Count <= 1) UISectorSize.Enabled = false;
    }

    private void UICancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
