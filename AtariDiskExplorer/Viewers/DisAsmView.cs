
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

public class DisAsmView
{
    private int _curAddress;
    private byte[] dat;
    private int _height;
    private int _startOffset;

    private M6502DASM disasm;

    //Drawing style objects
    private SolidBrush NormalFontBrush;
    private Font NormalFont;

    //Text sizes
    private int LineHeight;
    private int AddrWidth;
    private int DataWidth;

    //Graphics objects
    private Bitmap gr;
    private Graphics g;

    public int StartOffset
    {
        get { return _startOffset; }
        set { _startOffset = value; }
    }

    public byte[] Data
    {
        set
        {
            dat = value;
            disasm = new M6502DASM(dat, _startOffset);
        }
    }

    public int DataLength
    {
        get { return dat.Length; }
    }

    public int Height
    {
        get { return _height; }
        set
        {
            _height = value;
            SetSize();
        }
    }

    public int BitmapWidth
    {
        get { return gr.Width; }
    }

    public int BitmapHeight
    {
        get { return gr.Height; }
    }

    public int StartAddress
    {
        get { return _curAddress; }
        set { _curAddress = value; }
    }

    public Bitmap bmp
    {
        get { return gr; }
    }

    public DisAsmView(byte[] data)
    {

        dat = data;

        disasm = new M6502DASM(dat, 0);

        // Setup drawing objects
        NormalFontBrush = new SolidBrush(Color.Black);
        NormalFont = new Font("Courier New", 10);

        // Setup bitmap
        gr = new System.Drawing.Bitmap(100, 100);
        g = Graphics.FromImage(gr);

        //Determine the size of the text
        SizeF size;
        size = g.MeasureString("00 ", NormalFont);

        LineHeight = (int)Math.Ceiling(size.Height);
        DataWidth = (int)Math.Ceiling(size.Width);
        size = g.MeasureString("0000:", NormalFont);
        AddrWidth = (int)Math.Ceiling(size.Width);
    }

    public void SetSize()
    {
        int width;

        //Set picture box width
        width = AddrWidth + (16 * DataWidth) + 130;

        // Re-create graphics objects
        gr = new System.Drawing.Bitmap(width, _height);
        g = Graphics.FromImage(gr);
    }

    // Redraw bitmap
    public void update()
    {
        int y;
        int lines;
        int addr;
        bool overflow = false;

        // Clear bitmap
        g.Clear(Color.LightGray);

        if (dat == null) return;


        // Determine the number of lines that will fit in the box
        lines = (int)Math.Floor((double)(_height / LineHeight));

        addr = _curAddress;
        for (y = 0; y <= lines - 1; y++)
        {

            //     g.DrawString(disasm.Disassemble(addr), NormalFont, NormalFontBrush, 0, y * LineHeight)

            // If not at the end of memory, increment address
            if ((addr <= dat.GetUpperBound(0)))
            {
            }

            else
            {
                overflow = true;
            }

            // If we are past the end of memory, then exit
            if ((overflow)) break;

        }

    }


}

