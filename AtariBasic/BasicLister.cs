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

namespace AtariBasic
{
    public class BasicLister : BasicProgram
    {
        private bool asciiLineBreak = true;

        private bool breakStatements = false;

        private string lineBreak = "\n\r";
        private AtasciiString program;

        private string[] commands = new string[] 
			{
				"REM","DATA","INPUT","COLOR","LIST","ENTER","LET","IF",
				"FOR","NEXT","GOTO","GO TO","GOSUB","TRAP","BYE","CONT",
				"COM","CLOSE","CLR","DEG","DIM","END","NEW","OPEN","LOAD",
				"SAVE","STATUS","NOTE","POINT","XIO","ON","POKE","PRINT",
				"RAD","READ","RESTORE","RETURN","RUN","STOP","POP","?", 
				"GET","PUT","GRAPHICS","PLOT","POSITION","DOS","DRAWTO",
				"SETCOLOR","LOCATE","SOUND","LPRINT","CSAVE","CLOAD","","ERROR - "};

        private string[] operators = new string[] 
			{
				"","",",","$",":",";","","GOTO","GOSUB"," TO "," STEP ",
				" THEN ","#","<=","<>",">=","<",">","=","^","*","+","-","/",
				"NOT"," OR "," AND ","(",")","=","=","<=","<>",">=","<",">","=",
				"+","-","(","(","(","(","(",",","STR$","CHR$","USR","ASC","VAL",
				"LEN","ADR","ATN","COS","PEEK","SIN","RND","FRE","EXP","LOG",
				"CLOG","SQR","SGN","ABS","INT","PADDLE","STICK","PTRING","STRIG"};

        public BasicLister(byte[] data)
            : base(data)
        {

            program = new AtasciiString();
        }

        public AtasciiString Program
        {
            get { return program; }
        }



        public bool BreakStatements
        {
            get { return breakStatements; }
            set { breakStatements = value; }
        }

        public bool AsciiLineBreak
        {
            get { return asciiLineBreak; }
            set
            {
                asciiLineBreak = value;
                if (value)
                {
                    lineBreak = "\n\r";
                }
                else
                {
                    char lb = (char)155;
                    lineBreak = lb.ToString();
                }

            }
        }

        public void DecodeProgram()
        {
            string s;
            int pos;
            int l;

            DecodeHeader();
            DecodeVariables();

            // FixVariables();

            pos = DST;
            while (pos < DEND)
            {
                s = DetokenizeLine(pos);
                if (s == "") break;
                program.Append(s);
                program.NewLine();
                l = rawdata[pos + 2];
                if (l == 0) break;
                pos += l;
            }
        }

        private string DetokenizeLine(int pos)
        {
            int LineNum;
            int LineLen;
            int LineEnd;
            int LineStart;
            string line = "";
            int statement;

            // Get line number
            LineStart = pos;
            LineNum = LSBMSB(pos);
            pos += 2;

            // End of program
            if (LineNum == 32768) return ("");

            // Add line number to detokenized line	
            line = String.Format("{0:#####} ", LineNum);

            // Get line length
            LineLen = rawdata[pos++];
            LineEnd = LineLen + pos - 3;

            // Handle statements until the end of the line
            while (pos < LineEnd)
            {
                statement = rawdata[pos + 1];
                line += DetokenizeStatement(ref pos, LineStart);
                if (statement == 0)
                {
                    pos = LineEnd;
                    break;
                }
            }
            return (line);
        }

        private string DetokenizeStatement(ref int pos, int lineStart)
        {
            int StateLen;
            string st = "";
            byte token = 0;
            int endpos;
            byte statement = 0;

            StateLen = rawdata[pos++];
            endpos = lineStart + StateLen;

            // Get command
            statement = rawdata[pos++];
            if (statement > 0x37) throw new BasicFileFormatError();

            // Add command text if it's not an implied LET
            if (statement != 54) st += commands[statement] + " ";

            // Handle REM and DATA
            if (statement == 0 || statement == 1)
            {
                while (pos < endpos)
                {
                    token = rawdata[pos++];

                    if (pos + 1 > rawdata.GetUpperBound(0)) return "";

                    if (token != 0x9B)
                    {
                        st += new string((Char)token, 1);
                    }
                    else
                    {
                        return st;
                    }
                }
                return st;
            }

            // Handle all other tokens
            while (token != 20 && token != 22 && pos < endpos)
            {
                if (pos + 1 > rawdata.GetUpperBound(0)) return "";

                token = rawdata[pos++];



                // Variable token
                if (token >= 0x80)
                {
                    st += VariableName(token - 0x80);
                    if (VariableType(token - 0x80) == VarType.String) st += "$";
                }

                // Operator token
                if (token >= 0x10 && token < 0x55) st += operators[token - 0x10];

                // String constant
                if (token == 0x0f) st += ParseString(ref pos);

                // Numeric constant
                if (token == 0x0E)
                {
                    st += ParseFP(pos);
                    pos += 6;
                }

            }

            if (breakStatements) st += string.Format("\n\r");

            return (st);
        }



        private string ParseString(ref int pos)
        {
            int i;
            string st = "";

            byte len = rawdata[pos++];
            st += (char)(34);
            for (i = 0; i < len; i++) st += new string((Char)rawdata[pos++], 1);
            st += (char)(34);

            return (st);
        }

        private string ParseFP(int pos)
        {
            string fp = "";
            byte exp;
            int i;
            int d;

            // Get exponenet
            exp = rawdata[pos++];

            // Handle zero special case
            if (exp == 0) return ("0");

            // Decode BCD 
            for (i = 0; i < 5; i++)
            {
                d = (rawdata[pos] & 0xF0) >> 4;
                if (d > 9) d = d - 10;
                fp += (char)(d + 48);
                d = (rawdata[pos++] & 0x0F);
                if (d > 9) d = d - 10;
                fp += (char)(d + 48);
            }

            // Insert decimal point
            if (exp < 63 || exp > 68)
            {
                if (fp.StartsWith("0"))
                    fp = fp.Insert(2, ".");
                else
                    fp = fp.Insert(1, ".");
            }
            else
            {
                fp = fp.Insert((exp - 63) * 2, ".");
            }

            fp = fp.TrimStart('0');
            fp = fp.TrimEnd('0');

            // Handle E format
            if (exp < 63 || exp > 68)
            {
                if (fp.EndsWith(".")) fp += "0";
                if (exp > 64)
                    fp += "E" + String.Format("+{0:##}", (exp - 64) * 2);
                else
                    fp += "E" + String.Format("{0:##}", (((exp - 64) * 2) + 1));
            }

            fp = fp.TrimEnd('.');
            if (fp.StartsWith(".")) fp = "0" + fp;

            return (fp);
        }
    }
}
