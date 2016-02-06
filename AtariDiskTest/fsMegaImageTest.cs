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
using AtariDisk.FileSystems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtariDiskTest
{
    [TestClass]
    public class fsMegaImageTest
    {
        protected string WORKDIR = System.IO.Path.GetTempPath();

        private fsMegaImage CreateDisk()
        {
            var disk = new AtrDiskImage();

            disk.CreateImage(WORKDIR + "testdisk.atr", 8192, 128);
            disk.Mount(WORKDIR + "testdisk.atr", 128);

            var fs = new fsMegaImage(disk);
            fs.Format(false);
            return fs;
        }

        [TestMethod]
        public void TestFormat()
        {
            var fs = CreateDisk();
            Assert.AreEqual(8171, fs.AvailableSectors(), "Available Sectors Wrong");
            Assert.AreEqual(8171, fs.UnusedSectors(), "Unused sectors wrong");
            Assert.AreEqual(0, fs.DiskDirectory().Count, "Directory cound wrong");
        }

        private void TestFile(int size)
        {
            var fs = CreateDisk();
            var data = new byte[size];
            for (int i = 0; i < size; i++) data[i] = (byte)(i & 0xFF);

            fs.AddFile("TESTFILE.DAT", data);

            var readFile = fs.ReadFile("TESTFILE.DAT", false);

            Assert.AreEqual(data.Length, readFile.Length, "Read file length wrong");

            for (int i = 0; i < size; i++)
            {
                if (readFile[i] != data[i]) Assert.Fail(string.Format("Data comparision failed, FileSize: {0} Byte: {1}, Expected: {2}, Found: {3}", size, i, data[i], readFile[i]));

            }
        }

        [TestMethod]
        public void TestReadAddFile()
        {
            TestFile(1);
            TestFile(32);
            TestFile(125);
            TestFile(140);
            TestFile(126375);
        }
    }
}
