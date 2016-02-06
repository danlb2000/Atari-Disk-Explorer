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

using AtariDisk;
using System.IO;
using System.Text;

public class Disassembler
{
	private M6502DASM disAsm;

	public void DisassembleBinaryLoadFile(BinaryLoadFile file, string destFileName)
	{
		StreamWriter sw = new StreamWriter(destFileName);
		StringBuilder s;
		BinaryLoadSegment seg = new BinaryLoadSegment();

		for (int i = 0; i <= file.SegmentCount - 1; i++) {
			seg = file.Segment(i);
			s = new StringBuilder();
			s.Append(string.Format("Segment {0}",i));
			s.Append(string.Format(", Start Address: {0}" ,seg.StartAddress));
			s.Append(string.Format(", End Address: {0}",seg.EndAddress));

			sw.WriteLine(s.ToString());
			sw.WriteLine("");

			disAsm = new M6502DASM(seg.Data, seg.StartAddress);

			sw.Write(disAsm.Disassemble());
		}

		sw.Close();
	}
}

