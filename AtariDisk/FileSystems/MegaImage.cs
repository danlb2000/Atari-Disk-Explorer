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

public class fsMegaImage : fsDOS2
{

    public fsMegaImage(iDiskImage DiskImage): base(DiskImage)
	{
		maxFiles = 64;
        LastSector = 8192;
        lSectorMap = new SectorMap(LastSector + 1);
	}

	public override void Attach()
	{
		if (attached) return;
 
		if (lDiskImage.NumberOfSectors() < 368) throw new InvalidFileSystemException(); 
		base.Attach();
	}

	public override void ReadSectorMap()
	{
		
	}

	public override void WriteSectorMap()
	{
		
	}

	public void Format()
	{
		int i;
		byte[] sec = new byte[128];

		//Clear sectors
		for (i = 1; i <= lDiskImage.NumberOfSectors(); i++) {
			lDiskImage.ClearSector(i);
		}

		//Write VTOC header
		sec = lDiskImage.ReadSector(360);
		sec[0] = 7;
		sec[1] = (8178 & 0xff);
		sec[2] = (8178 & 0xff00) >> 8;
		sec[3] = sec[1];
		sec[4] = sec[2];
		lDiskImage.WriteSector(360, sec);

	}
}

