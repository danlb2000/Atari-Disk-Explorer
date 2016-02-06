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

using System.IO;

namespace AtariDisk.DiskImage
{
    public class XfdDiskImage : AbstractDiskImage
    {

        public XfdDiskImage()
        {
            dataStart = 0;
        }

        public override string ToString()
        {
            return "XFD Disk Image";
        }

        public override void CreateImage(string filename, int sectors, int sectorSize)
        {
            FileStream fs = null;
            BinaryWriter bw = null;
            this.SectorSize = sectorSize;
            this.length = sectors * sectorSize;
            this.filename = filename;

            if (sectorSize != 128 & sectorSize != 256) throw new System.ArgumentException("Invalid sector size, must be 128 or 256");

            try
            {
                fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                bw = new BinaryWriter(fs);

                //Sectors
                for (int i = 1; i <= sectors * sectorSize; i++)
                {
                    bw.Write(0);
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