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
using System.Drawing;

public class AtasciiView : FileView
{
    private int numChars;
    private int[] _lineStart;

    protected override void DataChanged()
    {
        int lineCount = 1;

        for (int i = 0; i <= dat.GetUpperBound(0); i++)
        {
            if (dat[i] == 155) lineCount += 1;
        }

        vsAddr.Minimum = 1;
        vsAddr.Maximum = lineCount;
        vsAddr.Enabled = true;

        _lineStart = new int[lineCount];

        lineCount = 1;
        _lineStart[0] = 0;
        for (int i = 0; i <= dat.GetUpperBound(0); i++)
        {
            if (dat[i] == 155)
            {
                _lineStart[lineCount] = i;
                lineCount += 1;
            }
        }

    }

    // Redraw bitmap
    public override void RefreshDisplay()
    {
        int curLine = 0;
        int curChar = 0;
        int addr;

        // Clear bitmap
        g.Clear(System.Drawing.Color.FromArgb(28, 113, 198));

        if (dat == null) return;

        addr = _lineStart[vsAddr.Value - 1];

        while (addr < dat.GetUpperBound(0))
        {

            //Display ATASCII character
            if (dat[addr] != 155)
            {
                g.DrawImageUnscaled(chrs[dat[addr]], new Point(curChar * 8, curLine * 8));
                curChar += 1;
            }
            else
            {
                curChar = 0;
                curLine += 1;
                if (curLine > numLines) break;

            }

            if (curChar > numChars)
            {
                curChar = 0;
                curLine += 1;
                if (curLine > numLines) break;

            }
            addr += 1;
        }
        pbDisplay.Refresh();

    }

    public override void ResizeDisplay()
    {
        base.ResizeDisplay();

        if (pbDisplay.Width == 0 | pbDisplay.Height == 0) return;

        lineHeight = 8;

        // Determine the number of lines that will fit in the box
        numLines = (int)Math.Floor((decimal)(pbDisplay.Height / lineHeight));
        numChars = (int)Math.Floor((decimal)(pbDisplay.Width / 8)) - 1;

        RefreshDisplay();
    }


    private void InitializeComponent()
    {
        this.SuspendLayout();
        this.Name = "AtasciiView";
        this.ResumeLayout(false);
    }
}

