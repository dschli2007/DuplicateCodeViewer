using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.UI.Metadata;

namespace DuplicateCodeViewer.UI.Helper
{
    internal class GridBuilderHelper
    {
        private readonly DataGridView _grid;
        private SourceFile _sourceFile;
        private Duplicate[] _duplicates;
        private List<Line> _lines;

        public List<Line> Lines => _lines;

        public GridBuilderHelper(DataGridView grid)
        {
            _grid = grid;
            _grid.DataBindingComplete += DataBindingComplete;
        }

        public void Update(SourceFile sourceFile, Duplicate[] duplicates)
        {
            _sourceFile = sourceFile;
            _duplicates = duplicates;

            if (sourceFile == null)
            {
                _grid.DataSource = null;
                return;
            }

            var fs = new FileStream(_sourceFile.Filename, FileMode.Open);
            try
            {
                _lines = new List<Line>();
                using (var sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = new Line
                        {
                            Content = sr.ReadLine()
                            
                        };
                        _lines.Add(line);
                    }
                }
            }
            finally
            {
                fs?.Dispose();
            }

            UpdateDuplicateInLines();

            _grid.DataSource = _lines;
        }

        private void UpdateDuplicateInLines()
        {
            if (_duplicates.Length == 0)
                return;

            foreach (var duplicate in _duplicates)
            {
                var fragment = duplicate.Fragments.First(f => f.SourceFile == _sourceFile);
                for (var i = fragment.LineStart - 1; i < fragment.LineEnd; i++)
                {
                    _lines[i].Duplicate = duplicate;
                }
            }
        }

        private void DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var duplicateCellStyle = _grid.DefaultCellStyle.Clone();
            duplicateCellStyle.BackColor = Color.LightSalmon;

            for (var i = 0; i < _grid.Rows.Count; i++)
            {
                _grid.Rows[i].HeaderCell.Value = (i + 1).ToString();
                if (_lines[i].Duplicate != null)
                    _grid.Rows[i].DefaultCellStyle = duplicateCellStyle;
            }

            SelectFirstRow();
        }

        private void SelectFirstRow()
        {
            var fragment = _duplicates?[0].Fragments.FirstOrDefault(f => f.SourceFile == _sourceFile);
            if (fragment != null)
            {
                _grid.ClearSelection();
                _grid.Rows[fragment.LineStart - 1].Selected = true;
                _grid.FirstDisplayedScrollingRowIndex = Math.Max(fragment.LineStart - 3, 0);
                _grid.Focus();
            }
        }
    }
}
