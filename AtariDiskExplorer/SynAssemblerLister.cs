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

using AtariBasic;
using System;

namespace AtariDiskExplorer
{
    public class SynAssemblerLister 
    {
        private byte[] rawdata;

        private bool asciiLineBreak = true;

        private string lineBreak = "\n\r";
        private AtasciiString program;


        public SynAssemblerLister(byte[] data)
        {

            program = new AtasciiString();
            rawdata = data;
        }

        public AtasciiString Program
        {
            get { return program; }
        }


        public bool AsciiLineBreak
        {
            get { return asciiLineBreak; }
            set
            {
                asciiLineBreak = value;
                if (value)
                {
                    lineBreak = "\n";
                }
                else
                {
                    char lb = (char)155;
                    lineBreak = lb.ToString();
                }

            }
        }

        public void DecodeProgram()
        {
            int pos;

            pos = 6;
            while (pos < rawdata.Length)
            {
                pos += 1; // Skip line length
                int lineNum = rawdata[pos + 1] * 256 + rawdata[pos];
                program.Append(string.Format("{0:000000} ", lineNum));
                pos += 2;
                do
                {
                    byte c = rawdata[pos++];
                    if (c == 0) break;
                    if (c == 0x81) c = 32;
                    program.Append(new string((Char)c, 1));
                } while (pos < rawdata.Length);
                program.Append(lineBreak);
            }
        }

       
    }
}
