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

using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

public class RecentFilesHandler
{

    private int _maxFiles = 5;

    public delegate void FileClick(System.Object sender, System.EventArgs e);

    public int MaxFiles
    {
        get { return _maxFiles; }
        set { _maxFiles = value; }
    }

    /// <summary>
    /// Get list of recent files from app settings
    /// </summary>
    /// <returns>Arraylist of files</returns>
    private ArrayList GetFileList()
    {
        ArrayList ar = new ArrayList();

        if (AtariDiskExplorer.Properties.Settings.Default.RecentFiles == "") return ar;
        string[] files = AtariDiskExplorer.Properties.Settings.Default.RecentFiles.Split(',');
        for (int i = 0; i <= files.GetUpperBound(0); i++)
        {
            ar.Add(files[i]);
        }

        return ar;
    }

    private void SaveFileList(ArrayList FileList)
    {
        StringBuilder s = new StringBuilder();
        foreach (string file in FileList)
        {
            s.Append(file);
            s.Append(",");
        }
        AtariDiskExplorer.Properties.Settings.Default.RecentFiles = s.ToString().TrimEnd(',');
        AtariDiskExplorer.Properties.Settings.Default.Save();
    }

    public void AddFile(string Filename)
    {
        ArrayList ar = GetFileList();
        if (ar.Count == MaxFiles) ar.RemoveAt(_maxFiles - 1);
        int i = ar.IndexOf(Filename);
        if (i > -1) ar.RemoveAt(i);
        ar.Insert(0, Filename);
        SaveFileList(ar);
    }

    public void Deletefile(string filename)
    {
        ArrayList ar = GetFileList();
        int i = ar.IndexOf(filename);
        if (i >= 0) ar.RemoveAt(i);
        SaveFileList(ar);
    }

    public List<MenuItem> GetMenuItems()
    {
        MenuItem mi;
        List<MenuItem> items = new List<MenuItem>();
        ArrayList files = GetFileList();
        int count = 1;

        foreach (string file in files)
        {
            mi = new MenuItem();
            if (file == "") continue;
            mi.Text = string.Format("{0}. {1}", count, file);
            mi.Name = "recentFile" + count.ToString();
            mi.Tag = file;
            items.Add(mi);
            count += 1;
        }

        return items;
    }

    public void UpdateMenuItems(Menu.MenuItemCollection Menu, System.EventHandler ClickFunction)
    {
        for (int i = 1; i <= 5; i++)
        {
            Menu.RemoveByKey("recentFile" + i.ToString());
        }

        List<MenuItem> items = GetMenuItems();

        foreach (MenuItem mi in items)
        {
            mi.Click += ClickFunction;
            Menu.Add(mi);
        }
    }
}

