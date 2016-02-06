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
using System.Collections;
using System.Windows.Forms;

public partial class DiskImageProperies
{
    private AbstractDiskImage _disk;

    public DiskImageProperies(AbstractDiskImage Disk)
    {
        this.InitializeComponent();
        _disk = Disk;
    }

    public string Title
    {
        set { this.Text = value; }
    }

    private void DiskImageProperies_Load(System.Object sender, System.EventArgs e)
    {
        Hashtable props = _disk.Properties();
        ListViewItem li;

        foreach (DictionaryEntry de in props)
        {
            li = new ListViewItem((string)de.Key);
            li.SubItems.Add(string.Format("{0}", de.Value));
            UIPropList.Items.Add(li);
        }
    }
}
