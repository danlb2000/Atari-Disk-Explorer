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
using System.Windows.Forms;

public partial class StatusForm : Form
{
    public StatusForm()
    {
        InitializeComponent();
    }

    public string Title
    {
        set
        {
            this.Text = value;
        }
    }

    public string Message
    {
        set
        {
            UIMessage.Text = value;
        }
    }

    public void AddError(string message)
    {
        UIErrors.Text += message + "\n\r";
    }

    private void UIClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}

