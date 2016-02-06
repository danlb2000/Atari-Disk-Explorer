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
using System.Text;

namespace AtariBasic
{
    public class BasicProgram
    {
        protected byte[] rawdata;
        private ArrayList vars;

        protected int LOMEM;
        protected int DVNT;
        protected int VNTE;
        protected int DVVT;
        protected int DST;
        protected int DEND;
        protected int STMCUR;

        public enum VarType : byte
        {
            Scalar = 0, Array = 1, String = 2
        }

        public BasicProgram(byte[] data)
        {
            rawdata = data;
        }

        public string dumpVariables()
        {
            int i;

            StringBuilder sb = new StringBuilder();

            for (i = 0; i < vars.Count - 1; i++)
            {
                sb.Append((string)VariableName(i));
                if (VariableType(i) == VarType.String) sb.Append("$");
                if (VariableType(i) == VarType.Array) sb.Append("()");
                sb.Append("\n\r");
            }
            return (sb.ToString());
        }

        protected ushort LSBMSB(int pos)
        {
            return ((ushort)((rawdata[pos + 1] * 256) + rawdata[pos]));
        }

        protected void DecodeHeader()
        {
            LOMEM = LSBMSB(0);
            DVNT = LSBMSB(2);
            VNTE = LSBMSB(4);
            DVVT = LSBMSB(6);
            DST = LSBMSB(8);
            STMCUR = LSBMSB(10);
            DEND = LSBMSB(12);

            // Correct pointer position
            int COR = DVNT - LOMEM - 0x0E;
            DVNT -= COR;
            VNTE -= COR;
            DVVT -= COR;
            DST -= COR;
            STMCUR -= COR;
            DEND -= COR;
        }

        protected void DecodeVariables()
        {
            ushort pos = (ushort)(DVNT);
            ushort end = (ushort)(DVVT);
            string var = "";

            vars = new ArrayList();

            while (pos < end)
            {
                var += (char)(rawdata[pos] & 0x7F);

                if ((rawdata[pos] & 0x80) == 0x80)
                {
                    vars.Add(var);
                    var = "";
                }
                pos++;
            }
        }

        protected void FixVariables()
        {
            for (int i = 0; i < vars.Count; i++)
            {
                vars[i] = "N" + i.ToString();
            }
        }

        public string VariableName(int index)
        {
            if (index > vars.Count - 1)
            {
                return "VAR" + index.ToString();
            }

            string v = (string)vars[index];
            if (v.EndsWith("(") || v.EndsWith("$"))
            {
                return v.Substring(0, v.Length - 1);
            }
            else
            {
                return v;
            }
        }

        public VarType VariableType(int index)
        {
            if (index > vars.Count - 1)
            {
                return VarType.Scalar;
            }

            string v = (string)vars[index];
            if (v.EndsWith("("))
            {
                return VarType.Array;
            }
            else if (v.EndsWith("$"))
            {
                return VarType.String;
            }
            else
            {
                return VarType.Scalar;
            }

        }

    }

    public class BasicFileFormatError : Exception
    {

    }
}
