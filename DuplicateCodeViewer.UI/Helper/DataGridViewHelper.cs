using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DuplicateCodeViewer.Core.Metadata;

namespace DuplicateCodeViewer.UI.Helper
{
    internal static class DataGridViewHelper
    {
        public static void SetSourceGridFormats(DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;


            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.BackgroundColor = SystemColors.Window;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            var cellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = SystemColors.Window,
                Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                ForeColor = SystemColors.ControlText,
                SelectionBackColor = SystemColors.Highlight,
                SelectionForeColor = SystemColors.HighlightText,
                WrapMode = DataGridViewTriState.False
            };
            
            grid.DefaultCellStyle = cellStyle;
            grid.ReadOnly = true;
            grid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            var rowHeaderStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleRight,
                BackColor = SystemColors.Control,
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular,
                    GraphicsUnit.Point, 0),
                ForeColor = SystemColors.WindowText,
                SelectionBackColor = SystemColors.Highlight,
                SelectionForeColor = SystemColors.HighlightText,
                //WrapMode = System.Windows.Forms.DataGridViewTriState.True
            };
            grid.RowHeadersDefaultCellStyle = rowHeaderStyle;
            grid.RowHeadersWidth = 60;


            var contentColumn = new DataGridViewTextBoxColumn
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DataPropertyName = "Content",
                DefaultCellStyle = cellStyle,
                MinimumWidth = 500,
                HeaderText = "",
                Name = grid.Name + "_CONTENT",
                ReadOnly = true,
                Width = 4000
            };
            
            grid.Columns.AddRange(contentColumn);
        }

        public static void SetFilesGridFormats(DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            foreach (DataGridViewColumn gridColumn in grid.Columns)
            {
                gridColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                gridColumn.Width = 4000;
            }

        }

        public static void SetStyleToGrid(DataGridView grid)
        {
            var lines = grid.DataSource as IList<Line>;
            if (lines == null)
                return;

            var duplicateCellStyle = grid.DefaultCellStyle.Clone();
            duplicateCellStyle.BackColor = Color.LightSalmon;

            for (var i = 0; i < grid.Rows.Count; i++)
            {
                grid.Rows[i].HeaderCell.Value = (i + 1).ToString();
                if (lines[i].Duplicate != null)
                    grid.Rows[i].DefaultCellStyle = duplicateCellStyle;
            }
        }

        public static void SelectFirstDuplicate(DataGridView grid)
        {
            InternalGotoDuplicate(grid, 0, 1, false);
        }

        public static void SelectNextDuplicate(DataGridView grid)
        {
            InternalGotoDuplicate(grid, GetCurrentRowIndex(grid), 1, true);
        }

        public static void SelectPriorDuplicate(DataGridView grid)
        {
            InternalGotoDuplicate(grid, GetCurrentRowIndex(grid), -1, true);
        }

        private static int GetCurrentRowIndex(DataGridView grid)
        {
            var index = grid.CurrentRow?.Index;
            return Convert.ToInt32(index);
        }

        private static void InternalGotoDuplicate(DataGridView grid, int current, int delta, bool skipCurrent)
        {
            var lines = grid.DataSource as IList<Line>;
            if (lines == null)
                return;

            if (skipCurrent)
            {
                while (current >= 0 && current < lines.Count && lines[current].Duplicate != null)
                    current += delta;
            }

            while (current >= 0 && current < lines.Count)
            {
                if (lines[current].Duplicate != null)
                {
                    while (current > 0 && lines[current - 1].Duplicate != null)
                        current--;

                    grid.ClearSelection();
                    grid.FirstDisplayedScrollingRowIndex = Math.Max(current - 5, 0);
                    grid.Rows[current].Selected = true;
                    grid.CurrentCell = grid.Rows[current].Cells[0];

                    break;
                }
                current += delta;
            }
        }


    }
}
