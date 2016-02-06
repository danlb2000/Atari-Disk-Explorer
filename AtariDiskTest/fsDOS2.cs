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
using AtariDisk.FileSystems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtariDiskTest
{
    [TestClass]
    public class fsDOS2 : fsTestBase
    {
        protected const string WORKDIR = @"c:\temp\";

        
        private fsDos20 CreateDisk()
        {
            var disk = new AtrDiskImage();

            disk.CreateImage(WORKDIR + "testdisk.atr", 720, 128);
            disk.Mount(WORKDIR + "testdisk.atr", 128);
            disk.Unmount();
            var fs = new fsDos20(disk);
            fs.Format(false);
            return fs;
        }

        [TestMethod]
        public void DirectoryStartSector()
        {
            var disk = new AtrDiskImage();
            var fs = new fsDos20(disk);
            fs.DirectoryStartSector = 361;

            int sector, offset;
            fs.DirectorySectorLocation(0, out sector, out offset);
            Assert.AreEqual(361, sector, "Sector file 0");
            Assert.AreEqual(0, offset, "Offset file 0");

            fs.DirectorySectorLocation(1, out sector, out offset);
            Assert.AreEqual(361, sector, "Sector file 1");
            Assert.AreEqual(16, offset, "Offset file 1");

            fs.DirectorySectorLocation(8, out sector, out offset);
            Assert.AreEqual(362, sector, "Sector file 8");
            Assert.AreEqual(0, offset, "Offset file 8");
            
            
        }

        [TestMethod]
        public void TestFormat()
        {
            var fs = CreateDisk();
            Assert.AreEqual(707, fs.AvailableSectors(), "Available Sectors Wrong");
            Assert.AreEqual(707, fs.UnusedSectors(), "Unused sectors wrong");
            Assert.AreEqual(0, fs.DiskDirectory().Count, "Directory cound wrong");
        }


        [TestMethod]
        public void TestOverwriteFile()
        {
            FileSystem fs;

            fs = CreateDisk(); 

            WriteFile(fs, 1, 32, 1);
            WriteFile(fs, 1, 256, 255);
            VerifyFile(fs, 1, 256, 255);      
        }

        [TestMethod]
        public void TestAddEmptyFile()
        {
            FileSystem fs;

            fs = CreateDisk();

            fs.AddFile("TESTFILE.DAT", null);

            var info = fs.GetFileInfo("TESTFILE.DAT");
            Assert.IsTrue(info.IsValid);
            Assert.IsTrue(info.DirEntry.ValidEntry);
        }

        [TestMethod]
        public void TestReadAddSingleFile()
        {
            FileSystem fs;

            fs = CreateDisk();
            TestFile(fs,1);

            fs = CreateDisk();
            TestFile(fs, 32);

            fs = CreateDisk();
            TestFile(fs, 125);

            fs = CreateDisk();
            TestFile(fs, 140);

            fs = CreateDisk();
            TestFile(fs, 88374);
        }

        [TestMethod]
        public void TestReadAddMultiFile()
        {
            FileSystem fs;

            fs = CreateDisk();
            WriteFile(fs, 1, 120, 0x55);
            WriteFile(fs, 2, 256, 0xAA);
            WriteFile(fs, 3, 1024, 0x33);

            VerifyFile(fs, 1, 120, 0x55);
            VerifyFile(fs, 2, 256, 0xAA);
            VerifyFile(fs, 3, 1024, 0x33);
        }


        [TestMethod]
        public void ReplaceDeleteFileDirectoryEntry()
        {
            FileSystem fs;

            fs = CreateDisk();
            WriteFile(fs, 1, 120, 0x55);
            WriteFile(fs, 2, 256, 0xAA);
            WriteFile(fs, 3, 1024, 0x33);

            Assert.AreEqual(3, fs.DiskDirectory().Count, "Count wrong before delete");

            fs.DeleteFile("TEST2.DAT");

            Assert.AreEqual(3, fs.DiskDirectory().Count, "Count wrong after delete");

            WriteFile(fs, 4, 256, 0xAA);

            Assert.AreEqual(3, fs.DiskDirectory().Count, "Count wrong after fourth file added");


            VerifyFile(fs, 1, 120, 0x55);
            VerifyFile(fs, 4, 256, 0xAA);
            VerifyFile(fs, 3, 1024, 0x33);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryFullException))]
        public void DirectoryFull()
        {
            var fs = CreateDisk();
            var data = new byte[32];
            for(int i=0; i<64; i++) fs.AddFile("T" + i.ToString(), data);

            fs.AddFile("TEST", data);
        }
    
        [TestMethod] 
        [ExpectedException(typeof(InvalidFileNameException))]
        public void InvalidFileName() {
            var fs = CreateDisk();
            var data = new byte[32];            
            
            fs.AddFile("TESTFILE1234.DAT", data);
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientDiskSpaceException))]
        public void InsuficiantDiskSpace()
        {
            FileSystem fs = CreateDisk();
            TestFile(fs,88376);
        }

        [TestMethod]
        public void TestUnusedSectors()
        {
            var fs = CreateDisk();
            Assert.AreEqual(707, fs.UnusedSectors(), "Unused Sectors Wrong");

            var data = new byte[32];            
            
            fs.AddFile("TESTFILE.DAT", data);
            Assert.AreEqual(706, fs.UnusedSectors(), "Unused Sectors Wrong");

            fs.AddFile("TESTFIL2.DAT", data);
            Assert.AreEqual(705, fs.UnusedSectors(), "Unused Sectors Wrong");

        }

        [TestMethod]
        public void TestUnusedBytes()
        {
            var fs = CreateDisk();
            Assert.AreEqual(88375, fs.UnusedBytes(), "Unused Bytes Wrong");

            var data = new byte[32];

            fs.AddFile("TESTFILE.DAT", data);
            Assert.AreEqual(88250, fs.UnusedBytes(), "Unused Bytes Wrong");

            fs.AddFile("TESTFIL2.DAT", data);
            Assert.AreEqual(88125, fs.UnusedBytes(), "Unused Bytes Wrong");

        }

        [TestMethod]
        public void TestDeleteFile()
        {
            var fs = CreateDisk();

            var data = new byte[32];
            fs.AddFile("TESTFILE.DAT", data);
            fs.DeleteFile("TESTFILE.DAT");

            Assert.AreEqual(707, fs.UnusedSectors(), "Available Sectors Wrong");

            Assert.IsNull(fs.FindDirectoryEntry("TESTFILE.DAT"),"Directory entry not null");
        }

        [TestMethod]
        public void TestGetFileInfo()
        {
            var fs = CreateDisk();

            var data = new byte[32];
            fs.AddFile("TESTFILE.DAT", data);

            var info = fs.GetFileInfo("TESTFILE.DAT");
            Assert.AreEqual(0, info.DirEntry.FileNumber, "File number wrong");

            Assert.AreEqual(1, info.SectorList.Count, "Sector list count wrong");
            Assert.AreEqual(4, info.SectorList[0].Sector, "First sector wrong");
            Assert.AreEqual(0, info.SectorList[0].NextSector, "Next sector wrong");
            Assert.AreEqual(32, info.SectorList[0].ByteCount, "Byte cound wrong");
        }

         [TestMethod]
        public void TestSectorMap()
        {
            var fs = CreateDisk();

            var data = new byte[32];
            fs.AddFile("TESTFILE.DAT", data);

            Assert.AreEqual(SectorMap.SectorTypes.System, fs.Map[1], "Sector 1 wrong in map");
            Assert.AreEqual(SectorMap.SectorTypes.System, fs.Map[2], "Sector 2 wrong in map");
            Assert.AreEqual(SectorMap.SectorTypes.System, fs.Map[3], "Sector 3 wrong in map");
            Assert.AreEqual(SectorMap.SectorTypes.Used, fs.Map[4], "Sector 4 wrong in map");
            Assert.AreEqual(SectorMap.SectorTypes.Available, fs.Map[5], "Sector 4 wrong in map");

            Assert.AreEqual(5, fs.Map.GetNextAvailableSector(), "Next available sector wrong");
            
           
        }

         [TestMethod]
         public void TestFindDirectory()
         {
             var fs = CreateDisk();

             var data = new byte[32];
             fs.AddFile("TESTFILE.DAT", data);

             var list = fs.FindDirectory();
             Assert.AreEqual(1, list.Count, "Sector count wrong");
             Assert.AreEqual(361, list[0], "Sector 0 wrong");
         }

    }
}
