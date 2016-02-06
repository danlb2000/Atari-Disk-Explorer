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

public class HexView : FileView
{

	// Drawing style objects
	private SolidBrush NormalFontBrush;
	private Font NormalFont;

	private int charColumn;
	private int addrWidth;
	private int dataWidth;
	private int numBytes;
	private int curAddress;

	public HexView()
	{
		// Setup drawing objects
		NormalFontBrush = new SolidBrush(Color.Black);
		NormalFont = new Font("Courier New", 10);
        vsAddr.ValueChanged += this.VsAddr_ValueChanged;
	}

	private void  VsAddr_ValueChanged(object sender, System.EventArgs e)
	{
		curAddress = vsAddr.Value * numBytes;
		RefreshDisplay();
	}

	// Redraw bitmap
	public override void RefreshDisplay()
	{
		int x;
		int y;
		int xp;
		string s;
		int addr;
		bool overflow = false;

		// Clear bitmap
		g.Clear(Color.LightGray);

		if (dat == null | NormalFont == null) return;
 
		if (dat.Length == 0) return;
 
		//Determine position of ATASCII display
		charColumn = addrWidth + (dataWidth * numBytes) + 2;

		addr = curAddress;
		for (y = 0; y <= numLines - 1; y++) {
			// Format and display address
			s = string.Format("{0:X4}:", addr);
			g.DrawString(s, NormalFont, NormalFontBrush, 0, y * lineHeight);

			// Starting position of data
			xp = (int)g.MeasureString(s, NormalFont).Width;

			// Display data
			for (x = 0; x <= numBytes - 1; x++) {
				//Format and display data
				s = string.Format("{0:X2} ",dat[addr]);
				g.DrawString(s, NormalFont, NormalFontBrush, xp, y * lineHeight);
				xp = xp + dataWidth;

				//Display ATASCII character
				g.DrawImageUnscaled(chrs[dat[addr]], new Point(charColumn + (x * 8), y * lineHeight + 5));

				// If not at the end of memory, increment address
				if ((addr != dat.GetUpperBound(0))) {
					addr += 1;
				}
				else {
					overflow = true;
				}

				// If we are past the end of memory, then exit
				if (overflow) break; // TODO: might not be correct. Was : Exit For
 
			}
			if ((overflow)) break; // TODO: might not be correct. Was : Exit For
 
		}
		pbDisplay.Refresh();
	}

	public override void ResizeDisplay()
	{
		base.ResizeDisplay();

		if (pbDisplay.Width == 0 | pbDisplay.Height == 0 | NormalFont == null) return;
 

		//Determine the size of the text
		SizeF size;
		size = g.MeasureString("00 ", NormalFont);
		dataWidth = (int)Math.Ceiling(size.Width);
		size = g.MeasureString("0000:", NormalFont);
        addrWidth = (int)Math.Ceiling(size.Width);

        lineHeight = (int)Math.Ceiling(size.Height);

		// Determine the number of lines that will fit in the box
        numLines = (int)Math.Floor((decimal)(pbDisplay.Height / lineHeight));
        numBytes = (int)Math.Floor((decimal)((pbDisplay.Width - addrWidth - 2) / (dataWidth + 8)));

		//Adjust slider
		if (dat != null) {
            int dataLines = (int)Math.Floor((decimal)(dat.Length / numBytes));
			if (dataLines > numLines) {
				vsAddr.Maximum = dataLines;
				vsAddr.Enabled = true;
			}
			else {
				vsAddr.Enabled = false;
			}
		}

		RefreshDisplay();
	}

	private void InitializeComponent()
	{
		//
		//HexView
		//
		this.Name = "HexView";

	}
}
