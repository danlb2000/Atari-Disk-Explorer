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
    public class Directory
    {
        private List<DirectoryEntry> entries = new List<DirectoryEntry>();

        /// <summary>
        /// List of directory entries
        /// </summary>
        public List<DirectoryEntry> Entries
        {
            get { return entries; }
        }

        /// <summary>
        /// Adds a directory entry
        /// </summary>
        /// <param name="entry"></param>
        public void AddEntry(DirectoryEntry entry)
        {
            entries.Add(entry);
        }

        /// <summary>
        /// Finds the directory entry for a specific file name
        /// </summary>
        /// <param name="filename">Filename to find</param>
        /// <returns>DirectoryEntry object or null if not found</returns>
        public DirectoryEntry FindEntry(string filename)
        {
            foreach (DirectoryEntry di in entries)
            {
                if (di.EntryInUse & !di.Deleted & di.FileName == filename) return di;
            }

            return null;
        }

        /// <summary>
        /// Finds an available directory entry
        /// </summary>
        /// <returns></returns>
        public DirectoryEntry FindOpenEntry()
        {
            foreach (DirectoryEntry entry in entries)
            {
                if (!entry.EntryInUse) return entry;
            }
            return null;
        }
    }
}