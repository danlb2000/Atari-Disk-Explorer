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

namespace AtariDisk.FileSystems
{

    public class FileInfo
    {
        private List<FileSector> sectorList;
        private List<string> fileErrors;

        public DirectoryEntry DirEntry { get; set; }
        public List<FileSector> SectorList
        {
            get
            {
                return sectorList;
            }
        }

        public List<string> FileErrors
        {
            get
            {
                return fileErrors;
            }
        }

        public bool IsValid
        {
            get { return FileErrors.Count == 0; }
        }

        public FileInfo()
        {
            sectorList = new List<FileSector>();
            fileErrors = new List<string>();
        }
    }

    public class FileSector
    {
        public byte[] Data;
        public int Sector { get; set; }
        public int NextSector { get; set; }
        public int FileHandle { get; set; }
        public int ByteCount { get; set; }
        public int InUseInMap { get; set; }
    }


}

