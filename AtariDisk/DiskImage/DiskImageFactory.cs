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

namespace AtariDisk.DiskImage
{
    public class DiskImageFactory
    {
        public static AbstractDiskImage NewDiskImage(string filename)
        {
            string ext = System.IO.Path.GetExtension(filename);
            ext = ext.TrimStart('.');

            switch (ext.ToUpper().Trim())
            {
                case "ATR":
                    return new AtrDiskImage();
                case "XFD":
                    return new XfdDiskImage();
                default:
                    throw new System.ArgumentException("Unknown disk image type");
            }
        }
    }
}