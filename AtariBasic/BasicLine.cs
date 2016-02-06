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

namespace AtariBasic
{
    public class BasicLine : IBasicCommand
    {
        int LineNumber;
        List<IBasicCommand> Statements = new List<IBasicCommand>();

        public AtasciiString List()
        {
            AtasciiString list = new AtasciiString();
            list.Append(LineNumber.ToString());
            list.Append(" ");
            foreach (IBasicCommand obj in Statements) list.Append(obj.List());
            return list;
        }

        public void Parse(byte[] data)
        {
            int pos = 3;
            int statementLen;

            LineNumber = BasicTree.LSBMSB(data, 0);
            while (pos < data.GetUpperBound(0))
            {
                statementLen = data[pos];
                if (pos + statementLen > data.GetLength(0)) statementLen = data.GetLength(0) - pos - 1;
                byte[] statementData = new byte[statementLen];
                Array.ConstrainedCopy(data, pos + 1, statementData, 0, statementLen - 1);
                pos = pos + statementLen;

                switch (statementData[0])
                {
                    case (byte)BasicEnums.CmdTokens.GRAPHICS:
                        Statements.Add(new CmdGraphics(statementData));
                        break;
                    default:
                        return;

                }
            }

        }
    }
}
