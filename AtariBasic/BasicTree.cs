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
using System.Collections.Generic;

namespace AtariBasic
{
    public class BasicTree : IBasicCommand
    {
        public List<BasicLine> Lines = new List<BasicLine>();
        protected byte[] rawdata;

        protected int LOMEM;
        protected int DVNT;
        protected int VNTE;
        protected int DVVT;
        protected int DST;
        protected int DEND;
        protected int STMCUR;

        public AtasciiString List()
        {
            AtasciiString list = new AtasciiString();
            foreach (BasicLine line in Lines)
            {
                list.Append(line.List());
                list.Append("\r\n");
            }
            return list;
        }

        public BasicTree(byte[] data)
        {
            rawdata = data;
        }

        public static ushort LSBMSB(byte[] data, int pos)
        {
            return ((ushort)((data[pos + 1] * 256) + data[pos]));
        }

        protected void DecodeHeader(byte[] data)
        {
            LOMEM = LSBMSB(data, 0);
            DVNT = LSBMSB(data, 2);
            VNTE = LSBMSB(data, 4);
            DVVT = LSBMSB(data, 6);
            DST = LSBMSB(data, 8);
            STMCUR = LSBMSB(data, 10);
            DEND = LSBMSB(data, 12);

            // Correct pointer position
            int COR = DVNT - LOMEM - 0x0E;
            DVNT -= COR;
            VNTE -= COR;
            DVVT -= COR;
            DST -= COR;
            STMCUR -= COR;
            DEND -= COR;
        }

        public void Parse()
        {
            int lineLen;
            BasicLine line;
            int pos;

            DecodeHeader(rawdata);

            pos = DST;
            while (pos < DEND)
            {
                lineLen = rawdata[pos + 2];
                byte[] lineData = new byte[lineLen];
                Array.ConstrainedCopy(rawdata, pos, lineData, 0, lineLen);
                line = new BasicLine();
                line.Parse(lineData);
                Lines.Add(line);
                pos = pos + lineLen;
            }
        }
    }
}
