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

namespace AtariDisk.FileSystems
{

    /// <summary>
    /// Holds a VTOC sector map in a standard format
    /// </summary>
    public class SectorMap
    {
        // Type of each sector
        private int[] sectorMap;

        public int[] FileInSector { get; set; }

        public enum SectorTypes : int
        {
            Available = 0,
            Used = 1,
            System = 2,
            Unusable = 3
        }

        public SectorMap(int numberOfSectors)
        {
            sectorMap = new int[numberOfSectors];
            FileInSector = new int[numberOfSectors];
        }

        public SectorTypes this[int SectorNumber]
        {
            get { return (SectorTypes)sectorMap[SectorNumber]; }
            set { sectorMap[SectorNumber] = (int)value; }
        }

        /// <summary>
        /// Return number of sectors in the map
        /// </summary>
        /// <returns></returns>
        public int NumberOfSectorsInMap()
        {
            return sectorMap.GetUpperBound(0);
        }

        /// <summary>
        /// Count the number of available sectors within a specified range of sectors
        /// </summary>
        /// <param name="fromSector"></param>
        /// <param name="toSector"></param>
        /// <returns></returns>
        public int AvailableSectors(int fromSector, int toSector)
        {
            int count = 0;

            for (int i = fromSector; i <= toSector; i++)
            {
                if (this[i] == SectorTypes.Available) count += 1;
            }

            return count;
        }

        /// <summary>
        /// Count the number of available sectors in the map
        /// </summary>
        /// <returns></returns>
        public int AvailableSectors()
        {
            int count = 0;

            for (int i = 1; i <= sectorMap.GetUpperBound(0); i++)
            {
                if (this[i] == SectorTypes.Available) count += 1;
            }

            return count;
        }

        /// <summary>
        /// Makes all sectors in the map available
        /// </summary>
        public void ClearMap()
        {
            for (int i = 1; i <= sectorMap.GetUpperBound(0); i++)
            {
                this[i] = SectorTypes.Available;
            }
        }


        /// <summary>
        /// Finds the next available sector
        /// </summary>
        /// <returns>Sector number or 0 if no available sectors</returns>
        public int GetNextAvailableSector()
        {
            for (int i = 1; i <= sectorMap.GetUpperBound(0); i++)
            {
                if (this[i] == SectorTypes.Available)
                {
                    this[i] = SectorTypes.Used;
                    return i;
                }
            }

            return 0;
        }
    }

}