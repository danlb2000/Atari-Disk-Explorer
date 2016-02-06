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
using AtariDisk;
using AtariDisk.DiskImage;

namespace AtariDisk.FileSystems
{
    public class fsDos25 : fsDOS2
    {

        byte[] bootRecord = {
	0x00, 0x03, 0x00, 0x07, 0x40, 0x15, 0x4C, 0x14, 0x07, 0x03, 0x03, 0x00,
	0xCC, 0x19, 0x00, 0x04, 0x00, 0x7D, 0xCB, 0x07, 0xAC, 0x0E, 0x07, 0xF0,
	0x35, 0x20, 0x5F, 0x07, 0xAD, 0x10, 0x07, 0xAC, 0x0F, 0x07, 0xA6, 0x24,
	0x8E, 0x04, 0x03, 0xA6, 0x25, 0x8E, 0x05, 0x03, 0x18, 0x20, 0x6C, 0x07,
	0x30, 0x1C, 0xAC, 0x11, 0x07, 0xB1, 0x24, 0x29, 0x03, 0xAA, 0xC8, 0x11,
	0x24, 0xF0, 0x11, 0xB1, 0x24, 0x48, 0xC8, 0xB1, 0x24, 0x20, 0x55, 0x07,
	0x68, 0xA8, 0x8A, 0x4C, 0x22, 0x07, 0xA9, 0xC0, 0x0A, 0xA8, 0x60, 0xA9,
	0x80, 0x18, 0x65, 0x24, 0x85, 0x24, 0x90, 0x02, 0xE6, 0x25, 0x60, 0xAD,
	0x12, 0x07, 0x85, 0x24, 0xAD, 0x13, 0x07, 0x85, 0x25, 0x60, 0x00, 0x00,
	0x8D, 0x0B, 0x03, 0x8C, 0x0A, 0x03, 0xA9, 0x52, 0xA0, 0x40, 0x90, 0x04,
	0xA9, 0x57, 0xA0, 0x80, 0x08, 0xA6, 0x21, 0xE0, 0x08, 0xD0, 0x07, 0x28,
	0x20, 0x81, 0x14, 0x4C, 0xB9, 0x07, 0x28, 0x8D, 0x02, 0x03, 0xA9, 0x0F,
	0x8D, 0x06, 0x03, 0x8C, 0x17, 0x13, 0xA9, 0x31, 0x8D, 0x00, 0x03, 0xA9,
	0x03, 0x8D, 0x09, 0x13, 0xA9, 0x80, 0x8D, 0x08, 0x03, 0x0A, 0x8D, 0x09,
	0x03, 0xAD, 0x17, 0x13, 0x8D, 0x03, 0x03, 0x20, 0x59, 0xE4, 0x10, 0x05,
	0xCE, 0x09, 0x13, 0x10, 0xF0, 0xA6, 0x49, 0x98, 0x60, 0x20, 0xAD, 0x11,
	0x20, 0x64, 0x0F, 0x20, 0x04, 0x0D, 0x4C, 0xC7, 0x12, 0x00, 0x00, 0x64,
	0x08, 0x8F, 0x0A, 0x4D, 0x0A, 0x8F, 0x09, 0xBC, 0x07, 0x2A, 0x0B, 0x80,
	0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01, 0xFF, 0xAD, 0x0C, 0x07, 0x85,
	0x24, 0xAD, 0x0D, 0x07, 0x85, 0x25, 0xAD, 0x0A, 0x07, 0x85, 0x43, 0xA2,
	0x07, 0xA9, 0x00, 0x06, 0x43, 0x90, 0x15, 0xA0, 0x05, 0x91, 0x24, 0xA5,
	0x24, 0x9D, 0x29, 0x13, 0xA5, 0x25, 0x9D, 0x31, 0x13, 0xA9, 0x90, 0x20,
	0x55, 0x07, 0xA9, 0x64, 0x9D, 0x19, 0x13, 0xCA, 0x10, 0xDF, 0xA5, 0x24,
	0x8D, 0x39, 0x13, 0xA5, 0x25, 0x8D, 0x3A, 0x13, 0xAC, 0x09, 0x07, 0xA2,
	0x00, 0x88, 0x98, 0x9D, 0x21, 0x13, 0x30, 0x03, 0x20, 0x53, 0x07, 0xE8,
	0xE0, 0x08, 0xD0, 0xF1, 0xA5, 0x24, 0x8D, 0xE7, 0x02, 0xA5, 0x25, 0x8D,
	0xE8, 0x02, 0xA9, 0x00, 0xA8, 0x99, 0x81, 0x13, 0xC8, 0x10, 0xFA, 0xA8,
	0xB9, 0x1A, 0x03, 0xF0, 0x0C, 0xC9, 0x44, 0xF0, 0x08, 0xC8, 0xC8, 0xC8,
	0xC0, 0x1E, 0xD0, 0xF0, 0x00, 0xA9, 0x44, 0x99, 0x1A, 0x03, 0xA9, 0xCB,
	0x99, 0x1B, 0x03, 0xA9, 0x07, 0x99, 0x1C, 0x03, 0x60, 0x20, 0xAD, 0x11,
	0x20, 0x7D, 0x0E, 0xBD, 0x4A, 0x03, 0x9D, 0x82, 0x13, 0x29, 0x02, 0xF0,
	0x03, 0x4C, 0x72, 0x0D, 0x20, 0xEC, 0x0E, 0x08, 0xBD, 0x82, 0x13, 0xC9
};


        public fsDos25(AbstractDiskImage diskImage)
            : base(diskImage)
        {
            SystemSectors = 14;
            LastUsableSector = 1024;
            TotalSectors = 1040;
            maxFiles = 64;
            sectorMap = new SectorMap(TotalSectors + 1);
        }

        /// <summary>
        /// Attach file system to disk image
        /// </summary>
        public override void Attach()
        {
            if (attached) return;

            if (diskImage.NumberOfSectors() < TotalSectors) throw new InvalidFileSystemException();
            base.Attach();
        }

        /// <summary>
        /// Read sector map from VTOC and VTOC2
        /// </summary>
        public override void ReadSectorMap()
        {
            base.ReadMap(360, 10, 99, 0);
            base.ReadMap(1024, 84, 121, 720);

            Map[1] = SectorMap.SectorTypes.System;
            Map[2] = SectorMap.SectorTypes.System;
            Map[3] = SectorMap.SectorTypes.System;
            Map[1024] = SectorMap.SectorTypes.System;
            Map[720] = SectorMap.SectorTypes.Unusable;
            for (int i = 360; i <= 368; i++) Map[i] = SectorMap.SectorTypes.System;
        }

        /// <summary>
        /// Return the unused sector count as reported by the VTOC and VTOC2
        /// </summary>
        /// <returns>Unused sector count</returns>
        public override int UnusedSectors()
        {
            byte[] sec = ReadSector(360);
            int sectors = sec[4] * 256 + sec[3];

            sec = ReadSector(1024);
            sectors += (sec[123] * 256 + sec[122]);

            return sectors;
        }

        /// <summary>
        /// Updates the unused sector count in VTOC and VTOC2
        /// </summary>
        /// <remarks>
        /// </remarks>
        protected override void UpdateUnusedSectors()
        {
            int count = sectorMap.AvailableSectors(1, 719);
            byte[] sec = ReadSector(360);
            sec[4] = (byte)(count >> 8);
            sec[3] = (byte)(count & 0xff);
            WriteSector(360, sec);

            count = sectorMap.AvailableSectors(720, 1023);
            sec = ReadSector(1024);
            sec[4] = (byte)(count >> 8);
            sec[3] = (byte)(count & 0xff);
            WriteSector(1024, sec);
        }


        /// <summary>
        /// Write sector map back to VTOC and VTOC2
        /// </summary>
        public override void WriteSectorMap()
        {
            base.WriteMap(360, 10, 99, 0);
            base.WriteMap(1024, 0, 83, 48);
            base.WriteMap(1024, 84, 121, 720);
        }

        /// <summary>
        /// Format disk as DOS 2.5
        /// </summary>
        /// <param name="clearData"></param>
        public override void Format(bool clearData)
        {
            // Start with DOS 2.0 format
            base.Format(clearData);

            // Write VTOC2 header
            var sec = diskImage.ReadSector(1024);

            sec[122] = (303 & 0xff);
            sec[123] = (303 & 0xff00) >> 8;
            diskImage.WriteSector(1024, sec);

            // Update  sector map
            ReadSectorMap();
            Map[1024] = SectorMap.SectorTypes.System;   // VTOC2
            Map[720] = SectorMap.SectorTypes.Unusable;  // DOS 2.5 can't use sector 720
            WriteSectorMap();

            bootRecord.Copy(sec, 0, 0, 128);
            diskImage.WriteSector(1, sec);
            bootRecord.Copy(sec, 128, 0, 128);
            diskImage.WriteSector(2, sec);
            bootRecord.Copy(sec, 256, 0, 128);
            diskImage.WriteSector(3, sec);
        }

        public override void SetFileFlags(DirectoryEntry entry, int flags)
        {
            if ((flags & 0x01) > 0 || (flags & 0x40) > 0) entry.EntryInUse = true;
            if ((flags & 0x2) > 0) entry.CreatedInDos2 = true;
            if ((flags & 0x20) > 0) entry.Locked = true;
            if ((flags & 0x80) > 0) entry.Deleted = true;
        }

        public override int GetFileFlags(DirectoryEntry entry)
        {
            int flags = 0;

            if (entry.StartSector > 719 && entry.EntryInUse) flags |= 0x1;
            if (entry.CreatedInDos2) flags |= 0x2;
            if (entry.Locked) flags |= 0x20;
            if (entry.EntryInUse && entry.StartSector < 720) flags |= 0x40;
            if (entry.Deleted) flags |= 0x80;

            return flags;
        }

        /// <summary>
        /// Create a map of sector usage based on the sector chain for each file on the disk.
        /// </summary>
        /// <returns></returns>
        public SectorMap TraceFiles()
        {
            var map = base.TraceFiles();

            map[720] = SectorMap.SectorTypes.Used;
            return map;
        }   

    }

}