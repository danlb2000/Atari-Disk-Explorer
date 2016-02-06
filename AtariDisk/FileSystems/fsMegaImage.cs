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

using System;
using AtariDisk.FileSystems;
using AtariDisk.DiskImage;

namespace AtariDisk.FileSystems
{

    public class fsMegaImage : fsDOS2
    {

        public fsMegaImage(AbstractDiskImage diskImage)
            : base(diskImage)
        {
            maxFiles = 64;
            LastUsableSector = 8192;
            sectorMap = new SectorMap(LastUsableSector + 1);
        }

        public override void Attach()
        {
            if (attached) return;

            if (diskImage.NumberOfSectors() < 368) throw new InvalidFileSystemException();
            base.Attach();
        }

        public override void ReadSectorMap()
        {
            base.ReadMap(360, 10, 127, 0);
            base.ReadMap(359, 0, 127, 944);
            base.ReadMap(358, 0, 127, 1968);
            base.ReadMap(357, 0, 127, 2992);
            base.ReadMap(356, 0, 127, 4016);
            base.ReadMap(355, 0, 127, 5040);
            base.ReadMap(354, 0, 127, 6064);
            base.ReadMap(353, 0, 127, 7088);
            base.ReadMap(352, 0, 127, 8112);

            Map[1] = SectorMap.SectorTypes.System;
            Map[2] = SectorMap.SectorTypes.System;
            Map[3] = SectorMap.SectorTypes.System;
            for (int i = 351; i <= 368; i++) Map[i] = SectorMap.SectorTypes.System;
        }


        public override void WriteSectorMap()
        {
            base.WriteMap(360, 10, 127, 0);
            base.WriteMap(359, 0, 127, 944);
            base.WriteMap(358, 0, 127, 1968);
            base.WriteMap(357, 0, 127, 2992);
            base.WriteMap(356, 0, 127, 4016);
            base.WriteMap(355, 0, 127, 5040);
            base.WriteMap(354, 0, 127, 6064);
            base.WriteMap(353, 0, 127, 7088);
            base.WriteMap(352, 0, 127, 8112);
        }

        /// <summary>
        /// Write a sector containing file data to the disk
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="fileSector"></param>
        public override void WriteFileSector(int sector, FileSector fileSector)
        {
            var sectorData = new byte[128];

            Array.Clear(sectorData, 0, 128);
            Array.Copy(fileSector.Data, sectorData, fileSector.ByteCount);

            sectorData[125] = (byte)((fileSector.NextSector & 0xff00) >> 8);
            sectorData[126] = (byte)(fileSector.NextSector & 0xff);
            sectorData[127] = (byte)fileSector.ByteCount;
            WriteSector(sector, sectorData);
        }

        /// <summary>
        /// Read a sector containing file data from the disk
        /// </summary>
        /// <param name="sector"></param>
        /// <returns></returns>
        public override FileSector ReadFileSector(int sector)
        {
            var fileSector = new FileSector();
            fileSector.Data = new byte[125];

            var sec = ReadSector(sector);
            fileSector.FileHandle = -1;
            fileSector.NextSector = (sec[125] << 8) + sec[126];
            fileSector.ByteCount = sec[127] & 0x7F;
            fileSector.Sector = sector;
            for (int i = 0; i < 125; i++) fileSector.Data[i] = sec[i];

            return fileSector;
        }

        public override void SetFileFlags(DirectoryEntry entry, int flags)
        {
            if ((flags & 0x1) > 0) entry.OpenForOutput = true;
            if ((flags & 0x2) > 0) entry.CreatedInDos2 = true;
            if ((flags & 0x20) > 0) entry.Locked = true;
            if ((flags & 0x40) > 0) entry.EntryInUse = true;
            if ((flags & 0x80) > 0) entry.Deleted = true;
        }

        public override int GetFileFlags(DirectoryEntry entry)
        {
            int flags = 0;

            if (entry.OpenForOutput) flags |= 0x1;
            if (entry.CreatedInDos2) flags |= 0x2;
            if (entry.Locked) flags |= 0x20;
            if (entry.EntryInUse) flags |= 0x40;
            if (entry.Deleted) flags |= 0x80;

            return flags;
        }

        public override void Format(bool clearData)
        {
            int i;
            byte[] sec = new byte[128];

            //Clear sectors
            if (clearData)
            {
                for (i = 1; i <= diskImage.NumberOfSectors(); i++)
                {
                    diskImage.ClearSector(i);
                }
            }

            // Create sector map
            sectorMap = new SectorMap(LastUsableSector + 1);
            sectorMap.ClearMap();
            sectorMap[1] = SectorMap.SectorTypes.System;
            sectorMap[2] = SectorMap.SectorTypes.System;
            sectorMap[3] = SectorMap.SectorTypes.System;
            for (i = 351; i <= 368; i++)
            {
                sectorMap[i] = SectorMap.SectorTypes.System;
            }

            WriteSectorMap();

            //Write VTOC header
            sec = diskImage.ReadSector(360);
            sec[0] = 7;
            sec[1] = (8171 & 0xff);
            sec[2] = (8171 & 0xff00) >> 8;
            sec[3] = sec[1];
            sec[4] = sec[2];
            diskImage.WriteSector(360, sec);
        }
    }

}