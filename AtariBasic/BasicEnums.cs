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
    public static class BasicEnums
    {

        public enum OperatorTokens : byte
        {
            NumConstant = 14,
            StringConstant = 15
        }

        public enum FuncTokens : byte
        {
            STR = 61,
            CHR = 62,
            USR = 63,
            ASC = 64,
            VAL = 65,
            LEN = 66,
            ADR = 67,
            ATN = 68,
            COS = 69,
            PEEK = 70,
            SIN = 71,
            RND = 72,
            FRE = 73,
            EXP = 74,
            LOG = 75,
            CLOG = 76,
            SQR = 77,
            SGN = 78,
            ABS = 79,
            INT = 80,
            PADDLE = 81,
            STICK = 82,
            PTRIG = 83,
            STRIG = 84 
        }

        public enum CmdTokens : byte
        {
            REM = 00,
            DATA = 01,
            INPUT = 02,
            COLOR = 03,
            LIST = 04,
            ENTER = 05,
            LET = 06,
            IF = 07,
            FOR = 08,
            NEXT = 09,
            GOTO = 10,
            GO_TO = 11,
            GOSUB = 12,
            TRAP = 13,
            BYE = 14,
            CONT = 15,
            COM = 16,
            CLOSE = 17,
            CLR = 18,
            DEG = 19,
            DIM = 20,
            END = 21,
            NEW = 22,
            OPEN = 23,
            LOAD = 24,
            SAVE = 25,
            STATUS = 26,
            NOTE = 27,
            POINT = 28,
            XIO = 29,
            ON = 30,
            POKE = 31,
            PRINT = 32,
            RAD = 33,
            READ = 34,
            RESTORE = 35,
            RETURN = 36,
            RUN = 37,
            STOP = 38,
            POP = 39,
            QUESTIONMARK = 40,
            GET = 41,
            PUT = 42,
            GRAPHICS = 43,
            PLOT = 44,
            POSITION = 45,
            DOS = 46,
            DRAWTO = 47,
            SETCOLOR = 48,
            LOCATE = 49,
            SOUND = 50,
            LPRINT = 51,
            CSAVE = 52,
            CLOAD = 53,
            IMPLIEDLET = 54
        }
    }
}
