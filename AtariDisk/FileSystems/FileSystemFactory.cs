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

namespace AtariDisk.FileSystems
{

    public class FileSystemFactory
    {
        public static FileSystem MakeFileSystem(string FileSystemName, AbstractDiskImage DiskImage)
        {
            FileSystemName = FileSystemName.Replace(".", "");
            switch (FileSystemName.ToUpper())
            {
                case "DOS20":
                    return new fsDos20(DiskImage);
                case "DOS25":
                    return new fsDos25(DiskImage);
                case "NONE":
                    return new fsNone(DiskImage);
                case "MEGAIMAGE":
                    return new fsMegaImage(DiskImage);
                default:
                    throw new System.ArgumentException("Unknown file system");
            }
        }

    }


}