using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DuplicateCodeViewer.Core.Metadata;
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

        private FileInfo _fileInfo;
        private Duplicate _currentDuplicate;

        private GridBuilderHelper _gridFileHelper;
        private GridBuilderHelper _gridDuplicateFileHelper;

        internal void SetFileInfo(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
            Text = fileInfo.SourceFile.Filename;
            GridFile.AutoGenerateColumns = false;
            GridDuplicateFiles.AutoGenerateColumns = false;
            GridDuplicateFileContent.AutoGenerateColumns = false;

            _gridFileHelper = new GridBuilderHelper(GridFile);
            _gridDuplicateFileHelper = new GridBuilderHelper(GridDuplicateFileContent);

            UpdateGridFile();
        }

        private void UpdateGridFile()
        {
            _gridFileHelper.Update(_fileInfo.SourceFile, _fileInfo.LazyDuplicates);
        }

        public FormViewFile()
        {
            InitializeComponent();
        }

        private void FormViewFile_Load(object sender, EventArgs e)
        {

        }

        private void MnuClose_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void GridFile_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var line = _gridFileHelper.Lines[e.RowIndex];
            if (_currentDuplicate != line.Duplicate)
            {
                SetCurrentDuplicate(line.Duplicate);
            }
        }

        private void SetCurrentDuplicate(Duplicate duplicate)
        {
            _currentDuplicate = duplicate;
            UpdateGridDuplicateFiles();
        }

        private void UpdateGridDuplicateFiles()
        {
            if (_currentDuplicate != null)
            {
                var files = from item in _currentDuplicate.Fragments
                            where item.SourceFile != _fileInfo.SourceFile
                            select item.SourceFile;
                GridDuplicateFiles.DataSource = files.ToList();
            }
            else
            {
                GridDuplicateFiles.DataSource = null;
            }
        }

        private void GridDuplicateFiles_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var dataSource = GridDuplicateFiles.DataSource as IList<SourceFile>;
            if (dataSource != null)
            {
                var duplicatedFile = dataSource[e.RowIndex];
                _gridDuplicateFileHelper.Update(duplicatedFile, new[] { _currentDuplicate });
            }
        }

        private void GridDuplicateFiles_SelectionChanged(object sender, EventArgs e)
        {
            var dataSource = GridDuplicateFiles.DataSource as IList<SourceFile>;
            if (dataSource != null && GridDuplicateFiles.CurrentRow != null)
            {
                var duplicatedFile = dataSource[GridDuplicateFiles.CurrentRow.Index];
                _gridDuplicateFileHelper.Update(duplicatedFile, new[] { _currentDuplicate });
            }
            else
            {
                GridDuplicateFileContent.DataSource = null;
            }
        }
    }
}
