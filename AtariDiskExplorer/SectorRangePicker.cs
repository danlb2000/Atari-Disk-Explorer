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

using System;
using System.Windows.Forms;

namespace AtariDiskExplorer
{
    public partial class SectorRangePicker : Form
    {
        public int StartSector { get; set; }
        public int EndSector { get; set; }

        public SectorRangePicker(int startSector, int endSector)
        {
            InitializeComponent();
            UIStartSector.Text = startSector.ToString();
            UIEndSector.Text = endSector.ToString();
        }

        private void SectorRangePicker_Load(object sender, EventArgs e)
        {
        }

        private void UIOk_Click(object sender, EventArgs e)
        {
            int i;

            if (int.TryParse(UIStartSector.Text, out i))
            {
                StartSector = i;
            }

            if (int.TryParse(UIEndSector.Text, out i))
            {
                EndSector = i;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UICancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
