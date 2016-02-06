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
*/

using System;
using System.Text;

public class M6502DASM
{
    private int offset;
    private byte[] mem;

    // Instruction Mnemonics
    private enum m : int
    {
        XXX,
        ADC,
        AND,
        ASL,
        BIT,
        BCC,
        BCS,
        BEQ,
        BMI,
        BNE,
        BPL,
        BRK,
        BVC,
        BVS,
        CLC,
        CLD,
        CLI,
        CLV,
        CMP,
        CPX,
        CPY,
        DEC,
        DEX,
        DEY,
        EOR,
        INC,
        INX,
        INY,
        JMP,
        JSR,
        LDA,
        LDX,
        LDY,
        LSR,
        NOP,
        ORA,
        PLA,
        PLP,
        PHA,
        PHP,
        ROL,
        ROR,
        RTI,
        RTS,
        SEC,
        SEI,
        STA,
        SBC,
        SED,
        STX,
        STY,
        TAX,
        TAY,
        TSX,
        TXA,
        TXS,
        TYA,

        // Illegal/undefined opcodes
        isb,
        kil,
        lax,
        rla,
        sax,
        top
    }

    // Addressing Modes
    private enum a : int
    {
        REL,
        // Relative: $aa (branch instructions only)
        ZPG,
        // Zero Page: $aa
        ZPX,
        // Zero Page Indexed X: $aa,X
        ZPY,
        // Zero Page Indexed Y: $aa,Y
        ABS,
        // Absolute: $aaaa
        ABX,
        // Absolute Indexed X: $aaaa,X
        ABY,
        // Absolute Indexed Y: $aaaa,Y
        IDX,
        // Indexed Indirect: ($aa,X)		
        IDY,
        // Indirect Indexed: ($aa),Y	
        IND,
        // Indirect Absolute: ($aaaa) (JMP only)
        IMM,
        // Immediate: #aa
        IMP,
        // Implied
        ACC
        // Accumulator
    }

    private m[] MnemonicMatrix = { m.BRK, m.ORA, m.kil, 0, 0, m.ORA, m.ASL, 0, m.PHP, m.ORA, 
	m.ASL, 0, m.top, m.ORA, m.ASL, 0, m.BPL, m.ORA, m.kil, 0, 
	0, m.ORA, m.ASL, 0, m.CLC, m.ORA, 0, 0, m.top, m.ORA, 
	m.ASL, 0, m.JSR, m.AND, m.kil, 0, m.BIT, m.AND, m.ROL, 0, 
	m.PLP, m.AND, m.ROL, 0, m.BIT, m.AND, m.ROL, 0, m.BMI, m.AND, 
	m.kil, 0, 0, m.AND, m.ROL, 0, m.SEC, m.AND, 0, 0, 
	m.top, m.AND, m.ROL, m.rla, m.RTI, m.EOR, m.kil, 0, 0, m.EOR, 
	m.LSR, 0, m.PHA, m.EOR, m.LSR, 0, m.JMP, m.EOR, m.LSR, 0, 
	m.BVC, m.EOR, m.kil, 0, 0, m.EOR, m.LSR, 0, m.CLI, m.EOR, 
	0, 0, m.top, m.EOR, m.LSR, 0, m.RTS, m.ADC, m.kil, 0, 
	0, m.ADC, m.ROR, 0, m.PLA, m.ADC, m.ROR, 0, m.JMP, m.ADC, 
	m.ROR, 0, m.BVS, m.ADC, m.kil, 0, 0, m.ADC, m.ROR, 0, 
	m.SEI, m.ADC, 0, 0, m.top, m.ADC, m.ROR, 0, 0, m.STA, 
	0, m.sax, m.STY, m.STA, m.STX, m.sax, m.DEY, 0, m.TXA, 0, 
	m.STY, m.STA, m.STX, m.sax, m.BCC, m.STA, m.kil, 0, m.STY, m.STA, 
	m.STX, m.sax, m.TYA, m.STA, m.TXS, 0, m.top, m.STA, 0, 0, 
	m.LDY, m.LDA, m.LDX, m.lax, m.LDY, m.LDA, m.LDX, m.lax, m.TAY, m.LDA, 
	m.TAX, 0, m.LDY, m.LDA, m.LDX, m.lax, m.BCS, m.LDA, m.kil, m.lax, 
	m.LDY, m.LDA, m.LDX, m.lax, m.CLV, m.LDA, m.TSX, 0, m.LDY, m.LDA, 
	m.LDX, m.lax, m.CPY, m.CMP, 0, 0, m.CPY, m.CMP, m.DEC, 0, 
	m.INY, m.CMP, m.DEX, 0, m.CPY, m.CMP, m.DEC, 0, m.BNE, m.CMP, 
	m.kil, 0, 0, m.CMP, m.DEC, 0, m.CLD, m.CMP, 0, 0, 
	m.top, m.CMP, m.DEC, 0, m.CPX, m.SBC, 0, 0, m.CPX, m.SBC, 
	m.INC, 0, m.INX, m.SBC, m.NOP, 0, m.CPX, m.SBC, m.INC, m.isb, 
	m.BEQ, m.SBC, m.kil, 0, 0, m.SBC, m.INC, 0, m.SED, m.SBC, 
	0, 0, m.top, m.SBC, m.INC, m.isb };

    private a[] AddressingModeMatrix = { a.IMP, a.IDX, a.IMP, 0, 0, a.ZPG, a.ZPG, 0, a.IMP, a.IMM, 
	a.ACC, 0, a.ABS, a.ABS, a.ABS, 0, a.REL, a.IDY, a.IMP, 0, 
	0, a.ZPG, a.ZPG, 0, a.IMP, a.ABY, 0, 0, a.ABS, a.ABX, 
	a.ABX, 0, a.ABS, a.IDX, a.IMP, 0, a.ZPG, a.ZPG, a.ZPG, 0, 
	a.IMP, a.IMM, a.ACC, 0, a.ABS, a.ABS, a.ABS, 0, a.REL, a.IDY, 
	a.IMP, 0, 0, a.ZPG, a.ZPG, 0, a.IMP, a.ABY, 0, 0, 
	a.ABS, a.ABX, a.ABX, a.ABX, a.IMP, a.IDY, a.IMP, 0, 0, a.ZPG, 
	a.ZPG, 0, a.IMP, a.IMM, a.ACC, 0, a.ABS, a.ABS, a.ABS, 0, 
	a.REL, a.IDY, a.IMP, 0, 0, a.ZPG, a.ZPG, 0, a.IMP, a.ABY, 
	0, 0, a.ABS, a.ABX, a.ABX, 0, a.IMP, a.IDX, a.IMP, 0, 
	0, a.ZPG, a.ZPG, 0, a.IMP, a.IMM, a.ACC, 0, a.IND, a.ABS, 
	a.ABS, 0, a.REL, a.IDY, a.IMP, 0, 0, a.ZPX, a.ZPX, 0, 
	a.IMP, a.ABY, 0, 0, a.ABS, a.ABX, a.ABX, 0, 0, a.IDY, 
	0, a.IDX, a.ZPG, a.ZPG, a.ZPG, a.ZPG, a.IMP, 0, a.IMP, 0, 
	a.ABS, a.ABS, a.ABS, a.ABS, a.REL, a.IDY, a.IMP, 0, a.ZPX, a.ZPX, 
	a.ZPY, a.ZPY, a.IMP, a.ABY, a.IMP, 0, a.ABS, a.ABX, 0, 0, 
	a.IMM, a.IND, a.IMM, a.IDX, a.ZPG, a.ZPG, a.ZPG, a.ZPX, a.IMP, a.IMM, 
	a.IMP, 0, a.ABS, a.ABS, a.ABS, a.ABS, a.REL, a.IDY, a.IMP, a.IDY, 
	a.ZPX, a.ZPX, a.ZPY, a.ZPY, a.IMP, a.ABY, a.IMP, 0, a.ABX, a.ABX, 
	a.ABY, a.ABY, a.IMM, a.IDX, 0, 0, a.ZPG, a.ZPG, a.ZPG, 0, 
	a.IMP, a.IMM, a.IMP, 0, a.ABS, a.ABS, a.ABS, 0, a.REL, a.IDY, 
	a.IMP, 0, 0, a.ZPX, a.ZPX, 0, a.IMP, a.ABY, 0, 0, 
	a.ABS, a.ABX, a.ABX, 0, a.IMM, a.IDX, 0, 0, a.ZPG, a.ZPG, 
	a.ZPG, 0, a.IMP, a.IMM, a.IMP, 0, a.ABS, a.ABS, a.ABS, a.ABS, 
	a.REL, a.IDY, a.IMP, 0, 0, a.ZPX, a.ZPX, 0, a.IMP, a.ABY, 
	0, 0, a.ABS, a.ABX, a.ABX, a.ABX };

    public M6502DASM(byte[] Mem, int Offset)
    {
        mem = Mem;
        offset = Offset;
    }

    public string Disassemble()
    {
        int num_operands;
        int PC1;
        string addrmodeStr;
        StringBuilder s = new StringBuilder();
        bool dataOnly = false;
        int addr = 0;

        while ((addr < mem.Length))
        {
            num_operands = InstructionLength(mem[addr]) - 1;
            PC1 = addr + 1;

            if (mem.Length < addr + num_operands)
            {
                addrmodeStr = "";
                num_operands = mem.Length - addr - 1;
                dataOnly = true;
            }
            else
            {
                switch (AddressingModeMatrix[mem[addr]])
                {
                    case a.REL:

                        addrmodeStr = string.Format("${0:x4}", offset + addr + (mem[PC1]) + 2);
                        break;

                    case a.ABS:
                    case a.ZPG:
                        addrmodeStr = EA(PC1, num_operands);
                        break;
                    case a.ABX:
                    case a.ZPX:

                        addrmodeStr = EA(PC1, num_operands) + ",X";
                        break;
                    case a.ABY:
                    case a.ZPY:

                        addrmodeStr = EA(PC1, num_operands) + ",Y";
                        break;
                    case a.IDX:

                        addrmodeStr = "(" + EA(PC1, num_operands) + ",X)";
                        break;
                    case a.IDY:

                        addrmodeStr = "(" + EA(PC1, num_operands) + "),Y";
                        break;
                    case a.IND:

                        addrmodeStr = "(" + EA(PC1, num_operands) + ")";
                        break;
                    case a.IMM:

                        addrmodeStr = "#" + EA(PC1, num_operands);
                        break;
                    default:

                        // a.IMP, a.ACC
                        addrmodeStr = "";
                        break;
                }
            }

            //Append address
            s.Append(string.Format("{0:X4}: ", addr + offset));

            //Append data
            for (int i = 0; i <= 2; i++)
            {
                if (i <= num_operands && addr + i < mem.Length)
                {
                    s.Append(string.Format("{0:X2}", mem[addr + i]));
                    if (i != num_operands) s.Append(",");
                }
                else
                {
                    s.Append("   ");
                }
            }

            //Append instruction
            if (!dataOnly)
            {
                s.Append(string.Format(" {0} ", MnemonicMatrix[mem[addr]]));
                s.Append(addrmodeStr);
            }

            addr = addr + num_operands + 1;
            s.Append(Environment.NewLine);
        }

        return s.ToString();
    }

    private int InstructionLength(int opcode)
    {

        switch (AddressingModeMatrix[opcode])
        {
            case a.ACC:
            case a.IMP:
                return 1;
            case a.REL:
            case a.ZPG:
            case a.ZPX:
            case a.ZPY:
            case a.IDX:
            case a.IDY:
            case a.IMM:
                return 2;
            default:
                return 3;
        }
    }

    private string EA(int addr, int bytes)
    {
        if (addr > mem.GetUpperBound(0)) return "";

        byte lsb = mem[addr];
        byte msb = 0;

        if (bytes == 2)
        {
            msb = mem[addr + 1];
        }

        int address = (lsb | (msb << 8)) & 0xffff;

        if (bytes == 1)
        {
            return string.Format("${0:x2}", address);
        }
        else
        {
            return string.Format("${0:x4}", address);
        }
    }

}

