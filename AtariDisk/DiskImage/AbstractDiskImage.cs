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
    public abstract class AbstractDiskImage
    {
        protected string filename;
        protected int length;
        protected int dataStart;
        protected bool readOnly = false;

        public int Length
        {
            get { return length; }
        }

        public string FileName
        {
            get { return filename; }
        }

        public int SectorSize { get; set; }

        public int NumberOfSectors()
        {
            return (length - dataStart) / SectorSize;
        }

        public void Mount(string name, int sectorSize)
        {
            filename = name;
            FileInfo fInfo = new FileInfo(name);
            length = (int)fInfo.Length;
            SectorSize = sectorSize;
            if (fInfo.Attributes == FileAttributes.ReadOnly)
                readOnly = true;
            else
                readOnly = false;
        }

        public void Mount(string name)
        {
            this.Mount(name, 128);
        }

        public void Unmount()
        {
        }

        public bool IsValidSector(int sectorNumber)
        {
            if (sectorNumber < 1 | sectorNumber > NumberOfSectors()) return false;
            return true;
        }

        public byte[] ReadSector(int sectorNumber)
        {
            if (!IsValidSector(sectorNumber))
            {
                throw new System.ArgumentException(string.Format("Invalid sector number. Must be between 1 and {0}", NumberOfSectors()));
            }

            byte[] buffer;
            FileStream fs = null;
            BinaryReader br = null;

            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
                fs.Seek(dataStart + ((sectorNumber - 1) * SectorSize), SeekOrigin.Begin);
                buffer = br.ReadBytes(SectorSize);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (br != null) br.Close();
                if (fs != null) fs.Close();
            }

            return buffer;
        }

        protected byte[] ReadHeader(int length)
        {
            byte[] buffer;

            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            buffer = br.ReadBytes(length);
            br.Close();
            fs.Close();
            return buffer;
        }

        public void WriteSector(int sectorNumber, byte[] data)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            fs.Seek(dataStart + ((sectorNumber - 1) * SectorSize), SeekOrigin.Begin);
            fs.Write(data, 0, SectorSize);
            bw.Close();
            fs.Close();
        }

        public void ClearSector(int sectorNumber)
        {
            byte[] data = new byte[SectorSize];
            System.Array.Clear(data, 0, SectorSize);
            WriteSector(sectorNumber, data);
        }

        public virtual Hashtable Properties()
        {
            return new Hashtable();
        }

        public virtual void CreateImage(string filename, int sectors, int sectorSize)
        {
        }
    }

}