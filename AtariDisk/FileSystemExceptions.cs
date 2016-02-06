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

namespace AtariDisk
{
    [SerializableAttribute]
    public class InvalidSectorException : System.Exception
    {

        public InvalidSectorException()
            : base("Invalid sector number")
        {
        }

        public InvalidSectorException(string message)
            : base(message)
        {
        }


    }

    [SerializableAttribute]
    public class FileNotFoundException : System.Exception
    {

        public FileNotFoundException()
            : base("File not found")
        {
        }

        public FileNotFoundException(string message)
            : base(message)
        {
        }

    }

    [SerializableAttribute]
    public class FileNumberMismatchException : System.Exception
    {

        public FileNumberMismatchException()
            : base("File number mismatch")
        {
        }

        public FileNumberMismatchException(string message)
            : base(message)
        {
        }
    }

    [SerializableAttribute]
    public class InvalidFileNameException : System.Exception
    {

        public InvalidFileNameException()
            : base("Invalid filename")
        {

        }

        public InvalidFileNameException(string message)
            : base(message)
        {
        }
    }

    [SerializableAttribute]
    public class InsufficientDiskSpaceException : System.Exception
    {

        public InsufficientDiskSpaceException()
            : base("Insufficient Disk Space")
        {
        }

        public InsufficientDiskSpaceException(string message)
            : base(message)
        {

        }
    }

    [SerializableAttribute]
    public class DirectoryFullException : System.Exception
    {

        public DirectoryFullException()
            : base("Disk directory is full")
        {

        }

        public DirectoryFullException(string message)
            : base(message)
        {

        }
    }

    [SerializableAttribute]
    public class FileAlreadyExistsException : System.Exception
    {

        public FileAlreadyExistsException()
            : base("The specified file already exists")
        {

        }

        public FileAlreadyExistsException(string message)
            : base(message)
        {

        }
    }

    [SerializableAttribute]
    public class InvalidBinaryLoadFileException : System.Exception
    {

        public InvalidBinaryLoadFileException()
            : base("The file isn't a valid binary load file")
        {

        }

        public InvalidBinaryLoadFileException(string message)
            : base("The file isn't a valid binary load file. " + message)
        {

        }
    }

    [SerializableAttribute]
    public class InvalidFileSystemException : System.Exception
    {

        public InvalidFileSystemException()
            : base("Invalid file system for this disk.")
        {

        }
    }
}