﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DuplicateCodeViewer.Core;
using DuplicateCodeViewer.UI.Metadata;
using DuplicateCodeViewer.UI.UserInterfaceCommands;

namespace DuplicateCodeViewer.UI
{
    public partial class FormMain : Form
    {
        private IController _controller;
        private List<FileInfo> _files;

        public FormMain()
        {
            InitializeComponent();
            InitializeController();
        }

        private void InitializeController()
        {
            _controller = new Controller();
            _controller.LoadCompleted += Controller_LoadCompleted;
            UserInterfaceCommandExecutor.Controller = _controller;
        }

        private void Controller_LoadCompleted(object sender, EventArgs e)
        {
            _files = (from item in _controller.UniqueFiles
                      orderby item.Filename
                      select new FileInfo { SourceFile = item })
                      .ToList();

            Action updateGrid = () => { GridFiles.DataSource = _files; };
            if (GridFiles.InvokeRequired)
                GridFiles.Invoke(updateGrid);
            else
                updateGrid();
        }

        private void MnuQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MnuOpenXmlFile_Click(object sender, EventArgs e)
        {
            var command = new OpenXmlFileCommand();
            UserInterfaceCommandExecutor.Execute(command);
        }

        private void MnuOpenProject_Click(object sender, EventArgs e)
        {
            var command = new OpenVisualStudioFileCommand();
            UserInterfaceCommandExecutor.Execute(command);
        }

        private void MnuSelectDupFinderExe_Click(object sender, EventArgs e)
        {
            var command = new SelectDupFinderExeCommand();
            UserInterfaceCommandExecutor.Execute(command);
        }

        private void MnuAbout_Click(object sender, EventArgs e)
        {
            var command = new ShowAboutCommand();
            UserInterfaceCommandExecutor.Execute(command);
        }

        private void GridFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var fileInfo = _files[e.RowIndex];
            FormViewFile.ShowFile(fileInfo);
        }
    }
}
