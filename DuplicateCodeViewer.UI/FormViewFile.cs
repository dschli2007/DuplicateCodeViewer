using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using DuplicateCodeViewer.UI.Metadata;
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

        internal void SetFileInfo(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
            UpdateGridFile();
        }

        private void UpdateGridFile()
        {
            var fs = new FileStream(_fileInfo.SourceFile.Filename, FileMode.Open);
            try
            {
                var lines = new List<LineInfo>();
                using (var sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = new LineInfo
                        {
                            Content = sr.ReadLine(),
                            LineNumber = lines.Count + 1
                        };
                        lines.Add(line);
                    }

                    GridFile.DataSource = lines;
                }
            }
            finally
            {
                fs?.Dispose();
            }
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

        private void GridFile_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //e.ro
        }
    }
}
