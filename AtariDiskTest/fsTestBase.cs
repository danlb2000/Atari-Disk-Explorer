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


using AtariDisk.FileSystems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtariDiskTest
{
    public class fsTestBase
    {
        protected void TestFile(FileSystem fs, int size)
        {
            var data = new byte[size];
            for (int i = 0; i < size; i++) data[i] = (byte)(i & 0xFF);

            fs.AddFile("TESTFILE.DAT", data);

            var readFile = fs.ReadFile("TESTFILE.DAT", false);

            Assert.AreEqual(data.Length, readFile.Length, "Read file length wrong");

            for (int i = 0; i < size; i++)
            {
                if (readFile[i] != data[i]) Assert.Fail(string.Format("Data comparision failed, FileSize: {0} Byte: {1}, Expected: {2}, Found: {3}", size, i, data[i], readFile[i]));

            }

            var info = fs.GetFileInfo("TESTFILE.DAT");
            if (!fs.IsFileValid("TESTFILE.DAT", null)) Assert.Fail("File has errors");
        }

        protected void WriteFile(FileSystem fs, int num, int size, byte testdata)
        {
            var data = new byte[size];
            for (int i = 0; i < size; i++) data[i] = testdata;

            fs.AddFile("TEST" + num.ToString() + ".DAT", data);
        }

        protected void VerifyFile(FileSystem fs, int num, int size, byte testdata)
        {
            var readFile = fs.ReadFile("TEST" + num.ToString() + ".DAT", false);

            Assert.AreEqual(size, readFile.Length, "Read file length wrong");

            for (int i = 0; i < size; i++)
            {
                if (readFile[i] != testdata) Assert.Fail(string.Format("Data comparision failed, FileSize: {0} Byte: {1}, Expected: {2}, Found: {3}", size, i, testdata, readFile[i]));

            }
        }
    }
}
