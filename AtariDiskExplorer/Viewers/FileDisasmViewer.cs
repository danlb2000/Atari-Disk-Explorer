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

using AtariDisk;
using System.Windows.Forms;

public class FileDisasmViewer : System.Windows.Forms.Form
{
#region " Windows Form Designer generated code "

	//Form overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing)
	{
		if (disposing) {
			if (!(components == null)) {
				components.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	//Required by the Windows Form Designer
	private System.ComponentModel.IContainer components = null;

	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.
	internal System.Windows.Forms.ComboBox cbSegments;
	internal System.Windows.Forms.TextBox txtDisasm;
	internal System.Windows.Forms.Button btSave;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.cbSegments = new System.Windows.Forms.ComboBox();
		this.txtDisasm = new System.Windows.Forms.TextBox();
		this.btSave = new System.Windows.Forms.Button();
		this.SuspendLayout();
		//
		//cbSegments
		//
		this.cbSegments.Location = new System.Drawing.Point(8, 8);
		this.cbSegments.Name = "cbSegments";
		this.cbSegments.Size = new System.Drawing.Size(304, 21);
		this.cbSegments.TabIndex = 0;
		//
		//txtDisasm
		//
		this.txtDisasm.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
		this.txtDisasm.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.txtDisasm.Location = new System.Drawing.Point(8, 32);
		this.txtDisasm.Multiline = true;
		this.txtDisasm.Name = "txtDisasm";
		this.txtDisasm.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtDisasm.Size = new System.Drawing.Size(376, 352);
		this.txtDisasm.TabIndex = 3;
		this.txtDisasm.Text = "";
		//
		//btSave
		//
		this.btSave.Location = new System.Drawing.Point(312, 8);
		this.btSave.Name = "btSave";
		this.btSave.Size = new System.Drawing.Size(72, 23);
		this.btSave.TabIndex = 4;
		this.btSave.Text = "Save . . .";
		//
		//FileDisasmViewer
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(392, 390);
		this.Controls.Add(this.btSave);
		this.Controls.Add(this.txtDisasm);
		this.Controls.Add(this.cbSegments);
		this.Name = "FileDisasmViewer";
		this.Text = "File Disassembly";
		this.ResumeLayout(false);

	}
#endregion

	private BinaryLoadFile _file;

	public FileDisasmViewer(BinaryLoadFile file)
	{
		InitializeComponent();

		_file = file;
	}

	private void FileDisasmViewer_Load(System.Object sender, System.EventArgs e)
	{
		for (int i = 0; i <= _file.SegmentCount - 1; i++) {
			cbSegments.Items.Add(_file.Segment(i).ToString());
		}
		cbSegments.SelectedIndex = 0;
	}

	private void cbSegments_SelectedIndexChanged(System.Object sender, System.EventArgs e)
	{
		BinaryLoadSegment seg;
		seg = _file.Segment(cbSegments.SelectedIndex);

		M6502DASM disasm = new M6502DASM(seg.Data, seg.StartAddress);
		txtDisasm.Text = disasm.Disassemble();
	}

	private void btSave_Click(System.Object sender, System.EventArgs e)
	{
		SaveFileDialog dialog = new SaveFileDialog();
		if (dialog.ShowDialog() == DialogResult.OK) {
			Disassembler disasm = new Disassembler();
			disasm.DisassembleBinaryLoadFile(_file, dialog.FileName);
		}
	}
}

