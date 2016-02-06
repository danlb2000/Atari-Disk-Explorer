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


using AtariDisk.DiskImage;

public class SectorViewer : System.Windows.Forms.Form
{

    #region " Windows Form Designer generated code "

    //Form overrides dispose to clean up the component list.
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (!(components == null))
            {
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
    internal System.Windows.Forms.StatusBar StatusBar1;
    internal System.Windows.Forms.StatusBarPanel pnlCurrentSector;
    internal System.Windows.Forms.StatusBarPanel pnlTotalSectors;
    internal System.Windows.Forms.Button UIPrevSector;
    internal System.Windows.Forms.Button UINextSector;
    internal HexView viewer;
    internal System.Windows.Forms.TextBox UISector;
    internal System.Windows.Forms.Button UIFirstSector;
    internal System.Windows.Forms.Button UILastSector;
    [System.Diagnostics.DebuggerStepThrough()]
    private void InitializeComponent()
    {
        this.StatusBar1 = new System.Windows.Forms.StatusBar();
        this.pnlCurrentSector = new System.Windows.Forms.StatusBarPanel();
        this.pnlTotalSectors = new System.Windows.Forms.StatusBarPanel();
        this.UIPrevSector = new System.Windows.Forms.Button();
        this.UINextSector = new System.Windows.Forms.Button();
        this.UISector = new System.Windows.Forms.TextBox();
        this.UIFirstSector = new System.Windows.Forms.Button();
        this.UILastSector = new System.Windows.Forms.Button();
        this.viewer = new HexView();
        ((System.ComponentModel.ISupportInitialize)(this.pnlCurrentSector)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pnlTotalSectors)).BeginInit();
        this.SuspendLayout();
        // 
        // StatusBar1
        // 
        this.StatusBar1.Location = new System.Drawing.Point(0, 281);
        this.StatusBar1.Name = "StatusBar1";
        this.StatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.pnlCurrentSector,
            this.pnlTotalSectors});
        this.StatusBar1.ShowPanels = true;
        this.StatusBar1.Size = new System.Drawing.Size(544, 24);
        this.StatusBar1.TabIndex = 4;
        this.StatusBar1.Text = "StatusBar1";
        // 
        // pnlCurrentSector
        // 
        this.pnlCurrentSector.Name = "pnlCurrentSector";
        // 
        // pnlTotalSectors
        // 
        this.pnlTotalSectors.Name = "pnlTotalSectors";
        // 
        // UIPrevSector
        // 
        this.UIPrevSector.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        this.UIPrevSector.Location = new System.Drawing.Point(221, 255);
        this.UIPrevSector.Name = "UIPrevSector";
        this.UIPrevSector.Size = new System.Drawing.Size(24, 20);
        this.UIPrevSector.TabIndex = 6;
        this.UIPrevSector.Text = "<";
        this.UIPrevSector.Click += new System.EventHandler(this.UIPrevSector_Click);
        // 
        // UINextSector
        // 
        this.UINextSector.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        this.UINextSector.Location = new System.Drawing.Point(299, 255);
        this.UINextSector.Name = "UINextSector";
        this.UINextSector.Size = new System.Drawing.Size(24, 20);
        this.UINextSector.TabIndex = 7;
        this.UINextSector.Text = ">";
        this.UINextSector.Click += new System.EventHandler(this.UINextSector_Click);
        // 
        // UISector
        // 
        this.UISector.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        this.UISector.Location = new System.Drawing.Point(246, 256);
        this.UISector.Name = "UISector";
        this.UISector.Size = new System.Drawing.Size(52, 20);
        this.UISector.TabIndex = 9;
        this.UISector.TextChanged += new System.EventHandler(this.UISector_TextChanged);
        // 
        // UIFirstSector
        // 
        this.UIFirstSector.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        this.UIFirstSector.Location = new System.Drawing.Point(195, 255);
        this.UIFirstSector.Name = "UIFirstSector";
        this.UIFirstSector.Size = new System.Drawing.Size(24, 20);
        this.UIFirstSector.TabIndex = 10;
        this.UIFirstSector.Text = "|<";
        this.UIFirstSector.Click += new System.EventHandler(this.UIFirstSector_Click);
        // 
        // UILastSector
        // 
        this.UILastSector.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        this.UILastSector.Location = new System.Drawing.Point(325, 255);
        this.UILastSector.Name = "UILastSector";
        this.UILastSector.Size = new System.Drawing.Size(24, 20);
        this.UILastSector.TabIndex = 11;
        this.UILastSector.Text = ">|";
        this.UILastSector.Click += new System.EventHandler(this.UILastSector_Click);
        // 
        // viewer
        // 
        this.viewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.viewer.Location = new System.Drawing.Point(0, 0);
        this.viewer.Name = "viewer";
        this.viewer.Size = new System.Drawing.Size(544, 249);
        this.viewer.TabIndex = 8;
        // 
        // SectorViewer
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(544, 305);
        this.Controls.Add(this.UILastSector);
        this.Controls.Add(this.UIFirstSector);
        this.Controls.Add(this.UISector);
        this.Controls.Add(this.viewer);
        this.Controls.Add(this.UINextSector);
        this.Controls.Add(this.UIPrevSector);
        this.Controls.Add(this.StatusBar1);
        this.Name = "SectorViewer";
        this.Text = "Sector Viewer";
        this.Load += new System.EventHandler(this.SectorViewer_Load);
        ((System.ComponentModel.ISupportInitialize)(this.pnlCurrentSector)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pnlTotalSectors)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }
    #endregion

    private AbstractDiskImage _disk;
    private byte[] _data;
    private int _currentSector = 1;
    private int _lastSector = 1;

    public SectorViewer(AbstractDiskImage disk)
    {
        _disk = disk;
        _data = disk.ReadSector(1);

        InitializeComponent();
    }

    private void SectorViewer_Load(System.Object sender, System.EventArgs e)
    {
        UpdateDisplay();
        pnlTotalSectors.Text = _disk.NumberOfSectors().ToString();
    }

    private void vsAddress_ValueChanged(System.Object sender, System.EventArgs e)
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (!_disk.IsValidSector(_currentSector)) _currentSector = _lastSector;
        _lastSector = _currentSector;

        _data = _disk.ReadSector(_currentSector);
        viewer.Data = _data;
        viewer.RefreshDisplay();

        pnlCurrentSector.Text = _currentSector.ToString();
        UISector.Text = _currentSector.ToString();
    }

    private void UINextSector_Click(System.Object sender, System.EventArgs e)
    {
        _currentSector += 1;
        UpdateDisplay();
    }

    private void UIPrevSector_Click(System.Object sender, System.EventArgs e)
    {
        _currentSector -= 1;
        UpdateDisplay();
    }

    private void UILastSector_Click(System.Object sender, System.EventArgs e)
    {
        _currentSector = _disk.NumberOfSectors();
        UpdateDisplay();
    }

    private void UIFirstSector_Click(System.Object sender, System.EventArgs e)
    {
        _currentSector = 1;
        UpdateDisplay();
    }

    private void UISector_TextChanged(System.Object sender, System.EventArgs e)
    {
        int sector;
        if (int.TryParse(UISector.Text, out sector))
        {
            _currentSector = sector;
            UpdateDisplay();
        }
    }
}

