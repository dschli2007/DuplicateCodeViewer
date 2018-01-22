using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.Core.ViewController;
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


        private FileInfo _fileInfo;


        //private GridBuilderHelper _gridFileHelper;
        //private GridBuilderHelper _gridDuplicateFileHelper;

        internal void SetFileInfo(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
            Text = fileInfo.SourceFile.Filename;

            _controller = new ViewController(new FileReaderFactoryImplementation());
            _controller.OnUpdateFileLines += ControllerOnOnUpdateFileLines;
            _controller.OnUpdateDuplicateFiles += Controller_OnUpdateDuplicateFiles;
            _controller.OnUpdateDuplicateFileLines += Controller_OnUpdateDuplicateFileLines;


            _controller.SetContext(_fileInfo.SourceFile, _fileInfo.LazyDuplicates);




            GridFile.AutoGenerateColumns = false;
            GridDuplicateFiles.AutoGenerateColumns = false;
            GridDuplicateFileContent.AutoGenerateColumns = false;

            //_gridFileHelper = new GridBuilderHelper(GridFile);
            // _gridDuplicateFileHelper = new GridBuilderHelper(GridDuplicateFileContent);

            //UpdateGridFile();
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
    }
}
