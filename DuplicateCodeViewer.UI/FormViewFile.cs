using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.Core.ViewController;
using DuplicateCodeViewer.UI.Helper;
using FileInfo = DuplicateCodeViewer.UI.Metadata.FileInfo;

namespace DuplicateCodeViewer.UI
{
    public partial class FormViewFile : Form
    {
        internal static void ShowFile(FileInfo fileInfo)
        {
            var newForm = new FormViewFile();
            newForm.SetFileInfo(fileInfo);
            newForm.Show();
        }
        
        private ViewController _controller;
        
        internal void SetFileInfo(FileInfo fileInfo)
        {
            Text = fileInfo.SourceFile.Filename;

            DataGridViewHelper.SetSourceGridFormats(GridFile);
            DataGridViewHelper.SetSourceGridFormats(GridDuplicateFileContent);
            DataGridViewHelper.SetFilesGridFormats(GridDuplicateFiles);
            GridFile.Columns[0].HeaderText = Path.GetFileName(fileInfo.SourceFile.Filename);

            _controller = new ViewController(new FileReaderFactoryImplementation());
            _controller.OnUpdateFileLines += ControllerOnOnUpdateFileLines;
            _controller.OnUpdateDuplicateFiles += Controller_OnUpdateDuplicateFiles;
            _controller.OnUpdateDuplicateFileLines += Controller_OnUpdateDuplicateFileLines;
            _controller.SetContext(fileInfo.SourceFile, fileInfo.LazyDuplicates);
        }

        private void Controller_OnUpdateDuplicateFileLines(object sender, IList<Line> e)
        {
            GridDuplicateFileContent.DataSource = e;
        }

        private void Controller_OnUpdateDuplicateFiles(object sender, IList<SourceFile> e)
        {
            GridDuplicateFiles.DataSource = e;
        }

        private void ControllerOnOnUpdateFileLines(object sender, IList<Line> e)
        {
            GridFile.DataSource = e;
        }

        public FormViewFile()
        {
            InitializeComponent();
        }

        private void MnuClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GridFile_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _controller.SetCurrentFileLine(e.RowIndex + 1);
        }

        private void GridDuplicateFiles_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var dataSource = GridDuplicateFiles.DataSource as IList<SourceFile>;
            if (dataSource != null)
            {
                var duplicatedFile = dataSource[e.RowIndex];
                _controller.SetCurrentDuplicateFile(duplicatedFile);
            }
            else
            {
                _controller.SetCurrentDuplicateFile(null);
            }
        }

        private void GridDuplicateFiles_SelectionChanged(object sender, EventArgs e)
        {
            var dataSource = GridDuplicateFiles.DataSource as IList<SourceFile>;
            if (dataSource != null && GridDuplicateFiles.CurrentRow != null)
            {
                var duplicatedFile = dataSource[GridDuplicateFiles.CurrentRow.Index];
                _controller.SetCurrentDuplicateFile(duplicatedFile);
            }
            else
            {
                _controller.SetCurrentDuplicateFile(null);
            }
        }

        private void GridFile_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewHelper.SetStyleToGrid(GridFile);
            DataGridViewHelper.SelectFirstDuplicate(GridFile);
        }

        private void GridDuplicateFileContent_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewHelper.SetStyleToGrid(GridDuplicateFileContent);
            DataGridViewHelper.SelectFirstDuplicate(GridDuplicateFileContent);
        }

        private void MnuPrior_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.SelectPriorDuplicate(GridFile);
        }

        private void MnuNext_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.SelectNextDuplicate(GridFile);
        }
    }
}
