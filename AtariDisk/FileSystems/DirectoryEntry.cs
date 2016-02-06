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
using System.Collections.ObjectModel;

namespace AtariDisk.FileSystems
{

    public class DirectoryEntry
    {
        /// <summary>
        /// List of errors in this directory entry
        /// </summary>
        private Collection<EntryError> errorList;
        public Collection<EntryError> ErrorList
        {
            get
            {
                return errorList;
            }
        }

        public enum EntryError
        {
            InvalidStartSector,
            InvalidNumberOfSectors,
            FileNameInvalidCharacters
        }

        public DirectoryEntry()
        {
            errorList = new Collection<EntryError>();
            ValidEntry = true;
        }

        /// <summary>
        /// true = This is a valid entry
        /// </summary>
        public bool ValidEntry { get; set; }

        /// <summary>
        /// Internat DOS file number
        /// </summary>
        public int FileNumber { get; set; }

        /// <summary>
        /// true = file is currently open for output
        /// </summary>
        public bool OpenForOutput { get; set; }

        public bool CreatedInDos2 { get; set; }
        public bool Locked { get; set; }
        public bool EntryInUse { get; set; }
        public bool Deleted { get; set; }
        public int NumSectors { get; set; }
        public int StartSector { get; set; }
        public string FileName { get; set; }
    }

}