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

using AtariDisk.DiskImage;
using System.Collections.Generic;

namespace AtariDisk.FileSystems
{

    /// <summary>
    /// Null file system used on disks that do not have a file system
    /// </summary>
    public class fsNone : FileSystem
    {

        public fsNone(AbstractDiskImage diskImage)
            : base(diskImage)
        {
            capabilities = 0;
            AllowedSectorSizes = new int[] { 128, 256 };
        }

        public override FileSystem.Error IsDiskValid()
        {
            return 0;
        }

        public override string ToString()
        {
            return "No File System";
        }


        public override List<int> FindDirectory()
        {
            throw new System.NotImplementedException();
        }

        public override void ReadDirectory()
        {
            throw new System.NotImplementedException();
        }

        public override void ReadSectorMap()
        {
            throw new System.NotImplementedException();
        }

        public override int AvailableSectors()
        {
            throw new System.NotImplementedException();
        }

        public override int UnusedSectors()
        {
            throw new System.NotImplementedException();
        }

        public override int UnusedBytes()
        {
            throw new System.NotImplementedException();
        }

        public override void DeleteFile(string Filename)
        {
            throw new System.NotImplementedException();
        }

        public override bool FileExists(string Filename)
        {
            throw new System.NotImplementedException();
        }

        public override void AddFile(string Name, byte[] data)
        {
            throw new System.NotImplementedException();
        }

        public override bool ValidFileName(string Name)
        {
            throw new System.NotImplementedException();
        }


        public override AtariDisk.FileSystems.FileInfo GetFileInfo(string filename)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsFileValid(string filename, List<string> errorList)
        {
            throw new System.NotImplementedException();
        }

        public override int[] MapFiles()
        {
            throw new System.NotImplementedException();
        }

        public override void SetFileFlags(DirectoryEntry entry, int flags)
        {
            throw new System.NotImplementedException();
        }

        public override int GetFileFlags(DirectoryEntry entry)
        {
            return 0;
        }

        public override void Format(bool clearData)
        {
            // Clear sectors
            if (clearData)
            {
                for (int i = 1; i <= diskImage.NumberOfSectors(); i++)
                {
                    diskImage.ClearSector(i);
                }
            }

        }

        public override void DumpDirectory()
        {

        }

    }
}

