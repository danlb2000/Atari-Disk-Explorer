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

using System.Collections.Generic;
using AtariDisk.FileSystems;
using System;
using AtariDisk.DiskImage;

namespace AtariDisk.FileSystems
{

    public abstract class FileSystem
    {
        [Flags]
        public enum Capabilities
        {
            SectorMap = 0x0001,
            Directory = 0x0002,
            WriteFiles = 0x0004
        }

        [Flags]
        public enum Error
        {
            Directory = 0x0001,
            File = 0x0002,
            SectorMap = 0x0004
        }

        protected Capabilities capabilities;
        protected AbstractDiskImage diskImage;
        protected SectorMap sectorMap;
        protected List<DirectoryEntry> directory = new List<DirectoryEntry>();
        protected bool attached = false;

        protected int maxFiles;

        public int SystemSectors { get; set; }
        public int TotalSectors { get; set; }
        public int LastUsableSector { get; set; }

        public int DirectoryStartSector { get; set; }
        public int DirectoryEndSector { get; set; }

        public int[] AllowedSectorSizes { get; set; }

        protected FileSystem(AbstractDiskImage diskImage)
        {
            this.diskImage = diskImage;
        }

        public bool HasCapability(Capabilities capability)
        {
            if ((capabilities & capability) > 0) return true;
            return false;
        }

        public SectorMap Map
        {
            get { return sectorMap; }
            set { sectorMap = value; }
        }

        public List<DirectoryEntry> DiskDirectory()
        {
            return directory;
        }

        public byte[] ReadSector(int sectorNumber)
        {
            return diskImage.ReadSector(sectorNumber);
        }

        public void WriteSector(int sectorNumber, byte[] data)
        {
            diskImage.WriteSector(sectorNumber, data);
        }

        /// <summary>
        /// Converts byte data to an ASCII string
        /// </summary>
        /// <param name="data">Array containing data to convert</param>
        /// <param name="start">Start position of string in data</param>
        /// <param name="end">End position or string in data</param>
        /// <returns>String</returns>
        public static string BytesToString(byte[] data, int start, int end)
        {
            bool isNull = true;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = start; i <= end; i++)
            {
                if (data[i] != 0) isNull = false;
                sb.Append((char)data[i]);
            }
            if (isNull)
                return "";
            else 
                return sb.ToString();
        }

        /// <summary>
        /// Converts an ASCII string to bytes
        /// </summary>
        /// <param name="data">Array to write string into</param>
        /// <param name="s">String to write</param>
        /// <param name="start">Starting position in data</param>
        public static void StringToBytes(byte[] data, string s, int start)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

            for (int i = 0; i <= s.Length - 1; i++)
            {
                data[start + i] = encoding.GetBytes(s.Substring(i, 1))[0];
            }
        }

        /// <summary>
        ///  Return the main filename portion of a filename
        /// </summary>
        /// <param name="fullFileName">Full filename</param>
        /// <returns>Main part of filename</returns>
        public string Filename(string fullFileName)
        {
            int i = fullFileName.IndexOf(".",StringComparison.CurrentCultureIgnoreCase);
            if (i > -1)
            {
                return fullFileName.Substring(0, i);
            }
            else
            {
                return fullFileName;
            }
        }

        /// <summary>
        /// Return the file extension portion of a filename
        /// </summary>
        /// <param name="fullFileName">Full filename</param>
        /// <returns>Extension</returns>
        public string FileExtension(string fullFileName)
        {
            int i = fullFileName.IndexOf(".");
            if (i > -1)
            {
                return fullFileName.Substring(i + 1);
            }
            else
            {
                return "";
            }
        }

        public virtual void Attach()
        {
            attached = true;
        }

        public abstract void SetFileFlags(DirectoryEntry entry, int flags);

        public abstract int GetFileFlags(DirectoryEntry entry);

        public abstract FileSystem.Error  IsDiskValid();       

        public abstract void ReadDirectory();

        public abstract List<int> FindDirectory();

        public abstract void ReadSectorMap();

        public virtual void WriteSectorMap()
        {
        }

        public virtual byte[] ReadFile(string filename, bool doNotThrowError)
        {
            return null;
        }

        public abstract int AvailableSectors();

        public abstract int UnusedBytes();

        public abstract int UnusedSectors();

        public abstract void DeleteFile(string filename);

        public abstract bool FileExists(string filename);

        public abstract void AddFile(string Name, byte[] data);

        public abstract bool ValidFileName(string Name);

        public abstract FileInfo GetFileInfo(string filename);

        public abstract bool IsFileValid(string filename, List<string> errorList);

        public abstract int[] MapFiles();

        public abstract void Format(bool clearData);

        public abstract void DumpDirectory();

     

    }

}