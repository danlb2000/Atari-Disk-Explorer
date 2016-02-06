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

using System.IO;
using System.Windows.Forms;
using AtariBasic;

public partial class AtasciiFileSaveForm
{

    private AtariBasic.AtasciiString atasciiData;

    public AtasciiFileSaveForm()
    {
        InitializeComponent();
    }

    public AtasciiFileSaveForm(AtariBasic.AtasciiString atasciiData)
    {
        InitializeComponent();
        this.atasciiData = atasciiData;
    }

    private void UIBrowse_Click(System.Object sender, System.EventArgs e)
    {
        SaveFileDialog dialog = new SaveFileDialog();

        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            UIFileName.Text = dialog.FileName;
        }
    }

    private void UICancel_Click(System.Object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void UIOK_Click(System.Object sender, System.EventArgs e)
    {
        if (UIFileName.Text == "")
        {

            System.Windows.Forms.MessageBox.Show("You must specify a filename", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        atasciiData.ConvertEOL = UIConvertEOL.Checked;

        if (UIAtasciiRaw.Checked)
        {
            atasciiData.AtasciiMode = AtasciiString.ATASCIIModes.Raw;
        }
        else if (UIAtasciiHex.Checked)
        {
            atasciiData.AtasciiMode = AtasciiString.ATASCIIModes.Hex;
        }
        else if (UIAtasciiDecimal.Checked)
        {
            atasciiData.AtasciiMode = AtasciiString.ATASCIIModes.Decimal;
        }

        if (UIInverseRaw.Checked)
        {
            atasciiData.InverseMode = AtasciiString.InverseModes.Raw;
        }
        else if (UIInverseBraces.Checked)
        {
            atasciiData.InverseMode = AtasciiString.InverseModes.Braces;
        }
        else if (UIInverseNoDelmit.Checked)
        {
            atasciiData.InverseMode = AtasciiString.InverseModes.NoDelimiter;
        }


        FileStream fs = null;
        StreamWriter sw = null;

        try
        {
            fs = new FileStream(UIFileName.Text, FileMode.Create);
            sw = new StreamWriter(fs);
            sw.Write(atasciiData.ToString());
        }
        catch (System.Exception ex)
        {
            MessageBox.Show("Error writing to export file. " + ex.Message, "Export error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            if (sw != null) sw.Close();
            if (fs != null) fs.Close();
        }

        this.Close();
    }

}

