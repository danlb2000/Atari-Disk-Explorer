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

using AtariDisk.FileSystems;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AtariDiskExplorer
{
    public partial class ViewSectorMap : Form
    {
        public FileSystem FileSystem { get; set; }
        public string ImageFileName { get; set; }

        private Bitmap bmp;
        private Graphics gr;
        private List<int> fileSectorList;
        private AtariDisk.FileSystems.FileInfo selectedFileInfo = null;

        public const int BOXSIZE = 15;

        public ViewSectorMap()
        {
            InitializeComponent();
            fileSectorList = null;
        }

        private void ViewSectorMap_Load(object sender, EventArgs e)
        {
            ResizeDisplay();
            UpdateFileList();
            UpdateMap();
            this.Text = ImageFileName;
        }

        public virtual void ResizeDisplay()
        {
            if (UIMap.Width == 0 | UIMap.Height == 0) return;

            // Setup bitmap
            bmp = new System.Drawing.Bitmap(UIMap.Width, UIMap.Height);
            gr = Graphics.FromImage(bmp);

            int sectorsPerLine = UIMap.Width / BOXSIZE;
            if (sectorsPerLine <= 0) sectorsPerLine = 1;
            UIMapScroll.Maximum = FileSystem.Map.NumberOfSectorsInMap() / sectorsPerLine;
            UIMapScroll.Minimum = 1;
            if (UIMapScroll.Value > UIMapScroll.Maximum) UIMapScroll.Value = UIMapScroll.Maximum;
        }

        private void UpdateFileList()
        {
            UIFiles.Items.Clear();
            foreach (DirectoryEntry de in FileSystem.DiskDirectory())
            {
                if (de.EntryInUse) UIFiles.Items.Add(de.FileName);
            }
        }

        public void UpdateMap()
        {
            if (FileSystem == null) return;

            gr.Clear(Color.White);

            int x = 0, y = 0;
            int sector = (UIMapScroll.Value - 1) * (UIMap.Width / BOXSIZE) + 1;

            while (sector <= FileSystem.Map.NumberOfSectorsInMap())
            {
                var borderBrush = new SolidBrush(Color.Black);
                var fillBrush = GetSectorBrush(sector);

                gr.FillRectangle(fillBrush, x, y, BOXSIZE, BOXSIZE);
                gr.DrawRectangle(new Pen(Color.Black, 1), x, y, BOXSIZE, BOXSIZE);

                x += BOXSIZE;
                if (x > UIMap.Width - BOXSIZE)
                {
                    x = 0;
                    y += BOXSIZE;
                }
                sector += 1;
            }

            if (UIShowSectorLinks.Checked) DrawConnectors();

            this.Refresh();
        }

        private void DrawConnectors()
        {
            if (selectedFileInfo == null) return;

            var linePen = new Pen(Color.Yellow, 2);
;

            foreach (var sec in selectedFileInfo.SectorList)
            {
                var curSectorPoint = GetSectorLocation(sec.Sector);
                var nextSectorPoint = GetSectorLocation(sec.NextSector);

                if (sec.NextSector != 0)
                {
                    gr.DrawLine(linePen, curSectorPoint.X + BOXSIZE / 2,
                                        curSectorPoint.Y + BOXSIZE / 2,
                                        nextSectorPoint.X + BOXSIZE / 2,
                                        nextSectorPoint.Y + BOXSIZE / 2);

                    DrawArrowHead(linePen, new Point(nextSectorPoint.X + BOXSIZE / 2, nextSectorPoint.Y + BOXSIZE / 2));

                }
            }
        }

        private void DrawArrowHead(Pen pen, Point point)
        {
            gr.DrawLine(pen, point.X, point.Y, point.X - 5, point.Y - 5);
            gr.DrawLine(pen, point.X, point.Y, point.X - 5, point.Y + 5);
            gr.DrawLine(pen, point.X - 5, point.Y - 5, point.X - 5, point.Y + 5);

        }

        private Point GetSectorLocation(int sector)
        {
            var point = new Point();
            int sectorsPerLine = UIMap.Width / BOXSIZE;
            int firstShownSector = (UIMapScroll.Value - 1) * (UIMap.Width / BOXSIZE) - 1;
            sector -= firstShownSector;

            point.Y = (sector - 1) / sectorsPerLine;
            point.X = (sector - 1) - point.Y * sectorsPerLine;

            point.Y = point.Y * BOXSIZE;
            point.X = point.X * BOXSIZE;

            return point;
        }

        private Brush GetSectorBrush(int sector)
        {
            Brush fillBrush = new SolidBrush(Color.White);

            switch (FileSystem.Map[sector])
            {
                case SectorMap.SectorTypes.System:
                    fillBrush = new SolidBrush(Color.Black);
                    break;
                case SectorMap.SectorTypes.Used:
                    fillBrush = new SolidBrush(Color.FromArgb(0x80, 0x80, 0x80));
                    break;
                case SectorMap.SectorTypes.Unusable:
                    fillBrush = new SolidBrush(Color.Chocolate);
                    break;
            }

            if (fileSectorList != null)
            {
                if (fileSectorList.Contains(sector))
                {
                    fillBrush = new SolidBrush(Color.Blue);
                }
            }

            return fillBrush;
        }

        private void UIMap_Paint(object sender, PaintEventArgs e)
        {
            if (bmp == null) return;

            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void UIFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fileName = (string)UIFiles.SelectedItem;
            if (string.IsNullOrEmpty(fileName)) return;

            selectedFileInfo = FileSystem.GetFileInfo(fileName);

            fileSectorList = new List<int>();
            foreach (var sec in selectedFileInfo.SectorList)
            {
                fileSectorList.Add(sec.Sector);
            }

            UpdateMap();
        }

        private void UIMap_Resize(object sender, EventArgs e)
        {
            ResizeDisplay();
            UpdateMap();
        }

        private void UIShowSectorLinks_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMap();
        }

        private void UIMapScroll_ValueChanged(object sender, EventArgs e)
        {
            UpdateMap(); 
        }

        private void UIMap_MouseMove(object sender, MouseEventArgs e)
        {
            int sectorsPerLine = UIMap.Width / BOXSIZE;
            int firstShownSector = (UIMapScroll.Value - 1) * sectorsPerLine;
            int sector = (e.Y / BOXSIZE) * sectorsPerLine + (e.X / BOXSIZE);
            sector += firstShownSector + 1;
            UICurrentSectorNumber.Text = sector.ToString();
        }

     

    }
}
