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
using System.Collections;
using System.Collections.Generic;
using AtariDisk.FileSystems;
using AtariDisk.DiskImage;

namespace AtariDisk.FileSystems
{
    /// <summary>
    /// Base class for DOS2 style file systems. This forms that base for Dos20, Dos25 and Megaimage file systems.
    /// </summary>
    public abstract class fsDOS2 : FileSystem
    {

        protected fsDOS2(AbstractDiskImage diskImage)
            : base(diskImage)
        {
            DirectoryStartSector = 361;
            DirectoryEndSector = 368;
            capabilities = Capabilities.SectorMap | Capabilities.Directory | Capabilities.WriteFiles;
            AllowedSectorSizes = new int[] { 128 };
        }

        /// <summary>
        /// Attaches file system to disk image
        /// </summary>
        public override void Attach()
        {
            if (attached) return;

            base.Attach();
            diskImage.SectorSize = 128;

            ReadDirectory();
            ReadSectorMap();

            attached = true;
        }

        /// <summary>
        /// Check if directory and file structures are valid
        /// </summary>
        /// <returns>True = everything is valid/false= one or more </returns>
        public override FileSystem.Error IsDiskValid()
        {
            FileSystem.Error errors = 0;

            // Check directory entries and files
            foreach (DirectoryEntry entry in directory)
            {
                if (!entry.EntryInUse || entry.OpenForOutput) continue;

                if (!entry.ValidEntry)
                {
                    errors = errors | Error.Directory;
                }
                else
                {
                    // Check file for errors
                    try
                    {
                        if (!IsFileValid(entry.FileName, null)) errors = errors | Error.File;
                    }
                    catch
                    {
                        return errors = errors | Error.File;
                    }
                }

            }

            // Verify sector map
            if (this.HasCapability(Capabilities.SectorMap))
            {
                var fileTrace = this.TraceFiles();

                for (int i = 1; i <= fileTrace.NumberOfSectorsInMap(); i++)
                {
                    if ((sectorMap[i] == SectorMap.SectorTypes.Used && fileTrace[i] != SectorMap.SectorTypes.Used) ||
                       (sectorMap[i] == SectorMap.SectorTypes.Available && fileTrace[i] != SectorMap.SectorTypes.Available))
                    {
                        errors = errors | Error.SectorMap;
                    }
                }

            }

            return errors;
        }

        /// <summary>
        /// Finds a directory entry 
        /// </summary>
        /// <param name="filename">Filename to find</param>
        /// <returns>Directory Entry object</returns>
        public DirectoryEntry FindDirectoryEntry(string filename)
        {
            foreach (DirectoryEntry di in directory)
            {
                if (di.EntryInUse & !di.Deleted & !di.OpenForOutput & di.FileName == filename) return di;
            }

            return null;
        }

        /// <summary>
        /// Checks if a file is stored properly on the disk
        /// </summary>
        /// <param name="filename">File name to check</param>
        /// <param name="errorList">List of string to contain any errors found</param>
        /// <returns></returns>
        public override bool IsFileValid(string filename, List<string> errorList)
        {
            if (errorList == null) errorList = new List<string>();

            FileInfo info = null;

            try
            {
                info = GetFileInfo(filename);
            }
            catch (Exception ex)
            {
                errorList.Add(ex.Message);
                return false;
            }

            if (info.SectorList.Count == 0) return true;

            int lastSector = info.SectorList[info.SectorList.Count - 1].Sector;

            foreach (FileSector sector in info.SectorList)
            {
                if (sector.FileHandle != -1 && sector.FileHandle != info.DirEntry.FileNumber)
                {
                    errorList.Add(string.Format("Sector {0} has incorrect file number {1}", sector.Sector, sector.FileHandle));
                }

                if (sector.Sector != lastSector)
                {
                    if (!this.diskImage.IsValidSector(sector.NextSector))
                    {
                        errorList.Add(string.Format("Sector {0} continues to sector {1} which is not valid", sector.Sector, sector.NextSector));
                    }
                }
                else
                {
                    if (sector.NextSector != 0)
                    {
                        errorList.Add(string.Format("Last sector of file doesn't have valid next sector"));
                    }
                }

            }

            if (errorList.Count != 0) return false;
            return true;
        }

        /// <summary>
        /// Gets the details of where a file is stored on the disk
        /// </summary>
        /// <param name="filename">Filename to get information for</param>
        /// <returns>FileInfo object</returns>
        public override FileInfo GetFileInfo(string filename)        
        {
            Attach();

            var info = new FileInfo();

            // Find directory entry
            info.DirEntry = FindDirectoryEntry(filename);
            if (info.DirEntry == null) throw new FileNotFoundException();

            // Read sector list
            int sectorCount = 0;
            var sector = info.DirEntry.StartSector;

            if (!this.diskImage.IsValidSector(sector))
            {
                info.FileErrors.Add(string.Format("Start sector {0} is invalid", sector));
                return info;
            }

            while ((sectorCount < info.DirEntry.NumSectors))
            {
                var sec = ReadFileSector(sector);
                sectorCount += 1;

                info.SectorList.Add(sec);

                if (sectorCount != info.DirEntry.NumSectors && !this.diskImage.IsValidSector(sec.NextSector))
                {
                    info.FileErrors.Add(string.Format("Sector {0} links to invalid sector {1}", sector, sec.NextSector));
                    break;
                }
                sector = sec.NextSector;
            }


            return info;
        }

        /// <summary>
        /// Write a sector containing file data to the disk
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="fileSector"></param>
        public virtual void WriteFileSector(int sector, FileSector fileSector)
        {
            var sectorData = new byte[128];

            Array.Clear(sectorData, 0, 128);
            Array.Copy(fileSector.Data, sectorData, fileSector.ByteCount);

            var b = (byte)(fileSector.FileHandle << 2);
            b |= (byte)((fileSector.NextSector & 0x300) >> 8);
            sectorData[125] = b;
            sectorData[126] = (byte)(fileSector.NextSector & 0xff);
            sectorData[127] = (byte)fileSector.ByteCount;
            WriteSector(sector, sectorData);
        }

        /// <summary>
        /// Read a sector containing file data from the disk
        /// </summary>
        /// <param name="sector"></param>
        /// <returns></returns>
        public virtual FileSector ReadFileSector(int sector)
        {
            var fileSector = new FileSector();
            fileSector.Data = new byte[125];

            var sec = ReadSector(sector);
            fileSector.Sector = sector;
            fileSector.FileHandle = (sec[125] & 0xfc) >> 2;
            fileSector.NextSector = ((sec[125] & 0x3) << 8) + sec[126];
            fileSector.ByteCount = sec[127] & 0x7F;
            for (int i = 0; i < 125; i++) fileSector.Data[i] = sec[i];

            return fileSector;
        }

        /// <summary>
        /// Reads a portion of the sector map from disk
        /// </summary>
        /// <param name="mapSector">Number of sector that contains the map</param>
        /// <param name="startByte">First byte in sector that contains the map</param>
        /// <param name="endByte">Last byte in sector that contains the map</param>
        /// <param name="firstSector">Sector that is represented by the first entry in this part of the map</param>
        protected void ReadMap(int mapSector, int startByte, int endByte, int firstSector)
        {
            int b;
            byte d;

            var sec = ReadSector(mapSector);
            var sector = firstSector;
            for (int i = startByte; i <= endByte; i++)
            {
                d = sec[i];
                for (b = 0; b <= 7; b++)
                {
                    if ((d & 0x80) > 0)
                    {
                        sectorMap[sector] = SectorMap.SectorTypes.Available;
                    }
                    else
                    {
                        sectorMap[sector] = SectorMap.SectorTypes.Used;
                    }
                    sector += 1;
                    d = (byte)(d << 1);

                    if (sector >= sectorMap.NumberOfSectorsInMap()) return;
                }
            }
        }

        /// <summary>
        /// Write a portion of the sector map back to disk
        /// </summary>
        /// <param name="mapSector">Number of sector that contains the map</param>
        /// <param name="startByte">First byte in sector that contains the map</param>
        /// <param name="endByte">Last byte in sector that contains the map</param>
        /// <param name="firstSector">Sector that is represented by the first entry in this part of the map</param>
        protected void WriteMap(int mapSector, int startByte, int endByte, int firstSector)
        {
            int b;
            byte d;

            var sec = ReadSector(mapSector);
            var sector = firstSector;
            for (int i = startByte; i <= endByte; i++)
            {
                d = 0;
                for (b = 0; b <= 7; b++)
                {
                    if (sectorMap[sector] == SectorMap.SectorTypes.Available) d |= 1;
                    if (b < 7) d = (byte)(d << 1);
                    sector += 1;

                    if (sector >= sectorMap.NumberOfSectorsInMap()) break;
                }
                sec[i] = d;

                if (sector >= sectorMap.NumberOfSectorsInMap()) break;
            }
            WriteSector(mapSector, sec);
        }

        /// <summary>
        /// Attempt to find valid directory sectors on the disk. Used when the directory is not in it's normal location
        /// </summary>
        /// <returns>List of sector number containg valid directory entries</returns>
        public override List<int> FindDirectory()
        {
            var list = new List<int>();

            // Save the original location of the directory
            var originalStartSector = DirectoryStartSector;
            var originalEndSector = DirectoryEndSector;


            for (int i = 1; i <= LastUsableSector; i++)
            {
                DirectoryStartSector = i;
                DirectoryEndSector = i;

                ReadDirectory();

                int validfiles = 0;
                foreach (DirectoryEntry de in directory)
                {
                    if (de.ValidEntry && de.EntryInUse) validfiles++;

                }
                if (validfiles > 0) list.Add(i);
            }

            DirectoryStartSector = originalStartSector;
            DirectoryEndSector = originalEndSector;

            return list;
        }

        /// <summary>
        /// Read the directory from the disk
        /// </summary>
        public override void DumpDirectory()
        {
            int curSector = DirectoryStartSector;
            byte[] sec;
            int fileNumber = 0;

            while ((curSector <= DirectoryEndSector))
            {
                sec = ReadSector(curSector);
                int pos = 0;
                while ((pos < 128))
                {
                    DirectoryEntry entry = new DirectoryEntry();

                    // Get flags
                    int flags = sec[pos];

                    SetFileFlags(entry, flags);

                    //Assign filenumber
                    entry.FileNumber = fileNumber;
                    fileNumber += 1;

                    //Get file location information
                    entry.NumSectors = sec[pos + 2] * 256 + sec[pos + 1];
                    entry.StartSector = sec[pos + 4] * 256 + sec[pos + 3];


                    //Get filename
                    entry.FileName = BytesToString(sec, pos + 5, pos + 12).Trim();

                    string extension = BytesToString(sec, pos + 13, pos + 15).Trim();
                    if (extension != "") entry.FileName += "." + extension;

                    pos += 16;

                    System.Diagnostics.Debug.WriteLine(string.Format("{0}: {1}, In Use: {2}, Delete: {3}, Dos2: {4}",entry.FileNumber, entry.FileName.ToString(), entry.EntryInUse, entry.Deleted, entry.CreatedInDos2));

                }
                curSector += 1;
            }

        }

        public void DirectorySectorLocation(int fileNum, out int sector, out int offset) {
            sector = (fileNum / 8);
            offset = (fileNum - (sector * 8)) * 16;
            sector += DirectoryStartSector;
        }

        /// <summary>
        /// Read the directory from the disk
        /// </summary>
        public override void ReadDirectory()
        {
            int curSector = DirectoryStartSector;
            byte[] sec;
            int fileNumber = 0;

            directory = new List<DirectoryEntry>();

            while ((curSector <= DirectoryEndSector))
            {
                sec = ReadSector(curSector);
                int pos = 0; 
                while ((pos < 128))
                {
                    DirectoryEntry entry = new DirectoryEntry();

                    // Get flags
                    int flags = sec[pos];

                    SetFileFlags(entry, flags);

                    if (!entry.EntryInUse && !entry.Deleted) return;

                    //Assign filenumber
                    entry.FileNumber = fileNumber;
                    fileNumber += 1;

                    //Get file location information
                    entry.NumSectors = sec[pos + 2] * 256 + sec[pos + 1];
                    entry.StartSector = sec[pos + 4] * 256 + sec[pos + 3];

                    //Check location information
                    if (entry.StartSector < 4 | (entry.StartSector > 359 & entry.StartSector < 369) | entry.StartSector > LastUsableSector)
                    {
                        entry.ValidEntry = false;
                        entry.ErrorList.Add(DirectoryEntry.EntryError.InvalidStartSector);

                    }
                    if (entry.NumSectors < 1 | entry.NumSectors > AvailableSectors())
                    {
                        entry.ValidEntry = false;
                        entry.ErrorList.Add(DirectoryEntry.EntryError.InvalidNumberOfSectors);
                    }

                    //Check filename
                    if (sec[pos + 5] < 65 | sec[pos + 5] > 90)
                    {
                        entry.ValidEntry = false;
                        entry.ErrorList.Add(DirectoryEntry.EntryError.FileNameInvalidCharacters);
                    }
                    for (int i = 6; i <= 15; i++)
                    {
                        if (!ValidFileNameCharacter((char)(sec[pos + i])))
                        {
                            entry.ValidEntry = false;
                            entry.ErrorList.Add(DirectoryEntry.EntryError.FileNameInvalidCharacters);
                            break;
                        }

                    }

                    //Get filename
                    entry.FileName = BytesToString(sec, pos + 5, pos + 12).Trim();

                    string extension = BytesToString(sec, pos + 13, pos + 15).Trim();
                    if (extension != "") entry.FileName += "." + extension;

                    //Add entry
                    directory.Add(entry);

                    pos += 16;
                }
                curSector += 1;
            }

        }


        /// <summary>
        /// Finds the next open directory entry and creates a new entry at
        /// that locaiton
        /// </summary>
        /// <returns>New DirectoryEntry object</returns>
        private DirectoryEntry GetOpenEntry()
        {
            //Try to find an already open entry
            foreach (DirectoryEntry ent in directory)
            {
                if (!ent.EntryInUse && ent.Deleted) return ent;
            }

            //Check if directory is full
            if (directory.Count == maxFiles) return null;

            //Create a new entry 
            DirectoryEntry entry = new DirectoryEntry();
            entry.FileNumber = directory.Count;

            directory.Add(entry);

            return entry;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Writes a directory entry back to the disk
        /// </summary>
        /// <param name="entry">Directory entry to write</param>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        protected void WriteDirectoryEntry(DirectoryEntry entry)
        {
            byte[] sec;
            int i;
            string filename;
            string ext;

            int sector, offset;

            DirectorySectorLocation(entry.FileNumber, out sector, out offset);

            sec = ReadSector(sector);

            // Write flags
            sec[offset] = (byte)GetFileFlags(entry);

            // Write location information
            sec[offset + 2] = (byte)(entry.NumSectors >> 8);
            sec[offset + 1] = (byte)(entry.NumSectors & 0xff);
            sec[offset + 4] = (byte)(entry.StartSector >> 8);
            sec[offset + 3] = (byte)(entry.StartSector & 0xff);

            //Split filename
            i = entry.FileName.IndexOf(".");
            if (i > -1)
            {
                filename = entry.FileName.Substring(0, i);
                ext = entry.FileName.Substring(i + 1);
            }
            else
            {
                filename = entry.FileName;
                ext = "";
            }
            filename = filename.PadRight(8);
            ext = ext.PadRight(3);

            //Write filename
            StringToBytes(sec, filename, offset + 5);
            StringToBytes(sec, ext, offset + 13);

            WriteSector(sector, sec);

        }

        /// <summary>
        /// Checks if a filename exists on the disk
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public override bool FileExists(string filename)
        {
            Attach();
            DirectoryEntry entry = FindDirectoryEntry(filename);
            if (entry == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// For each section that is shown as used in the sector map, get the file number from that sector
        /// </summary>
        /// <returns></returns>
        public override int[] MapFiles()
        {
            var map = new int[TotalSectors + 1];
            byte[] sec;
            int fileNum;

            for (int sector = 1; sector <= TotalSectors; sector++)
            {
                if (this.Map[sector] == SectorMap.SectorTypes.Used)
                {
                    sec = ReadSector(sector);
                    fileNum = (sec[125] & 0xfc) >> 2;
                    map[sector] = fileNum;
                }
            }

            return map;
        }

        /// <summary>
        /// Create a map of sector usage based on the sector chain for each file on the disk.
        /// </summary>
        /// <returns></returns>
        public SectorMap TraceFiles()
        {
            var map = new SectorMap(LastUsableSector + 1);

            foreach (DirectoryEntry di in directory)
            {
                if (!di.EntryInUse || di.Deleted || di.OpenForOutput) continue;
                var fi = GetFileInfo(di.FileName);
                foreach (var fs in fi.SectorList)
                {
                    map[fs.Sector] = SectorMap.SectorTypes.Used;
                }

            }

            return map;
        }   
    
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Reads a file from the disk
        /// </summary>
        /// <param name="filename">Name of file to read</param>
        /// <returns>Byte array containing file data</returns>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        public override byte[] ReadFile(string filename, bool doNotThrowError)
        {
            var data = new List<byte>();
            int sectorCount = 0;

            Attach();

            //Find directory entry
            var entry = FindDirectoryEntry(filename);
            if (entry == null) throw new FileNotFoundException();

            var sector = entry.StartSector;

            while ((sectorCount < entry.NumSectors))
            {
                var fileSec = ReadFileSector(sector);
                sectorCount += 1;

                if (fileSec.FileHandle != -1 && fileSec.FileHandle != entry.FileNumber)
                {
                    if (doNotThrowError)
                    {
                        break;
                    }
                    else
                    {
                        throw new FileNumberMismatchException();
                    }
                }

                //Read sector data
                for (int i = 0; i < fileSec.ByteCount; i++)
                {
                    data.Add(fileSec.Data[i]);
                }

                //Get next sector number
                sector = fileSec.NextSector;
            }

            byte[] filedata = new byte[data.Count];
            data.CopyTo(filedata);
            return filedata;
        }



        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Adds a file to the disk
        /// </summary>
        /// <param name="Filename">Name of file being added</param>
        /// <param name="data">File data</param>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        public override void AddFile(string Filename, byte[] data)
        {
            DirectoryEntry entry;
            int curSector;
            int nextSector;
            int len;

            Attach();

            //Be sure filename is valid
            if (!ValidFileName(Filename))
            {
                throw new InvalidFileNameException();
            }

            //If file already exists, delete it
            entry = FindDirectoryEntry(Filename);
            if (entry != null)
            {
                DeleteFile(Filename);
            }

            // Check for disk space
            int dataLength = 0;
            if (data != null) dataLength = data.Length;
            int requiredSectors = (dataLength / 125);
            if (dataLength % 125 > 0) requiredSectors += 1;
            if (requiredSectors == 0) requiredSectors = 1;      // Files are always at least one sector
            if (requiredSectors > UnusedSectors()) throw new InsufficientDiskSpaceException();

            // Find open directory entry
            entry = GetOpenEntry();
            if (entry == null) throw new DirectoryFullException();

            entry.FileName = Filename;
            entry.Deleted = false;
            entry.EntryInUse = true;
            entry.Locked = false;
            entry.OpenForOutput = false;
            entry.StartSector = sectorMap.GetNextAvailableSector();
            entry.NumSectors = requiredSectors;

            curSector = entry.StartSector;
            for (int i = 0; i <= requiredSectors - 1; i++)
            {
                if ((dataLength - (i * 125)) <= 125)
                {
                    len = dataLength - (i * 125);
                    nextSector = 0;
                }
                else
                {
                    len = 125;
                    nextSector = sectorMap.GetNextAvailableSector();
                }

                var fileSec = new FileSector();
                fileSec.FileHandle = entry.FileNumber;
                fileSec.NextSector = nextSector;
                fileSec.ByteCount = len;
                fileSec.Data = new byte[125];

                if (data != null) Array.Copy(data, i * 125, fileSec.Data, 0, len);

                WriteFileSector(curSector, fileSec);

                curSector = nextSector;
            }

            WriteDirectoryEntry(entry);
            WriteSectorMap();

            //Refresh the directory
            ReadDirectory();

            UpdateUnusedSectors();
        }


        /// <summary>
        /// Renames a file
        /// </summary>
        /// <param name="oldName">Name of file to rename</param>
        /// <param name="newName">New name</param>
        public void RenameFile(string oldName, string newName)
        {
            DirectoryEntry entry;

            Attach();

            if (!ValidFileName(newName)) throw new InvalidFileNameException();
            if (oldName == newName) return;

            //Be sure file doesn't already exists
            entry = FindDirectoryEntry(newName);
            if (entry != null) throw new FileAlreadyExistsException();

            //Find directory entry of file to rename
            entry = FindDirectoryEntry(oldName);
            if (entry == null) throw new FileNotFoundException();

            //Chanmge filename
            entry.FileName = newName;
            WriteDirectoryEntry(entry);
        }

        /// <summary>
        /// Deletes a file from the disk
        /// </summary>
        /// <param name="filename">Name of file to delete</param>
        public override void DeleteFile(string filename)
        {
            int sector;
            byte[] sec;
            int sectorCount = 0;

            Attach();

            //Find directory entry
            DirectoryEntry entry = FindDirectoryEntry(filename);
            if (entry == null) throw new FileNotFoundException();

            //Remove file from sector map
            sector = entry.StartSector;
            while ((sectorCount < entry.NumSectors))
            {
                sec = ReadSector(sector);
                sectorCount += 1;

                //Check for filenumber mismatch
                if (((sec[125] & 0xfc) >> 2) != entry.FileNumber)
                {
                    throw new FileNumberMismatchException();
                }

                //Mark sector available
                sectorMap[sector] = SectorMap.SectorTypes.Available;

                //Get next sector number
                sector = ((sec[125] & 0x3) << 8) + sec[126];
            }

            WriteSectorMap();

            //Set flags
            entry.Deleted = true;
            entry.CreatedInDos2 = false;
            entry.EntryInUse = false;
            entry.Locked = false;
            entry.OpenForOutput = false;
            WriteDirectoryEntry(entry);

            //Set sector count
            UpdateUnusedSectors();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Checks if a character is valid for a DOS20 filename
        /// </summary>
        /// <param name="c">Character to check</param>
        /// <returns>True = valid/False = invalid</returns>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        protected bool ValidFileNameCharacter(char c)
        {
            int b = System.Convert.ToInt32(c);
            if (b == 32) return true;
            if (b < 48) return false;
            if (b > 57 & b < 65) return false;
            if (b > 90) return false;
            return true;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Check if a string contains characters that are valid for DOS20 filenames
        /// </summary>
        /// <param name="s">String to check</param>
        /// <returns>True = all valid characters/false = one or more invalid characters</returns>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        private bool ValidFilenameString(string s)
        {
            for (int i = 0; i <= s.Length - 1; i++)
            {
                if (!ValidFileNameCharacter(System.Convert.ToChar(s.Substring(i, 1)))) return false;
            }
            return true;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Check if a filename is valid for DOS2.0
        /// </summary>
        /// <param name="name">Filename to check</param>
        /// <returns>True = valid filename/false = invalid</returns>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        public override bool ValidFileName(string name)
        {
            string fname = Filename(name);
            string ext = FileExtension(name);

            // Verify lengths
            if (fname.Length < 1 | fname.Length > 8) return false;
            if (ext.Length > 3) return false;

            // Check first character of name
            if (fname.Substring(0, 1).CompareTo("A") < 0 || fname.Substring(0, 1).CompareTo("Z") > 0) return false;

            // Check for valid characters
            if (!ValidFilenameString(fname)) return false;
            if (!ValidFilenameString(ext)) return false;

            return true;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Returns the total number of sectors on the disk, used or unused as recorded in VTOC
        /// </summary>
        /// <returns>Sector count</returns>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        public override int AvailableSectors()
        {
            byte[] sec = ReadSector(360);
            return sec[2] * 256 + sec[1];
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Return the unused sector count as reported by the VTOC
        /// </summary>
        /// <returns>Unused sector count</returns>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        public override int UnusedSectors()
        {
            byte[] sec = ReadSector(360);
            return sec[4] * 256 + sec[3];
        }

        public override  int UnusedBytes()
        {   
            return UnusedSectors() * 125;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Updates the unused sector count in the VTOC
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        protected virtual void UpdateUnusedSectors()
        {
            int count = sectorMap.AvailableSectors();
            byte[] sec = ReadSector(360);
            sec[4] = (byte)(count >> 8);
            sec[3] = (byte)(count & 0xff);
            WriteSector(360, sec);
        }

        public override void Format(bool clearData)
        {
            int i;
            byte[] sec = new byte[128];

            // Clear sectors
            if (clearData)
            {
                for (i = 1; i <= diskImage.NumberOfSectors(); i++)
                {
                    diskImage.ClearSector(i);
                }
            }

            // Create sector map
            // sectorMap = new SectorMap(LastUsableSector + 1);
            sectorMap.ClearMap();
            sectorMap[0] = SectorMap.SectorTypes.Unusable;
            sectorMap[1] = SectorMap.SectorTypes.System;
            sectorMap[2] = SectorMap.SectorTypes.System;
            sectorMap[3] = SectorMap.SectorTypes.System;
            for (i = 360; i <= 368; i++)
            {
                sectorMap[i] = SectorMap.SectorTypes.System;
            }

            WriteSectorMap();

            // Write VTOC header
            sec = diskImage.ReadSector(360);
            sec[0] = 2;
            sec[1] = (byte)(LastUsableSector - SystemSectors & 0x00ff);
            sec[2] = (byte)(((LastUsableSector - SystemSectors) & 0xff00) >> 8);
            sec[3] = (707 & 0xff);
            sec[4] = (707 & 0xff00) >> 8;
            diskImage.WriteSector(360, sec);
        }

    }
}