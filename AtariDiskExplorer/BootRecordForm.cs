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

using AtariDisk.DiskImage;

public partial class BootRecordForm
{
    private AbstractDiskImage lDisk;
    private int sectorsToBoot;
    private int loadAddress;

    public string Title
    {
        set { this.Text = value; }
    }

    public BootRecordForm(AbstractDiskImage Disk)
    {
        InitializeComponent();
        lDisk = Disk;
    }

    private void BootRecordForm_Load(System.Object sender, System.EventArgs e)
    {
        ShowDisk();
        ShowDisassembly();
    }

    private void ShowDisassembly()
    {
        byte[] data = new byte[lDisk.SectorSize * sectorsToBoot];
        byte[] sec;

        for (int i = 0; i <= sectorsToBoot - 1; i++)
        {
            sec = lDisk.ReadSector(i + 1);
            sec.CopyTo(data, i * lDisk.SectorSize);
        }

        M6502DASM disasm = new M6502DASM(data, loadAddress - 3);
        UIDisassembly.Text = disasm.Disassemble();
    }

    private void ShowDisk()
    {
        byte[] sec;

        sec = lDisk.ReadSector(1);
        UIDosCode.Text = sec[0].ToString();
        sectorsToBoot = sec[1];
        UISectorsToBoot.Text = sectorsToBoot.ToString();
        loadAddress = sec[3] * 256 + sec[1];
        UILoadAddress.Text = "$" + loadAddress.ToString("X");
        UIInitAddress.Text = "$" + (sec[5] * 256 + sec[4]).ToString("X");
        UIBootContinue.Text = "$" + sec[6].ToString("X") + ", ";
        UIBootContinue.Text += "$" + sec[7].ToString("X") + ", ";
        UIBootContinue.Text += "$" + sec.ToString();
        UIMaxOpenFiles.Text = sec[9].ToString();
        UIDriveBits.Text = sec[10].ToString();
    }

}