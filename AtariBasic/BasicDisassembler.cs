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


namespace AtariBasic
{
    public class UsrStatement
    {
        public enum CallTypes
        {
            ConstantADR = 0,
            StringADR = 1
        }

        public CallTypes callType { get; set; }
        public int LineNumber { get; set; }
        public int StatementNumber { get; set; }

    }
    public class BasicDisassembler : BasicProgram
    {
        int pos;

        public BasicDisassembler(byte[] data)
            : base(data)
        {
        }

        public string Disassemble()
        {
            int l;

            DecodeHeader();
            DecodeVariables();
            pos = DST;
            while (pos < DEND)
            {
                l = rawdata[pos + 2];
                ProcessLine();
                if (l == 0) break;
                pos += l;
            }

            return "";
        }

        public void ProcessLine()
        {
            int LineNum;
            int LineLen;
            int LineEnd;
            int LineStart;
            int statement;

            // Get line number
            LineStart = pos;
            LineNum = LSBMSB(pos);
            pos += 2;

            // End of program
            if (LineNum == 32768) return;

            // Get line length
            LineLen = rawdata[pos++];
            LineEnd = LineLen + pos - 3;

            // Handle statements until the end of the line
            while (pos < LineEnd)
            {
                statement = rawdata[pos + 1];
                ProcessStatement(LineStart);
                if (statement == 0)
                {
                    pos = LineEnd;
                    break;
                }
            }
        }

        private void ProcessStatement(int lineStart)
        {
            int StateLen;
            int endpos;
            byte statement = 0;

            StateLen = rawdata[pos++];
            endpos = lineStart + StateLen;

            // Get command
            statement = rawdata[pos++];
            if (statement > 0x37) throw new BasicFileFormatError();

            switch (statement)
            {
                case 6:     /* LET */
                case 54:    /* Implied Let */
                    ProcessLet();
                    break;
            }
        }

        private void ProcessLet()
        {
            int var = rawdata[pos++];
            pos++;
            int op = rawdata[pos++];
            if (op == 63)
            {
                ProcessUSR();
            }
            else if (op == 15)
            {
                ProcessStringConst();
            }
        }

        private void ProcessUSR()
        {
            pos++;
            switch (rawdata[pos++])
            {
                case 67:    /* Handle Addr */
                    break;
            }
        }

        private void ProcessStringConst()
        {

        }
    }
}

