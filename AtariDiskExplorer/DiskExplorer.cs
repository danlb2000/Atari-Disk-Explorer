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
using AtariDisk.DiskImage;
using AtariDisk.FileSystems;
using AtariDiskExplorer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

public class DirExplorer : System.Windows.Forms.Form
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
    private System.ComponentModel.IContainer components;

    //NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.
    internal System.Windows.Forms.ColumnHeader colName;
    internal System.Windows.Forms.ColumnHeader colSize;
    internal System.Windows.Forms.ListView lvFiles;
    internal System.Windows.Forms.MainMenu MainMenu1;
    internal System.Windows.Forms.MenuItem MenuItem1;
    internal System.Windows.Forms.MenuItem itmHexView;
    internal System.Windows.Forms.ContextMenu ContextMenuView;
    internal System.Windows.Forms.MenuItem itmHexViewCM;
    internal System.Windows.Forms.StatusBar StatusBar;
    internal System.Windows.Forms.StatusBarPanel pnlFreeSectors;
    internal System.Windows.Forms.StatusBarPanel pnlTotalSectors;
    internal System.Windows.Forms.MenuItem MenuItem2;
    internal System.Windows.Forms.MenuItem itmAddFile;
    internal System.Windows.Forms.MenuItem itmExtractFile;
    internal System.Windows.Forms.MenuItem itmDeleteFile;
    internal System.Windows.Forms.MenuItem itmExtractCM;
    internal System.Windows.Forms.MenuItem itmBinaryDisasm;
    internal System.Windows.Forms.MenuItem MenuItem3;
    internal System.Windows.Forms.MenuItem itmViewSectors;
    internal System.Windows.Forms.MenuItem itmAtasciiView;
    internal System.Windows.Forms.MenuItem itmAtariBasicView;
    internal System.Windows.Forms.MenuItem UIShowBootRecord;
    internal System.Windows.Forms.ColumnHeader colNumber;
    internal System.Windows.Forms.ToolStrip ToolStrip1;
    internal System.Windows.Forms.ToolStripComboBox UIFileSystemSelect;
    internal System.Windows.Forms.MenuItem itmShowImageProperties;
    internal System.Windows.Forms.MenuItem itmExtractAll;
    private MenuItem itmChangeDirSectors;
    private MenuItem itmFindDirectory;
    private ColumnHeader colDeleted;
    private MenuItem itmViewFileInfo;
    private MenuItem itmShowSectorMap;
    private MenuItem itmSynAssemblerView;
    private ToolStripTextBox UIDirectoryError;
    private ToolStripTextBox UIFileErrors;
    private ToolStripTextBox UISectorMapErrors;
    private MenuItem miDumpDirectory;
    internal System.Windows.Forms.ColumnHeader colStartSector;
    [System.Diagnostics.DebuggerStepThrough()]
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStartSector = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDeleted = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContextMenuView = new System.Windows.Forms.ContextMenu();
            this.itmHexViewCM = new System.Windows.Forms.MenuItem();
            this.itmExtractCM = new System.Windows.Forms.MenuItem();
            this.itmAtasciiView = new System.Windows.Forms.MenuItem();
            this.itmAtariBasicView = new System.Windows.Forms.MenuItem();
            this.itmSynAssemblerView = new System.Windows.Forms.MenuItem();
            this.MainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.MenuItem1 = new System.Windows.Forms.MenuItem();
            this.itmHexView = new System.Windows.Forms.MenuItem();
            this.itmBinaryDisasm = new System.Windows.Forms.MenuItem();
            this.MenuItem3 = new System.Windows.Forms.MenuItem();
            this.itmViewSectors = new System.Windows.Forms.MenuItem();
            this.UIShowBootRecord = new System.Windows.Forms.MenuItem();
            this.itmShowImageProperties = new System.Windows.Forms.MenuItem();
            this.itmChangeDirSectors = new System.Windows.Forms.MenuItem();
            this.itmFindDirectory = new System.Windows.Forms.MenuItem();
            this.itmShowSectorMap = new System.Windows.Forms.MenuItem();
            this.MenuItem2 = new System.Windows.Forms.MenuItem();
            this.itmAddFile = new System.Windows.Forms.MenuItem();
            this.itmExtractFile = new System.Windows.Forms.MenuItem();
            this.itmExtractAll = new System.Windows.Forms.MenuItem();
            this.itmDeleteFile = new System.Windows.Forms.MenuItem();
            this.itmViewFileInfo = new System.Windows.Forms.MenuItem();
            this.StatusBar = new System.Windows.Forms.StatusBar();
            this.pnlFreeSectors = new System.Windows.Forms.StatusBarPanel();
            this.pnlTotalSectors = new System.Windows.Forms.StatusBarPanel();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.UIFileSystemSelect = new System.Windows.Forms.ToolStripComboBox();
            this.UIDirectoryError = new System.Windows.Forms.ToolStripTextBox();
            this.UIFileErrors = new System.Windows.Forms.ToolStripTextBox();
            this.UISectorMapErrors = new System.Windows.Forms.ToolStripTextBox();
            this.miDumpDirectory = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFreeSectors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTotalSectors)).BeginInit();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvFiles
            // 
            this.lvFiles.AllowDrop = true;
            this.lvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colSize,
            this.colNumber,
            this.colStartSector,
            this.colDeleted});
            this.lvFiles.ContextMenu = this.ContextMenuView;
            this.lvFiles.Location = new System.Drawing.Point(0, 28);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(432, 244);
            this.lvFiles.TabIndex = 0;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 120;
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            // 
            // colNumber
            // 
            this.colNumber.Text = "Number";
            this.colNumber.Width = 75;
            // 
            // colStartSector
            // 
            this.colStartSector.Text = "Start Sector";
            this.colStartSector.Width = 77;
            // 
            // colDeleted
            // 
            this.colDeleted.Text = "Deleted";
            // 
            // ContextMenuView
            // 
            this.ContextMenuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.itmHexViewCM,
            this.itmExtractCM,
            this.itmAtasciiView,
            this.itmAtariBasicView,
            this.itmSynAssemblerView});
            // 
            // itmHexViewCM
            // 
            this.itmHexViewCM.Index = 0;
            this.itmHexViewCM.Text = "&Hex Viewer";
            this.itmHexViewCM.Click += new System.EventHandler(this.itmHexViewCM_Click);
            // 
            // itmExtractCM
            // 
            this.itmExtractCM.Index = 1;
            this.itmExtractCM.Text = "&Extract";
            this.itmExtractCM.Click += new System.EventHandler(this.itmExtractCM_Click);
            // 
            // itmAtasciiView
            // 
            this.itmAtasciiView.Index = 2;
            this.itmAtasciiView.Text = "ATASCII View";
            this.itmAtasciiView.Click += new System.EventHandler(this.itmAtasciiView_Click);
            // 
            // itmAtariBasicView
            // 
            this.itmAtariBasicView.Index = 3;
            this.itmAtariBasicView.Text = "Atari Basic View";
            this.itmAtariBasicView.Click += new System.EventHandler(this.itmAtariBasicView_Click);
            // 
            // itmSynAssemblerView
            // 
            this.itmSynAssemblerView.Index = 4;
            this.itmSynAssemblerView.Text = "Syn Assembler View";
            this.itmSynAssemblerView.Click += new System.EventHandler(this.itmSynAssemblerView_Click);
            // 
            // MainMenu1
            // 
            this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem1,
            this.MenuItem3,
            this.MenuItem2});
            // 
            // MenuItem1
            // 
            this.MenuItem1.Index = 0;
            this.MenuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.itmHexView,
            this.itmBinaryDisasm});
            this.MenuItem1.Text = "&View";
            // 
            // itmHexView
            // 
            this.itmHexView.Index = 0;
            this.itmHexView.Text = "Hex View";
            this.itmHexView.Click += new System.EventHandler(this.itmHexViewCM_Click);
            // 
            // itmBinaryDisasm
            // 
            this.itmBinaryDisasm.Index = 1;
            this.itmBinaryDisasm.Text = "Binary Disassembly";
            this.itmBinaryDisasm.Click += new System.EventHandler(this.itmBinaryDisasm_Click);
            // 
            // MenuItem3
            // 
            this.MenuItem3.Index = 1;
            this.MenuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.itmViewSectors,
            this.UIShowBootRecord,
            this.itmShowImageProperties,
            this.itmChangeDirSectors,
            this.itmFindDirectory,
            this.itmShowSectorMap});
            this.MenuItem3.Text = "&Disk";
            // 
            // itmViewSectors
            // 
            this.itmViewSectors.Index = 0;
            this.itmViewSectors.Text = "&View Sectors ...";
            this.itmViewSectors.Click += new System.EventHandler(this.itmViewSectors_Click);
            // 
            // UIShowBootRecord
            // 
            this.UIShowBootRecord.Index = 1;
            this.UIShowBootRecord.Text = "Show Boot Record";
            this.UIShowBootRecord.Click += new System.EventHandler(this.UIShowBootRecord_Click);
            // 
            // itmShowImageProperties
            // 
            this.itmShowImageProperties.Index = 2;
            this.itmShowImageProperties.Text = "Show Image Properties ...";
            this.itmShowImageProperties.Click += new System.EventHandler(this.itmShowImageProperties_Click);
            // 
            // itmChangeDirSectors
            // 
            this.itmChangeDirSectors.Index = 3;
            this.itmChangeDirSectors.Text = "Change Dir Sectors...";
            this.itmChangeDirSectors.Click += new System.EventHandler(this.itmChangeDirSectors_Click);
            // 
            // itmFindDirectory
            // 
            this.itmFindDirectory.Index = 4;
            this.itmFindDirectory.Text = "Find Directory";
            this.itmFindDirectory.Click += new System.EventHandler(this.itmFindDirectory_Click);
            // 
            // itmShowSectorMap
            // 
            this.itmShowSectorMap.Index = 5;
            this.itmShowSectorMap.Text = "Show Sector Map...";
            this.itmShowSectorMap.Click += new System.EventHandler(this.itmShowSectorMap_Click);
            // 
            // MenuItem2
            // 
            this.MenuItem2.Index = 2;
            this.MenuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.itmAddFile,
            this.itmExtractFile,
            this.itmExtractAll,
            this.itmDeleteFile,
            this.itmViewFileInfo,
            this.miDumpDirectory});
            this.MenuItem2.Text = "&Tools";
            // 
            // itmAddFile
            // 
            this.itmAddFile.Index = 0;
            this.itmAddFile.Text = "&Add File...";
            this.itmAddFile.Click += new System.EventHandler(this.itmAddFile_Click);
            // 
            // itmExtractFile
            // 
            this.itmExtractFile.Index = 1;
            this.itmExtractFile.Text = "&Extract File...";
            this.itmExtractFile.Click += new System.EventHandler(this.itmExtractCM_Click);
            // 
            // itmExtractAll
            // 
            this.itmExtractAll.Index = 2;
            this.itmExtractAll.Text = "Extract All...";
            this.itmExtractAll.Click += new System.EventHandler(this.itmExtractAll_Click);
            // 
            // itmDeleteFile
            // 
            this.itmDeleteFile.Index = 3;
            this.itmDeleteFile.Text = "&Delete File...";
            this.itmDeleteFile.Click += new System.EventHandler(this.itmDeleteFile_Click);
            // 
            // itmViewFileInfo
            // 
            this.itmViewFileInfo.Index = 4;
            this.itmViewFileInfo.Text = "View File Info...";
            this.itmViewFileInfo.Click += new System.EventHandler(this.itmViewFileInfo_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 278);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.pnlFreeSectors,
            this.pnlTotalSectors});
            this.StatusBar.ShowPanels = true;
            this.StatusBar.Size = new System.Drawing.Size(428, 22);
            this.StatusBar.TabIndex = 1;
            // 
            // pnlFreeSectors
            // 
            this.pnlFreeSectors.Name = "pnlFreeSectors";
            this.pnlFreeSectors.Width = 70;
            // 
            // pnlTotalSectors
            // 
            this.pnlTotalSectors.Name = "pnlTotalSectors";
            this.pnlTotalSectors.Width = 70;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UIFileSystemSelect,
            this.UIDirectoryError,
            this.UIFileErrors,
            this.UISectorMapErrors});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(428, 25);
            this.ToolStrip1.TabIndex = 2;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // UIFileSystemSelect
            // 
            this.UIFileSystemSelect.Items.AddRange(new object[] {
            "None",
            "DOS2.0",
            "DOS2.5",
            "MegaImage"});
            this.UIFileSystemSelect.Name = "UIFileSystemSelect";
            this.UIFileSystemSelect.Size = new System.Drawing.Size(121, 25);
            this.UIFileSystemSelect.SelectedIndexChanged += new System.EventHandler(this.UIFileSystemSelect_SelectedIndexChanged);
            // 
            // UIDirectoryError
            // 
            this.UIDirectoryError.Name = "UIDirectoryError";
            this.UIDirectoryError.ReadOnly = true;
            this.UIDirectoryError.Size = new System.Drawing.Size(70, 25);
            this.UIDirectoryError.Text = "Directory";
            this.UIDirectoryError.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UIFileErrors
            // 
            this.UIFileErrors.Name = "UIFileErrors";
            this.UIFileErrors.Size = new System.Drawing.Size(70, 25);
            this.UIFileErrors.Text = "Files";
            this.UIFileErrors.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UISectorMapErrors
            // 
            this.UISectorMapErrors.Name = "UISectorMapErrors";
            this.UISectorMapErrors.Size = new System.Drawing.Size(70, 25);
            this.UISectorMapErrors.Text = "Sector Map";
            this.UISectorMapErrors.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // miDumpDirectory
            // 
            this.miDumpDirectory.Index = 5;
            this.miDumpDirectory.Text = "Dump Directory";
            this.miDumpDirectory.Click += new System.EventHandler(this.miDumpDirectory_Click);
            // 
            // DirExplorer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(428, 300);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.lvFiles);
            this.Menu = this.MainMenu1;
            this.Name = "DirExplorer";
            this.Text = "DiskExplorer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DirExplorer_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFreeSectors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTotalSectors)).EndInit();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    #endregion

    private FileSystem fileSystem;
    private AbstractDiskImage disk;

    private enum FileViewTypes
    {
        Hex = 1,
        ATASCII = 2
    }

    public DirExplorer(string FileName)
    {
        disk = DiskImageFactory.NewDiskImage(FileName);

        InitializeComponent();
        disk.Mount(FileName);

        this.Text = FileName.Substring(FileName.LastIndexOf("\\") + 1);
        UIFileSystemSelect.SelectedItem = "None";
        UpdateList();

     
    }

    public void UpdateMenuItems()
    {
        itmShowSectorMap.Enabled = fileSystem.HasCapability(FileSystem.Capabilities.SectorMap);
        itmChangeDirSectors.Enabled = fileSystem.HasCapability(FileSystem.Capabilities.Directory);
        itmFindDirectory.Enabled = fileSystem.HasCapability(FileSystem.Capabilities.Directory);
        itmAddFile.Enabled = fileSystem.HasCapability(FileSystem.Capabilities.Directory);
        itmDeleteFile.Enabled = fileSystem.HasCapability(FileSystem.Capabilities.Directory);
        itmExtractFile.Enabled = fileSystem.HasCapability(FileSystem.Capabilities.Directory);
        itmExtractAll.Enabled = fileSystem.HasCapability(FileSystem.Capabilities.Directory);
        itmViewFileInfo.Enabled = fileSystem.HasCapability(FileSystem.Capabilities.Directory);
    }

    public void UpdateList()
    {
        List<DirectoryEntry> dir;
        ListViewItem lvItem;

        lvFiles.Items.Clear();
        if ((string)UIFileSystemSelect.SelectedItem == "None") return;

        dir = fileSystem.DiskDirectory();

        foreach (DirectoryEntry entry in dir)
        {
            if (entry.EntryInUse && !entry.OpenForOutput)
            {
                lvItem = new ListViewItem(entry.FileName);
                lvItem.SubItems.Add(entry.NumSectors.ToString());
                lvItem.SubItems.Add(entry.FileNumber.ToString());
                lvItem.SubItems.Add(entry.StartSector.ToString());
                if (entry.Deleted)
                    lvItem.SubItems.Add("Y");
                else
                    lvItem.SubItems.Add("");

                lvFiles.Items.Add(lvItem);

                var errorlist = new List<String>();
                if (!fileSystem.IsFileValid(entry.FileName, errorlist) || !entry.ValidEntry)
                {
                    lvItem.BackColor = System.Drawing.Color.Red;
                }

                if (entry.Deleted) lvItem.BackColor = System.Drawing.Color.Yellow;

            }
        }

        pnlFreeSectors.Text = String.Format("Free: {0}", fileSystem.UnusedSectors());
        pnlTotalSectors.Text = String.Format("Total: {0}", fileSystem.AvailableSectors());
    }

    private void itmExtractCM_Click(System.Object sender, System.EventArgs e)
    {
        ListViewItem lvCurrent = lvFiles.FocusedItem;
        if (lvCurrent == null) return;

        //Prompt for save filename
        SaveFileDialog dialog = new SaveFileDialog();
        dialog.FileName = lvCurrent.Text;
        if (dialog.ShowDialog() != DialogResult.OK) return;

        try
        {
            ExtractFile(lvCurrent.Text, dialog.FileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error extracting file " + ex.Message, "Extract File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private string ExtractFile(string sourceFile, string destFile)
    {
        //Read file from Atari disk
        byte[] data;

        try
        {
            data = fileSystem.ReadFile(sourceFile, false);
        }
        catch (Exception ex)
        {
            return string.Format("Could not read file {0}: {1}", sourceFile, ex.Message);
        }

        //Write data to host disk
        FileStream fs = null;
        BinaryWriter bw = null;
        try
        {
            fs = new FileStream(destFile, FileMode.Create);
            bw = new BinaryWriter(fs);
            bw.Write(data);
            bw.Close();
            fs.Close();
        }
        catch (Exception ex)
        {
            return string.Format("Could not write file {0}: {1}", destFile, ex.Message);
        }
        finally
        {
            if (bw != null) bw.Close();
            if (fs != null) fs.Close();
        }

        return "";
    }

    private void itmDeleteFile_Click(System.Object sender, System.EventArgs e)
    {
        ListViewItem lvCurrent = lvFiles.FocusedItem;
        if (lvCurrent == null) return;

        var result = MessageBox.Show("Are you sure you want to delete " + lvCurrent.Text + "?", "Delete File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

        if (result != System.Windows.Forms.DialogResult.Yes) return;

        try
        {
            fileSystem.DeleteFile(lvCurrent.Text);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error deleting file: " + ex.Message, "File Delete Error", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
        }
       
        UpdateList();
    }

    private void itmBinaryDisasm_Click(System.Object sender, System.EventArgs e)
    {
        //Read file from Atari disk
        byte[] data = LoadSelectedFile();
        if (data == null) return;

        BinaryLoadFile bfile;

        try
        {
            bfile = new BinaryLoadFile(data);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not load binary file. " + ex.Message);
            return;
        }

        FileDisasmViewer frmView = new FileDisasmViewer(bfile);
        frmView.MdiParent = this.MdiParent;
        frmView.Show();
    }

    private void itmViewSectors_Click(System.Object sender, System.EventArgs e)
    {
        SectorViewer frmSectorView = new SectorViewer(disk);
        frmSectorView.MdiParent = this.MdiParent;
        frmSectorView.Show();
    }

    private void itmHexViewCM_Click(System.Object sender, System.EventArgs e)
    {
        ViewFile(FileViewTypes.Hex);
    }

    private void itmAtasciiView_Click(System.Object sender, System.EventArgs e)
    {
        ViewFile(FileViewTypes.ATASCII);
    }

    private byte[] LoadSelectedFile()
    {
        ListViewItem lvCurrent = lvFiles.FocusedItem;
        if (lvCurrent == null) return null;

        //Read file from Atari disk
        byte[] data;

        try
        {
            data = fileSystem.ReadFile(lvCurrent.Text, false);
        }
        catch (FileNumberMismatchException ex)
        {
            MessageBox.Show(ex.Message + ". Displaying partial file.");
            data = fileSystem.ReadFile(lvCurrent.Text, true);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error reading file. " + ex.Message);
            return null;
        }

        return data;
    }

    private string SelectedFileName()
    {
        ListViewItem lvCurrent = lvFiles.FocusedItem;
        if (lvCurrent == null) return "";
        return lvCurrent.Text;
    }

    private void ViewFile(FileViewTypes type)
    {
        byte[] data = LoadSelectedFile();

        if (data == null) return;


        switch (type)
        {
            case FileViewTypes.ATASCII:
                AtasciiFileViewer frmAtViewer = new AtasciiFileViewer(data);
                frmAtViewer.Title = SelectedFileName();
                frmAtViewer.MdiParent = this.MdiParent;
                frmAtViewer.Show();
                break;
            case FileViewTypes.Hex:
                HexFileViewer frmHexViewer = new HexFileViewer(data);
                frmHexViewer.Title = SelectedFileName();
                frmHexViewer.MdiParent = this.MdiParent;
                frmHexViewer.Show();
                break;
        }
    }

    private void itmSynAssemblerView_Click(object sender, EventArgs e)
    {
        byte[] data = LoadSelectedFile();
        if (data == null) return;

        var asm = new SynAssemblerLister(data);

        asm.AsciiLineBreak = false;
        try
        {
            asm.DecodeProgram();
        }
        catch
        {
        }

        AtasciiFileViewer frmViewer = new AtasciiFileViewer(asm.Program.ToByteArray());
        frmViewer.Title = SelectedFileName();
        frmViewer.MdiParent = this.MdiParent;
        frmViewer.Show();
    }


    private void itmAtariBasicView_Click(System.Object sender, System.EventArgs e)
    {
        byte[] data = LoadSelectedFile();
        if (data == null) return;

        AtariBasic.BasicLister basic = new AtariBasic.BasicLister(data);
        basic.AsciiLineBreak = false;
        try
        {
            basic.DecodeProgram();
        }
        catch
        {
        }

        AtasciiFileViewer frmViewer = new AtasciiFileViewer(basic.Program.ToByteArray());
        frmViewer.Title = SelectedFileName();
        frmViewer.MdiParent = this.MdiParent;
        frmViewer.Show();
    }

    public static byte[] StrToByteArray(string str)
    {
        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
        return encoding.GetBytes(str);
    }

    private void UIFileSystemSelect_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        fileSystem = FileSystemFactory.MakeFileSystem((string)UIFileSystemSelect.SelectedItem, disk);
        try
        {
            fileSystem.Attach();

            var errors = fileSystem.IsDiskValid();
            if (errors != 0)
            {
                MessageBox.Show("WARNING: This disk image has one or more errors. Making any changes to the files on this disk may lead to un-expected results.", "Disk Has Errors", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             
           
            }

            if ((errors & FileSystem.Error.Directory) > 0)
                UIDirectoryError.BackColor = System.Drawing.Color.Red;
            else
                UIDirectoryError.BackColor = System.Drawing.Color.LightGreen;

            if ((errors & FileSystem.Error.File) > 0)              
                UIFileErrors.BackColor = System.Drawing.Color.Red;
            else
                UIFileErrors.BackColor = System.Drawing.Color.LightGreen;
           
            if ((errors & FileSystem.Error.SectorMap) > 0)
                UISectorMapErrors.BackColor = System.Drawing.Color.Red;
            else
                UISectorMapErrors.BackColor = System.Drawing.Color.LightGreen;


        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not attach file system. " + ex.Message);
            UIFileSystemSelect.SelectedItem = "None";
        }
        UpdateList();
        UpdateMenuItems();
    }

    private void UIShowBootRecord_Click(System.Object sender, System.EventArgs e)
    {
        BootRecordForm frm = new BootRecordForm(disk);
        frm.MdiParent = this.MdiParent;
        frm.Title = disk.FileName.Substring(disk.FileName.LastIndexOf("\\") + 1);
        frm.Show();
    }

    private void itmShowImageProperties_Click(System.Object sender, System.EventArgs e)
    {
        DiskImageProperies frm = new DiskImageProperies(disk);
        frm.MdiParent = this.MdiParent;
        frm.Title = disk.FileName.Substring(disk.FileName.LastIndexOf("\\") + 1);
        frm.Show();
    }

    private void itmAddFile_Click(System.Object sender, System.EventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        string filenameToAdd;
        string nameToAdd;

        //Get file name to add
        if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

        filenameToAdd = dialog.FileName;

        //Get valid filename for filesystem
        nameToAdd = Path.GetFileName(filenameToAdd).ToUpper();
        while ((!fileSystem.ValidFileName(nameToAdd)))
        {
            InputBoxForm.InputBox("Enter Valid Name", "Filename is not valid for this file system, please enter a valid name", ref nameToAdd);
            if (nameToAdd == "") return;
        }

        //Read file to add
        var myFile = new System.IO.FileInfo(filenameToAdd);
        byte[] fileData = new byte[myFile.Length];
        using (var fs = new FileStream(filenameToAdd, FileMode.Open, FileAccess.Read))
        {
            using (var br = new BinaryReader(fs))
            {
                fileData = br.ReadBytes((int)myFile.Length);
                br.Close();
            }
            fs.Close();
        }

        if (fileData.Length > fileSystem.UnusedBytes())
        {
            MessageBox.Show("Not enough space on the disk for this file.", "Disk Space Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        fileSystem.AddFile(nameToAdd, fileData);

        UpdateList();
    }

    private void itmExtractAll_Click(System.Object sender, System.EventArgs e)
    {
        //Prompt for save filename
        FolderBrowserDialog dialog = new FolderBrowserDialog();
        if (dialog.ShowDialog() != DialogResult.OK) return;

        //Get Atari disk directory
        List<DirectoryEntry> files = fileSystem.DiskDirectory();

        //Create status display form
        StatusForm status = new StatusForm();
        status.Title = "Extracting files";
        status.Show();

        // Extract each file
        string err = "";
        bool hasError = false;
        foreach (DirectoryEntry sourceFile in files)
        {

            status.Message = String.Format("Extracting {0}...", sourceFile.FileName);
            status.Refresh();
            err = ExtractFile(sourceFile.FileName, string.Format("{0}\\{1}", dialog.SelectedPath, sourceFile.FileName));

            // Display extract errors
            if (err != "")
            {
                status.AddError(err);
                hasError = true;
            }
        }

        // If there are no errors close the status box
        if (!hasError) status.Close();
    }

    private void itmChangeDirSectors_Click(object sender, EventArgs e)
    {
        var frm = new AtariDiskExplorer.SectorRangePicker(fileSystem.DirectoryStartSector, fileSystem.DirectoryEndSector);
        if (frm.ShowDialog() == DialogResult.OK)
        {
            fileSystem.DirectoryStartSector = frm.StartSector;
            fileSystem.DirectoryEndSector = frm.EndSector;
            fileSystem.ReadDirectory();
            UpdateList();
        }

    }

    private void itmFindDirectory_Click(object sender, EventArgs e)
    {
        try
        {
            var list = fileSystem.FindDirectory();
            var frm = new AtariDiskExplorer.ListViewer(list);
            frm.Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error while trying to find directory: " + ex.Message, "Find Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void itmViewFileInfo_Click(object sender, EventArgs e)
    {
        ListViewItem lvCurrent = lvFiles.FocusedItem;
        if (lvCurrent == null) return;

        AtariDisk.FileSystems.FileInfo info = null;

        info = fileSystem.GetFileInfo(lvCurrent.Text);

        fileSystem.IsFileValid(lvCurrent.Text, info.FileErrors);

        var frm = new AtariDiskExplorer.ViewFileInfo();
        frm.Info = info;
        frm.MdiParent = this.MdiParent;
        frm.Show();

    }

    private void itmShowSectorMap_Click(object sender, EventArgs e)
    {
        var frm = new AtariDiskExplorer.ViewSectorMap();
        frm.FileSystem = fileSystem;
        frm.ImageFileName = disk.FileName;
        frm.MdiParent = this.MdiParent;
        frm.Show();
        frm.UpdateMap();
    }

    private void DirExplorer_FormClosing(object sender, FormClosingEventArgs e)
    {
        disk.Unmount();
    }

    private void miDumpDirectory_Click(object sender, EventArgs e)
    {
        fileSystem.DumpDirectory();
    }



}

