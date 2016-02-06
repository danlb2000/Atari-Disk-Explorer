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
using System.IO;

namespace AtariDisk.DiskImage
{
    public class AtrDiskImage : AbstractDiskImage
    {

        public AtrDiskImage()
        {
            dataStart = 16;
        }

        public override string ToString()
        {
            return "ATR Disk Image";
        }

        public override Hashtable Properties()
        {
            Hashtable props = new Hashtable();
            byte[] header = this.ReadHeader(16);

            props.Add("Paragraphs", header[3] * 256 + header[2]);
            props.Add("SectorSize", header[5] * 256 + header[4]);
            props.Add("ExtendedParagraphs", header[6]);

            return props;
        }

        public override void CreateImage(string filename, int sectors, int sectorSize)
        {

            FileStream fs = null;
            BinaryWriter bw = null;
            this.SectorSize = sectorSize;
            this.length = sectors * sectorSize;
            this.filename = filename;

            try
            {
                fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                bw = new BinaryWriter(fs);

                if (sectorSize != 128 & sectorSize != 256) throw new System.ArgumentException("Invalid sector size, must be 128 or 256");

                //Signature
                bw.Write((byte)0x96);
                bw.Write((byte)0x2);

                //Disk size
                int size = (sectors * sectorSize) / 0x10;
                bw.Write((byte)(size & 0xff));
                bw.Write((byte)((size & 0xff00) >> 8));


                //Sector Size
                bw.Write((byte)(sectorSize & 0xff));
                bw.Write((byte)((sectorSize & 0xff00) >> 8));

                //Rest of header
                for (int i = 7; i <= 16; i++)
                {
                    bw.Write((byte)0);
                }

                //Sectors
                for (int i = 1; i <= sectors * sectorSize; i++)
                {
                    bw.Write((byte)0);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (bw != null) bw.Close();
                if (fs != null) fs.Close();
            }


        }
    }
}