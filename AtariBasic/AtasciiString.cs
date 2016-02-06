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
using System.Collections.Generic;
using System.Text;

namespace AtariBasic
{

    public class AtasciiString
    {

        /// <summary>
        /// Modes for converting inverse video to ASCII
        /// </summary>
        public enum InverseModes 
        {
            Raw = 0,  // Don't convert, include RAW ATASCII value
            NoDelimiter = 1, // Show character as if it was no inverse
            Braces = 2 // Show the character surrounded in braces
        }

        /// <summary>
        /// Modes for converting special ATASCII characters to ASCII
        /// </summary>
        public enum ATASCIIModes
        {
            Raw = 0, // Don't convert, include RAW ATASCII value
            Hex = 1,  // Show the character code in Hex
            Decimal = 2  // Show the character code in Deciaml
        }

        /// <summary>
        /// ATASCII character type
        /// </summary>
        public enum ATASCIICharType 
        {
            Normal = 0, NonAscii = 1, Inverse = 2
        }

        private List<byte> text;

        public ATASCIIModes AtasciiMode { get; set; }
        public InverseModes InverseMode { get; set; }
        public bool ConvertEOL { get; set; }

        /// <summary>
        /// ASCII characters in the ATASCII character set 
        /// </summary>
        private string[] ATASCII = new string[]
			{
				"","","","","","","","",
				"","","","","","","","",
				"","","","","","","","",
				"","","","","","","","",
				" ","!","","#","$","%","&","'",
				"(",")","*","+",",","-",".","/",
				"0","1","2","3","4","5","6","7",
				"8","9",":",";","<","=",">","?",
				"@","A","B","C","D","E","F","G",
				"H","I","J","K","L","M","N","O",
				"P","Q","R","S","T","U","V","W",
				"X","Y","Z","[","\\","]","^","_",
				"","a","b","c","d","e","f","g",
				"h","i","j","k","l","m","n","o",
				"p","q","r","s","t","u","v","w",
				"x","y","z","","|","","","",
				"","","","","","","","",
				"","","","","","","","",
				"","","","","","","","",
				"","","","","","","","",
				" ","!","","#","$","%","&","'",
				"(",")","*","+",",","-",".","/",
				"0","1","2","3","4","5","6","7",
				"8","9",":",";","<","=",">","?",
				"@","A","B","C","D","E","F","G",
				"H","I","J","K","L","M","N","O",
				"P","Q","R","S","T","U","V","W",
				"X","Y","Z","[","\\","]","^","_",
				"","a","b","c","d","e","f","g",
				"h","i","j","k","l","m","n","o",
				"p","q","r","s","t","u","v","w",
				"x","y","z","","|","","",""
				};

        /// <summary>
        /// Indetifies the type of each ATASCII character
        /// 0 = Normal, 1 = No ASCII character, 2 = Inverse
        /// </summary>
        private int[] ATASCIIType = new int[]
			{	
				1,1,1,1,1,1,1,1,
				1,1,1,1,1,1,1,1,
				1,1,1,1,1,1,1,1,
				1,1,1,1,1,1,1,1,
				0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,
				1,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,
				0,0,0,0,0,0,0,0,
				0,0,0,1,0,1,1,1,
				1,1,1,1,1,1,1,1,
				1,1,1,1,1,1,1,1,
				1,1,1,1,1,1,1,1,
				1,1,1,1,1,1,1,1,
				2,2,2,2,2,2,2,2,
				2,2,2,2,2,2,2,2,
				2,2,2,2,2,2,2,2,
				2,2,2,2,2,2,2,2,
				2,2,2,2,2,2,2,2,
				2,2,2,2,2,2,2,2,
				2,2,2,2,2,2,2,2,
				2,2,2,2,2,2,2,2,
				1,2,2,2,2,2,2,2,
				2,2,2,2,2,2,2,2,
				2,2,2,2,2,2,2,2,
				2,2,2,1,2,1,1,1
			};


        public AtasciiString()
        {
            ConvertEOL = false;
            AtasciiMode = ATASCIIModes.Raw;
            InverseMode = InverseModes.Raw;
            text = new List<byte>();
            ATASCII[34] += (char)(34);
            ATASCII[162] += (char)(34);
        }

        public AtasciiString(byte[] data)
            : this()
        {
            foreach (byte b in data) text.Add(b);
        }

        /// <summary>
        /// Append an ATASCII string to this one
        /// </summary>
        /// <param name="s"></param>
        public void Append(AtasciiString s)
        {
            Array bs = s.ToByteArray();
            foreach (byte b in bs) text.Add(b);
        }

        /// <summary>
        /// Append an ASCII string
        /// </summary>
        /// <param name="s"></param>
        public void Append(string s)
        {
            for (int i = 0; i < s.Length; i++) text.Add((byte)s[i]);
        }

        /// <summary>
        /// Add an ATASCII newline
        /// </summary>
        public void NewLine()
        {
            text.Add((byte)155);
        }

        /// <summary>
        /// Create a copy of the internal ATASCII byte array
        /// </summary>
        /// <returns></returns>
        public byte[] ToByteArray()
        {
            byte[] arr = new Byte[text.Count];
            text.CopyTo(arr);
            return arr;
        }

        /// <summary>
        /// Convert to ASCII string
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            StringBuilder s = new StringBuilder();

            foreach (Byte b in text) s.Append(ATASCIIConvert(b));
            return s.ToString();
        }

        /// <summary>
        /// Convert a single ATASCII character to ASCII
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private string ATASCIIConvert(byte c)
        {
            if (ConvertEOL && c == 155) return "\n".ToString();
            switch (ATASCIIType[c])
            {
                case 0:
                    return ATASCII[c];
                case 1:
                    switch (AtasciiMode)
                    {
                        case ATASCIIModes.Raw:
                            return new string((Char)c, 1);
                        case ATASCIIModes.Decimal:
                            return String.Format("~{0:X}~", c);
                        case ATASCIIModes.Hex:
                            return String.Format("~{0:D}~", c);
                        default:
                            return "";
                    }
                case 2:
                    switch (InverseMode)
                    {
                        case InverseModes.Raw:
                            return new string((Char)c, 1);
                        case InverseModes.Braces:
                            return "{" + ATASCII[c] + "}";
                        case InverseModes.NoDelimiter:
                            return ATASCII[c];
                        default:
                            return "";
                    }
                default:
                    return "";
            }
        }

    }
}
