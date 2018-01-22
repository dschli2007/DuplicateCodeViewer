using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DuplicateCodeViewer.Core.LoadController;
using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.UI.Metadata;
using DuplicateCodeViewer.UI.UserInterfaceCommands;

namespace DuplicateCodeViewer.UI
{
    public partial class FormMain : Form
    {
        private ILoadController _controller;
        private List<FileInfo> _files;
        private List<Duplicate> _duplicates;

        public FormMain()
        {
            InitializeComponent();
            InitializeController();
        }

        private void InitializeController()
        {
            _controller = new LoadControllerImplementation();
            _controller.LoadCompleted += Controller_LoadCompleted;
            UserInterfaceCommandExecutor.Controller = _controller;
        }

        private void Controller_LoadCompleted(object sender, EventArgs e)
        {
            _files = (from item in _controller.UniqueFiles
                      orderby item.Filename
                      select new FileInfo { SourceFile = item })
                      .ToList();

            _duplicates = (from item in _controller.Duplicates select item).ToList();

            Action updateGrid = () =>
            {
                GridFiles.AutoGenerateColumns = false;
                GridFiles.DataSource = _files;
            };
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

            // ToDo: Load in other thread
            if (fileInfo.LazyDuplicates == null)
            {
                var items = from item in _duplicates
                    where item.Fragments.Any(f => f.SourceFile == fileInfo.SourceFile)
                    select item;

                fileInfo.LazyDuplicates = items.ToArray();
            }
            
            FormViewFile.ShowFile(fileInfo);
        }
    }
}
