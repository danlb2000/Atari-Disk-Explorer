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


using System.Collections;
using System;
using AtariDisk;

namespace AtariDisk
{
    public class BinaryLoadSegment
    {
        private int startAddress;
        private int endAddress;
        private byte[] data;

        public byte[] Data
        {
            get { return data; }
        }

        public int StartAddress
        {
            get { return startAddress; }
            set { startAddress = value; }
        }

        public int EndAddress
        {
            get { return endAddress; }
            set { endAddress = value; }
        }

        public BinaryLoadSegment()
        {

        }

        public override string ToString()
        {
            return string.Format("${0:X4} to ${1:X4} length ${2:X4}", startAddress, endAddress, Length);
        }

        public BinaryLoadSegment(int startAddress, int endAddress)
        {
            this.startAddress = startAddress;
            this.endAddress = endAddress;
        }

        public void AddData(byte[] source, int offset)
        {
            data = new byte[this.Length - 1];

            Array.Copy(source, offset, data, 0, this.Length);
        }      

        public int Length
        {
            get { return endAddress - startAddress + 1; }
        }
    }

    public class BinaryLoadFile
    {
        private ArrayList _segments = new ArrayList();

        public int SegmentCount
        {
            get { return _segments.Count; }
        }

        public BinaryLoadSegment Segment(int segmentNum)
        {
            return (BinaryLoadSegment)_segments[segmentNum];
        }

        public byte[] SegmentData(int segment)
        {
            BinaryLoadSegment header;
            header = (BinaryLoadSegment)_segments[segment];
            return header.Data;
        }

        public BinaryLoadFile(byte[] data)
        {
            BinaryLoadSegment segment;
            int curAddress = 0;
            int curSegment = 1;
  
            if (data[0] != 0xff || data[1] != 0xff) throw new InvalidBinaryLoadFileException();
            curAddress = 2;
            while (curAddress + 4 < data.Length)
            {
                segment = new BinaryLoadSegment();
                segment.StartAddress = (data[curAddress + 1] * 256) + data[curAddress + 0];
                segment.EndAddress = (data[curAddress + 3] * 256) + data[curAddress + 2];

                if (segment.EndAddress < segment.StartAddress)
                {
                    throw new InvalidBinaryLoadFileException("Segment " + curSegment.ToString() + ", end address less then start address.");
                }

                if (curAddress + segment.Length > data.Length)
                {
                    throw new InvalidBinaryLoadFileException("Segment " + curSegment.ToString() + ", end address is beyond the end of the file.");
                }

                segment.AddData(data, curAddress + 4);
                _segments.Add(segment);
                curAddress = curAddress + segment.Length + 4;
                curSegment += 1;
            }
        }
    }
}