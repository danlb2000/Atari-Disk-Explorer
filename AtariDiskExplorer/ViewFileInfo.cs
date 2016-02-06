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

using AtariDisk.FileSystems;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AtariDiskExplorer
{
    public partial class ViewFileInfo : Form
    {
        public FileInfo Info { get; set; }


        public ViewFileInfo()
        {
            InitializeComponent();
        }

        public void ShowInfo()
        {
            if (Info == null) return;
            UIFileName.Text = Info.DirEntry.FileName;
            UIFileNumber.Text = Info.DirEntry.FileNumber.ToString();
            UINumberOfSectors.Text = Info.DirEntry.NumSectors.ToString();
            UIStartSector.Text = Info.DirEntry.StartSector.ToString();
            UIFileSectors.DataSource = Info.SectorList;

            List<string> errors = new List<string>();
            foreach (string s in Info.FileErrors)
            {
                errors.Add(s);
            }
            foreach (var err in Info.DirEntry.ErrorList)
            {
                switch (err)
                {
                    case DirectoryEntry.EntryError.FileNameInvalidCharacters:
                        errors.Add("Filename has invalid characters.");
                        break;
                    case DirectoryEntry.EntryError.InvalidNumberOfSectors:
                        errors.Add("Invalid number of sectors.");
                        break;
                    case DirectoryEntry.EntryError.InvalidStartSector:
                        errors.Add("Invalid start sector.");
                        break;
                }
            }

            UIErrorList.DataSource = errors;
            UIIsValid.Checked = Info.IsValid;
        }

        private void ViewFileInfo_Load(object sender, EventArgs e)
        {
            ShowInfo();
        }
    }
}
