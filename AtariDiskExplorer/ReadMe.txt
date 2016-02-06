Atari Disk Explorer
Copyright 2015 Dan Boris (danlb_2000@yahoo.com)

License
--------------------
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

System Requirements
-------------------

   Windows XP or greater 
   Microsoft .NET Framework 2.0


   NOTE: Be sure to make a backup of your disk images before using this tool on them.

History
--------

   I started writing this application in VB.NET a long time ago because I had dumped a bunch of Atari 8-bit disks and couldn't find a tool I liked to view and manipulate the contents of these disks. As time went on I added more features to the tool as I needed them, and then ported the code to C#. Eventually I realised that this tool might be useful to others so I cleaned it up to make it a more complete application. My other reason for releasing this is to provide an Atari disk manipulation library that other people could build thier own disk related tools around. To that end I have released the full source code of the tool under the GPL license.

Features
--------

	Atari Disk Explorer is a tool for viewing and manipulating Atari 8-bit disk images. 

	- Supports XFD and ATR disk image formats
	- Supports DOS 2.0, DOS 2.5 and MegaImage file systems
	- View boot sector details and disassmbly 
	- View sector data in ATASCII format
	- View disk directory even for disks with non-standard directory location
	- Add, delete and extract files from a disk, including extraction of all files at one time.
	- View file contents in Hex or ATASCII
	- De-tokenize Basic files with ATASCII display, and extract in ASCII formats. Handles some forms of Basic file protection.
	- View the sector map of a DOS disk.
	- View the boot record of a disk along with the dis-assembly of the boot code. 

Source Code
-----------

	The soruce code for the project can be opened and compiled with Microsoft Visual Studio 2013. The solution contains the followign projects:
	
	AtariBasic - Library for de-tokenizing Atari Basic programs
	AtariDisk - Library for the manipulation of Atari disk images
	AtariDiskExplorer - The main disk explorer program
	AtariDiskExplorerSetup - Package and delployement project for Atari Disk Explorer
	AtariDiskTest - Unit tests for the AtariDisk library

Revision Log
------------
	V1.0 - 11/14/2015 - First release

	v1.1 - 
		- When adding a file, there is now a check to be sure there is enough space available.
		- Moved to Visual Studio 2015