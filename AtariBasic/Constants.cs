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
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


namespace AtariBasic
{
    public class StringConstant : IBasicFunction
    {
        public string value = "";

        public AtasciiString List()
        {
            AtasciiString list = new AtasciiString();
            return list;
        }

        public object Eval()
        {
            return value;
        }
    }

    public class NumericConstant : IBasicFunction
    {
        public double value = 0;

        public AtasciiString List()
        {
            AtasciiString list = new AtasciiString();
            list.Append(value.ToString());
            return list;
        }

        public NumericConstant(byte[] data, ref int pos)
        {
            int exp = data[pos++];
            long weight = 1000000000;
            value = 0;

            for (int i = 0; i < 5; i++)
            {
                value += ((data[pos + i] & 0xF0) >> 4) * weight;
                weight /= 10;
                value += ((data[pos + i] & 0x0f) * weight);
                weight /= 10;
            }

            if (exp > 64)
            {
                value *= -1;
                value *= 10 ^ (exp - 64);
            }
            else
            {
                value *= 10 ^ exp;
            }

            pos += 5;
        }

        public object Eval()
        {
            return value;
        }
    }

}
