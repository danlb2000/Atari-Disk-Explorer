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
    public class fsDOS25 : fsTestBase
    {
        protected const string WORKDIR = @"c:\temp\";

        private fsDos25 CreateDisk()
        {
            var disk = new AtrDiskImage();

            disk.CreateImage(WORKDIR + "testdisk.atr", 1040, 128);
            disk.Mount(WORKDIR + "testdisk.atr", 128);

            var fs = new fsDos25(disk);
            fs.Format(false);
            return fs;
        }

        [TestMethod]
        public void TestFormat()
        {
            var fs = CreateDisk();
            Assert.AreEqual(1010, fs.AvailableSectors(), "Available Sectors Wrong");
            Assert.AreEqual(1010, fs.UnusedSectors(), "Unused sectors wrong");
            Assert.AreEqual(0, fs.DiskDirectory().Count, "Directory cound wrong");
        }

  

        [TestMethod]
        public void TestReadAddFile()
        {
            var fs = CreateDisk();

            TestFile(fs,1);
            TestFile(fs,32);
            TestFile(fs, 124);
            TestFile(fs,125);
            TestFile(fs,140);
            TestFile(fs,126250);
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientDiskSpaceException))]
        public void InsuficiantDiskSpace()
        {
            var fs = CreateDisk();

            TestFile(fs,126376);
        }

        [TestMethod]
        public void TestUnusedSectors()
        {
            var fs = CreateDisk();
            Assert.AreEqual(1010, fs.UnusedSectors(), "Unused Sectors Wrong");

            var data = new byte[32];

            fs.AddFile("TESTFILE.DAT", data);
            Assert.AreEqual(1009, fs.UnusedSectors(), "Unused Sectors Wrong");

            fs.AddFile("TESTFIL2.DAT", data);
            Assert.AreEqual(1008, fs.UnusedSectors(), "Unused Sectors Wrong");

        }    

        [TestMethod]
        public void TestFilesPast720()
        {
            var fs = CreateDisk();

            var data = new byte[95000];

            fs.AddFile("TESTFILE.DAT", data);

            var data2 = new byte[256];

            fs.AddFile("TESTFIL2.DAT", data2);

            var file = fs.ReadFile("TESTFIL2.DAT",false);

            Assert.AreEqual(256, file.Length, "File length wrong");

        }    
    }
}
